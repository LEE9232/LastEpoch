using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStat : MonoBehaviour
{
    public string enemyName; // �� ������ �̸�
    public int maxHealth = 100; // �ִ� ü��
    public int currentHealth; // ���� ü��
    public int attackDamage = 10; // ���ݷ�
    public float detectionRange = 10f; // �÷��̾� ���� ����
    public int MonsLevel;       // ���� ����
    public int MonsEXP = 50;    // ���Ͱ� �ִ� ����ġ
    private BossHPbar bossHPbar;
    private ItemDrop Drop;
    private Animator M_anim;
    private Playerstats player;
    private Slider hpBar; // ü�¹� �����̴�
    private void Start()
    {
        Drop = GetComponent<ItemDrop>();
        M_anim = GetComponent<Animator>();
        player = FindObjectOfType<Playerstats>();       
        currentHealth = maxHealth;
        MonsEXP +=  player.level;
        UpdateHealthBar();
        bossHPbar = FindObjectOfType<BossHPbar>();
        if(bossHPbar != null)
        {
            bossHPbar.BossHP(maxHealth);
        }
    }
    public void SetHpBar(Slider hpBarSlider)
    {
        hpBar = hpBarSlider;
        hpBar.maxValue = maxHealth;
        UpdateHealthBar(); // �ʱ� ü�¹� ������Ʈ
        bossHPbar.UpdateHP(currentHealth, maxHealth);
        if(bossHPbar !=null)
        {
            bossHPbar.BossHP(maxHealth);
        }
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // ���ݷ� ��ŭ ü�� ����
        UpdateHealthBar(); // ü�¹� ������Ʈ
        bossHPbar.UpdateHP(currentHealth, maxHealth);        
        if (currentHealth <= 0)
        {         
            Die(); // ü���� 0 �����̸� Die �޼��� ȣ
            DropItem(transform.position);
        }
    }
    // ���Ͱ� ������� �� ȣ��Ǵ� �޼���
    public void Die()
    {
        if (player != null)
        {       
            player.AddExp(MonsEXP);
        }
        M_anim.SetBool("Die", true);
        StartCoroutine(DestroyAfterDelay(gameObject , 1));
    }
    // �ڷ�ƾ���� ���� ��ü ����
    private IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
    public void DropItem(Vector3 dropPosition)
    {
        if (Drop != null)
        {
            Drop.DropItem(dropPosition);
        }
    }
    private void UpdateHealthBar()
    {
        if (hpBar != null)
        {
            hpBar.value = currentHealth;
        }
    }
}
