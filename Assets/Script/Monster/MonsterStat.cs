using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStat : MonoBehaviour
{
    public string enemyName; // 적 몬스터의 이름
    public int maxHealth = 100; // 최대 체력
    public int currentHealth; // 현재 체력
    public int attackDamage = 10; // 공격력
    public float detectionRange = 10f; // 플레이어 감지 범위
    public int MonsLevel;       // 몬스터 레벨
    public int MonsEXP = 50;    // 몬스터가 주는 경험치
    private BossHPbar bossHPbar;
    private ItemDrop Drop;
    private Animator M_anim;
    private Playerstats player;
    private Slider hpBar; // 체력바 슬라이더
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
        UpdateHealthBar(); // 초기 체력바 업데이트
        bossHPbar.UpdateHP(currentHealth, maxHealth);
        if(bossHPbar !=null)
        {
            bossHPbar.BossHP(maxHealth);
        }
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // 공격력 만큼 체력 감소
        UpdateHealthBar(); // 체력바 업데이트
        bossHPbar.UpdateHP(currentHealth, maxHealth);        
        if (currentHealth <= 0)
        {         
            Die(); // 체력이 0 이하이면 Die 메서드 호
            DropItem(transform.position);
        }
    }
    // 몬스터가 사망했을 때 호출되는 메서드
    public void Die()
    {
        if (player != null)
        {       
            player.AddExp(MonsEXP);
        }
        M_anim.SetBool("Die", true);
        StartCoroutine(DestroyAfterDelay(gameObject , 1));
    }
    // 코루틴으로 몬스터 객체 삭제
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
