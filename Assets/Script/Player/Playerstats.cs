using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Playerstats : MonoBehaviour
{
    // 플레이어의 속성 변수
    public string playerName;               // 플레이어 이름
    public float maxHP = 100;                     // 최대 체력 
    public float maxMP = 50;                     // 최대 마나
    public float currentHP;                 // 현재 체력
    public float currentMP;                 // 현재 마나
    public int attack = 0;                      // 공격력
    public int defense = 0;                     // 방어력
    public int level = 0;                   // 현재 레벨
    public int exp = 0;                     // 경험치
    public int expToLevelUp = 100;          // 레벨업 조건
    public int hpIncreasePerLevel = 20;     // 레벨업시 HP 증가량
    public int mpIncreasePerLevel = 10;     // 레벨업시 MP 증가량
    public int defenseIncreasePerLevel = 5; // 레벨업시 방어력 증가량
    public float healthRegenRate = 20f; // 초당 체력 재생량
    public float manaRegenRate = 20f;   // 초당 마나 재생량
    public int skillPoint = 1;          //스킬 포인트 
    private MouseMove playerMove;
    private MonsterAi monsterAi;
    public HealthBar healthBar;             // 체력바 불러오기
    public ManaBar manaBar;                 // 마나바 불러오기
    public EXPbar expBar;                   // 경험치 바 추가
    private Animator anim;                          // 애니메이터 불러오기
    private bool isDead = false;            // 플레이어가 죽었는지 여부
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
        // 플레이어 데이터를 저장
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
        if (expBar != null) // 경험치 바 초기화
        {
            expBar.Initialize(expToLevelUp);
            expBar.UpdateEXP(exp, expToLevelUp);
        }
    }
    // 오브젝트가 파괴될때 플레이어의 정보를 저장하고 다음씬에 넘겨줌

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

            // 데이터 초기화
            ResetPlayerData();
        }
    }
    // 플레이어 데이터를 초기화하는 메서드
    private void ResetPlayerData()
    {
        playerName = "Player";
        maxHP = 100;
        maxMP = 50;
        currentHP = maxHP;
        currentMP = maxMP;
        attack = 0;
        defense = 5;
        level = 1; // 이 부분을 추가했습니다.
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
        if (expBar != null) // 경험치 바 업데이트
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
                currentHP = Mathf.Min(currentHP, maxHP); // 체력이 최대 체력을 초과하지 않도록
                if (healthBar != null)
                {
                    healthBar.UpdateHealth(currentHP, maxHP);
                }
            }

            if (currentMP < maxMP)
            {
                currentMP += manaRegenRate * Time.deltaTime;
                currentMP = Mathf.Min(currentMP, maxMP); // 마나가 최대 마나를 초과하지 않도록
                if (manaBar != null)
                {
                    manaBar.UpdateMana(currentMP, maxMP);
                }
            }
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Village") // 마을 씬 이름
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
            if (expBar != null) // 경험치 바 업데이트
            {
                expBar.UpdateEXP(exp, expToLevelUp);
            }
            Debug.Log(playerName + " has entered the town. HP and MP are restored.");
        }
    } 
    // Mathf.Max  =  최소 최대값을 보장하고 싶을때 사용 / 실시간 업데이트를 한다.

    // 피격 시에 체력을 감소시키는 메서드
    public void TakeDamage(int damage)
    {
        int damageTaken = damage;// - defense;
       // currentHP -= damageTaken;
        currentHP -= Mathf.Max(0, damageTaken); // 체력은 음수가 되지 않도록 합니다.
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
            Debug.Log(playerName + "MP가 부족합니다. ");
        }

    }
    // 플레이어 사망 시에 호출되는 메서드
    public void Die()
    {
        isDead = true;
        Debug.Log("플레이어 죽음");
        Debug.Log(playerName + " has died.");
        // 사망 처리 등 추가 작업 수행

        if (playerMove != null)
        {
            playerMove.Die();
            playerMove.enabled = false;
            exp -= level * 4;         // 사망 시 경험치를 레벨x4 를 잃도록 설정
            if (exp < 0)
            {
                exp = 0;              //사망 시 플레이어의 경험치가 0이라면 0으로 초기화를 하겠다.
            }
        }
        
        // 부활을 위해 Respawn 메서드 호출
        StartCoroutine(Respawn());
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(10); // 10초 후 부활
        isDead = false;
        anim.SetBool("Die", false);
        currentHP = maxHP * 0.5f; // 부활 시 체력을 최대 체력의 절반
        currentMP = maxMP * 0.5f; // 부활 시 마나를 최대 마나의 절반
        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHP, maxHP);
        }
        if (manaBar != null)
        {
            manaBar.UpdateMana(currentMP, maxMP);
        }

        // 플레이어 움직임 다시 활성화
        if (playerMove != null)
        {
            playerMove.Respawn();
            playerMove.enabled = true;
        }
        Debug.Log(playerName + " has respawned.");
    }

    // 경험치를 추가하고 레벨업을 검사하는 메서드
    public void AddExp(int expAmount)
    {
        exp += expAmount;
        Debug.Log(playerName + " gained " + expAmount + " experience points.");

        if (expBar != null) // 경험치 바 업데이트
        {
            expBar.UpdateEXP(exp, expToLevelUp);
        }
        // 레벨업을 검사합니다.
        if (exp >= expToLevelUp)
        {
            LevelUp();
        }
    }

    // 레벨업 시에 호출되는 메서드
    private void LevelUp()
    {
        level++;
        skillPoint++;
        exp -= expToLevelUp;
        expToLevelUp *= 2; // 레벨업 경험치를 두 배로 증가시킵니다.
        defense += defenseIncreasePerLevel;
        maxHP += hpIncreasePerLevel;
        maxMP += mpIncreasePerLevel;
        healthRegenRate += 3;
        manaRegenRate += 3;
        currentHP = maxHP; // 체력을 증가된 최대 체력으로 재설정합니다.

        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHP, maxHP);
        }
        if (expBar != null) // 경험치 바 업데이트
        {
            expBar.UpdateEXP(exp, expToLevelUp);
        }
        Debug.Log(playerName + " leveled up to level " + level + "!");
    }
}
