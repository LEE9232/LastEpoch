using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Playerstats : MonoBehaviour
{
    // �÷��̾��� �Ӽ� ����
    public string playerName;               // �÷��̾� �̸�
    public float maxHP = 100;                     // �ִ� ü�� 
    public float maxMP = 50;                     // �ִ� ����
    public float currentHP;                 // ���� ü��
    public float currentMP;                 // ���� ����
    public int attack = 0;                      // ���ݷ�
    public int defense = 0;                     // ����
    public int level = 0;                   // ���� ����
    public int exp = 0;                     // ����ġ
    public int expToLevelUp = 100;          // ������ ����
    public int hpIncreasePerLevel = 20;     // �������� HP ������
    public int mpIncreasePerLevel = 10;     // �������� MP ������
    public int defenseIncreasePerLevel = 5; // �������� ���� ������
    public float healthRegenRate = 20f; // �ʴ� ü�� �����
    public float manaRegenRate = 20f;   // �ʴ� ���� �����
    public int skillPoint = 1;          //��ų ����Ʈ 
    private MouseMove playerMove;
    private MonsterAi monsterAi;
    public HealthBar healthBar;             // ü�¹� �ҷ�����
    public ManaBar manaBar;                 // ������ �ҷ�����
    public EXPbar expBar;                   // ����ġ �� �߰�
    private Animator anim;                          // �ִϸ����� �ҷ�����
    private bool isDead = false;            // �÷��̾ �׾����� ����
    public int nova1Count;
    public int nova2Count;
    public int nova3Count;
    public int novafinishCount;
    public int movingFireCount;
    public int auraCount;
    public int combinatorCount;
    public int manaBall;
    private void Awake()
    {   
        anim = GetComponent<Animator>();
        playerMove = GetComponent<MouseMove>();
        // �÷��̾� �����͸� ����
        PlayerData loadedPlayerData = PlayerSaveLoad.LoadPlayerData();
        if (loadedPlayerData != null)
        {
            playerName = loadedPlayerData.playerName;
            maxHP = loadedPlayerData.maxHP;
            maxMP = loadedPlayerData.maxMP;
            currentHP = loadedPlayerData.currentHP;
            currentMP = loadedPlayerData.currentMP;
            attack = loadedPlayerData.attack;
            defense = loadedPlayerData.defense;
            level = loadedPlayerData.level;
            exp = loadedPlayerData.exp;
            expToLevelUp = loadedPlayerData.expToLevelUp;
            hpIncreasePerLevel = loadedPlayerData.hpIncreasePerLevel;
            mpIncreasePerLevel = loadedPlayerData.mpIncreasePerLevel;
            defenseIncreasePerLevel = loadedPlayerData.defenseIncreasePerLevel;
            skillPoint = loadedPlayerData.skillPoint;
            nova1Count = loadedPlayerData.nova1Count;
            nova2Count = loadedPlayerData.nova2Count;
            nova3Count = loadedPlayerData.nova3Count;
            novafinishCount = loadedPlayerData.novafinishCount;
            movingFireCount = loadedPlayerData.movingFireCount;
            auraCount = loadedPlayerData.auraCount;
            combinatorCount = loadedPlayerData.combinatorCount;
            manaBall = loadedPlayerData.manaBall;
        }
        else
        {
            currentHP = maxHP;
            currentMP = maxMP;
        }
        
        if (healthBar != null)
        {
            healthBar.Initialize(maxHP);
            healthBar.UpdateHealth(currentHP, maxHP);
        }
        if (manaBar != null)
        {
            manaBar.UpdateMana(currentMP, maxMP);
        }
        if (expBar != null) // ����ġ �� �ʱ�ȭ
        {
            expBar.Initialize(expToLevelUp);
            expBar.UpdateEXP(exp, expToLevelUp);
        }
    }
    // ������Ʈ�� �ı��ɶ� �÷��̾��� ������ �����ϰ� �������� �Ѱ���

    private void OnDestroy()
    {
        PlayerData playerData = new PlayerData
        {
            playerName = this.playerName,
            maxHP = this.maxHP,
            maxMP = this.maxMP,
            currentHP = this.currentHP,
            currentMP = this.currentMP,
            attack = this.attack,
            defense = this.defense,
            level = this.level,
            exp = this.exp,
            expToLevelUp = this.expToLevelUp,
            hpIncreasePerLevel = this.hpIncreasePerLevel,
            mpIncreasePerLevel = this.mpIncreasePerLevel,
            defenseIncreasePerLevel = this.defenseIncreasePerLevel,
            skillPoint = this.skillPoint,
            nova1Count = this.nova1Count,
            nova2Count = this.nova2Count,
            nova3Count = this.nova3Count,
            novafinishCount = this.novafinishCount,
            movingFireCount = this.movingFireCount,
            auraCount = this.auraCount,
            combinatorCount = this.combinatorCount,
            manaBall = this.manaBall
        };
        PlayerSaveLoad.SavePlayerData(playerData);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void Update()
    {
        RegenerateHealthAndMana();
        if (Input.GetKeyDown(KeyCode.P))
        {

            // ������ �ʱ�ȭ
            ResetPlayerData();
        }
    }
    // �÷��̾� �����͸� �ʱ�ȭ�ϴ� �޼���
    private void ResetPlayerData()
    {
        playerName = "Player";
        maxHP = 100;
        maxMP = 50;
        currentHP = maxHP;
        currentMP = maxMP;
        attack = 0;
        defense = 5;
        level = 1; // �� �κ��� �߰��߽��ϴ�.
        exp = 0;
        expToLevelUp = 100;
        hpIncreasePerLevel = 20;
        mpIncreasePerLevel = 10;
        defenseIncreasePerLevel = 5;

        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHP, maxHP);
        }
        if (manaBar != null)
        {
            manaBar.UpdateMana(currentMP, maxMP);
        }
        if (expBar != null) // ����ġ �� ������Ʈ
        {
            expBar.UpdateEXP(exp, expToLevelUp);
        }
        OnDestroy();
    }
    private void RegenerateHealthAndMana()
    {
        if (!isDead)
        {
            if (currentHP < maxHP)
            {
                currentHP += healthRegenRate * Time.deltaTime;
                currentHP = Mathf.Min(currentHP, maxHP); // ü���� �ִ� ü���� �ʰ����� �ʵ���
                if (healthBar != null)
                {
                    healthBar.UpdateHealth(currentHP, maxHP);
                }
            }

            if (currentMP < maxMP)
            {
                currentMP += manaRegenRate * Time.deltaTime;
                currentMP = Mathf.Min(currentMP, maxMP); // ������ �ִ� ������ �ʰ����� �ʵ���
                if (manaBar != null)
                {
                    manaBar.UpdateMana(currentMP, maxMP);
                }
            }
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Village") // ���� �� �̸�
        {
            currentHP = maxHP;
            currentMP = maxMP;

            if (healthBar != null)
            {
                healthBar.UpdateHealth(currentHP, maxHP);
            }
            if (manaBar != null)
            {
                manaBar.UpdateMana(currentMP, maxMP);
            }
            if (expBar != null) // ����ġ �� ������Ʈ
            {
                expBar.UpdateEXP(exp, expToLevelUp);
            }
            Debug.Log(playerName + " has entered the town. HP and MP are restored.");
        }
    } 
    // Mathf.Max  =  �ּ� �ִ밪�� �����ϰ� ������ ��� / �ǽð� ������Ʈ�� �Ѵ�.

    // �ǰ� �ÿ� ü���� ���ҽ�Ű�� �޼���
    public void TakeDamage(int damage)
    {
        int damageTaken = damage;// - defense;
       // currentHP -= damageTaken;
        currentHP -= Mathf.Max(0, damageTaken); // ü���� ������ ���� �ʵ��� �մϴ�.
        Debug.Log(playerName + " took " + damageTaken + " damage.");
        Debug.Log(playerName + "'s HP: " + currentHP);
    if (healthBar != null)
        {
        healthBar.UpdateHealth(currentHP, maxHP);
        }
    if (currentHP <= 0)
        {
            Die();
        }
    }
    public void UseMana(float amount)
    {
        currentMP -= Mathf.Max(0, amount);
        Debug.Log(playerName + " used " + amount + " mana.");
        Debug.Log(playerName + "'s MP: " + currentMP);

        if (manaBar != null)
        {
            manaBar.UpdateMana(currentMP, maxMP);
        }
        if (currentMP <= 0)
        {
            Debug.Log(playerName + "MP�� �����մϴ�. ");
        }

    }
    // �÷��̾� ��� �ÿ� ȣ��Ǵ� �޼���
    public void Die()
    {
        isDead = true;
        Debug.Log("�÷��̾� ����");
        Debug.Log(playerName + " has died.");
        // ��� ó�� �� �߰� �۾� ����

        if (playerMove != null)
        {
            playerMove.Die();
            playerMove.enabled = false;
            exp -= level * 4;         // ��� �� ����ġ�� ����x4 �� �ҵ��� ����
            if (exp < 0)
            {
                exp = 0;              //��� �� �÷��̾��� ����ġ�� 0�̶�� 0���� �ʱ�ȭ�� �ϰڴ�.
            }
        }
        
        // ��Ȱ�� ���� Respawn �޼��� ȣ��
        StartCoroutine(Respawn());
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(10); // 10�� �� ��Ȱ
        isDead = false;
        anim.SetBool("Die", false);
        currentHP = maxHP * 0.5f; // ��Ȱ �� ü���� �ִ� ü���� ����
        currentMP = maxMP * 0.5f; // ��Ȱ �� ������ �ִ� ������ ����
        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHP, maxHP);
        }
        if (manaBar != null)
        {
            manaBar.UpdateMana(currentMP, maxMP);
        }

        // �÷��̾� ������ �ٽ� Ȱ��ȭ
        if (playerMove != null)
        {
            playerMove.Respawn();
            playerMove.enabled = true;
        }
        Debug.Log(playerName + " has respawned.");
    }

    // ����ġ�� �߰��ϰ� �������� �˻��ϴ� �޼���
    public void AddExp(int expAmount)
    {
        exp += expAmount;
        Debug.Log(playerName + " gained " + expAmount + " experience points.");

        if (expBar != null) // ����ġ �� ������Ʈ
        {
            expBar.UpdateEXP(exp, expToLevelUp);
        }
        // �������� �˻��մϴ�.
        if (exp >= expToLevelUp)
        {
            LevelUp();
        }
    }

    // ������ �ÿ� ȣ��Ǵ� �޼���
    private void LevelUp()
    {
        level++;
        skillPoint++;
        exp -= expToLevelUp;
        expToLevelUp *= 2; // ������ ����ġ�� �� ��� ������ŵ�ϴ�.
        defense += defenseIncreasePerLevel;
        maxHP += hpIncreasePerLevel;
        maxMP += mpIncreasePerLevel;
        healthRegenRate += 3;
        manaRegenRate += 3;
        currentHP = maxHP; // ü���� ������ �ִ� ü������ �缳���մϴ�.

        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHP, maxHP);
        }
        if (expBar != null) // ����ġ �� ������Ʈ
        {
            expBar.UpdateEXP(exp, expToLevelUp);
        }
        Debug.Log(playerName + " leveled up to level " + level + "!");
    }
}
