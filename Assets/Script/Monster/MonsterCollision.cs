using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollision : MonoBehaviour
{   
    public MonsterStat monsterStat; // 몬스터 스테이터스 스크립트에 대한 참조
    private Playerstats playerStat;
    private Bullet bullet;
    private NovaSkill novaSkill;
    private Novabullet novabullet;
    private NovafinlshSkill novafiniSkill;
    private void Awake()
    {
        monsterStat = GetComponent<MonsterStat>(); // 몬스터 스테이터스 스크립트 가져오기
    }
    private void OnCollisionEnter(Collision collision)
    {       
        // 충돌한 오브젝트가 플레이어인지 확인
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("( 콜리전 )인식 했습니다.");

            playerStat = collision.gameObject.GetComponent<Playerstats>(); // 플레이어 스테이터스 스크립트 가져오기
            if (playerStat != null)
            {
                // 플레이어에게 몬스터의 공격력만큼 데미지 입히기
                playerStat.TakeDamage(monsterStat.attackDamage);
                Debug.Log("( 콜리전 )데미지를 입었습니다.");
            }
        }  
        // 충돌한 오브젝트가 총알인지 확인
        if (collision.gameObject.CompareTag("Skill"))
        {
            // 총알에 대한 데미지를 가져옴           
            bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                // 몬스터에게 총알의 데미지만큼 데미지 입히기
                monsterStat.TakeDamage(bullet.bulletDamage);
                Debug.Log("( 블랫 콜리전 )데미지를 입혔습니다.");
                // 충돌한 총알을 비활성화하고 풀에 반환하도록 Bullet 클래스에서 처리
                bullet.gameObject.SetActive(false);
                if (monsterStat.currentHealth <= 0)
                {
                    monsterStat.Die(); // 체력이 0 이하이면 Die 호출
                    Debug.Log("( 블랫 콜리전 )데미지통해 죽었습니다.");
                }
            }
        }
        if (collision.gameObject.CompareTag("Skill"))
        {
            novaSkill = collision.gameObject.GetComponent<NovaSkill>();
            if (novaSkill != null)
            {
                // 몬스터에게 총알의 데미지만큼 데미지 입히기
                monsterStat.TakeDamage(novaSkill.novaDamage);
                Debug.Log("( 노바 콜리전 )데미지를 입혔습니다.");
                novaSkill.gameObject.SetActive(false);
                if (monsterStat.currentHealth <= 0)
                {
                    monsterStat.Die(); // 체력이 0 이하이면 Die 호출
                    Debug.Log("( 노바 콜리전 )데미지통해 죽었습니다.");
                }
            }
        }
        if (collision.gameObject.CompareTag("Skill"))
        {
            novabullet = collision.gameObject.GetComponent<Novabullet>();
            if (novabullet != null)
            {
                // 몬스터에게 총알의 데미지만큼 데미지 입히기
                monsterStat.TakeDamage(novabullet.bulletDamage);
                Debug.Log("( 노바 블랫 )데미지를 입혔습니다.");
                if (monsterStat.currentHealth <= 0)
                {
                    monsterStat.Die(); // 체력이 0 이하이면 Die 호출
                    Debug.Log("( 노바블랫 콜리전 )데미지통해 죽었습니다.");
                }
            }
        }    
        if (collision.gameObject.CompareTag("Skill"))
        {
            novafiniSkill = collision.gameObject.GetComponent<NovafinlshSkill>();
            if (novafiniSkill != null)
            {
                Vector3 collisionPoint = collision.contacts[0].point; // 충돌 지점을 가져옴
                // 몬스터에게 총알의 데미지만큼 데미지 입히기
                monsterStat.TakeDamage(novafiniSkill.NovaEndDamage);           
                Debug.Log("( 노바 피니쉬 )데미지를 입혔습니다.");
                if (monsterStat.currentHealth <= 0)
                {
                    monsterStat.Die(); // 체력이 0 이하이면 Die 호출
                    Debug.Log("( 노바 피니쉬 콜리전 )데미지통해 죽었습니다.");
                }
            }
        }      
    }
}