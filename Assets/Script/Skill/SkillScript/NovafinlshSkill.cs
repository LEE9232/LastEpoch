using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovafinlshSkill : MonoBehaviour
{
    public Playerstats playerStats;
    public GameObject SkillPosObject;   // 발사 위치
    public GameObject NovaFinish;       // 노바드랍
    public int NovaEndDamage;           // 노바데미지 담을 변수
    public int NovaFINISHDagage = 10;
    private Bullet bullet;
    private ObjectPool bulletPool;
    public ParticleSystem collisionParticle; // 충돌 파티클
    public GameObject collisionParticlePrefab; // 충돌 파티클 프리팹
    public LayerMask enemyLayer;
    private void Start()
    {
        bullet = GetComponent<Bullet>(); // 총알 스크립트 참조
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Skill"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Skill"), LayerMask.NameToLayer("Skill"));
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Playerstats>(); // 플레이어 스탯 참조
        NovaEndDamage *= NovaFINISHDagage + (playerStats.nova1Count + playerStats.nova2Count + playerStats.nova3Count);
        bulletPool = new ObjectPool(NovaFinish, Vector3.zero, Quaternion.identity, 20); // 총알 오브젝트 풀 생성
       
    }
        
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            MonsterStat monsterStat = collision.gameObject.GetComponent<MonsterStat>();
            if (monsterStat != null)
            {
                NovaEndDamage = CalculateNovaEndDamage(); // 노바 데미지 계산
                monsterStat.TakeDamage(NovaEndDamage);
            }
            PlayCollisionParticle(collision.contacts[0].point); // 충돌 지점을 파티클 재생 함수에 전달

            ReturnToPool();
        }
    }
    
    private int CalculateNovaEndDamage()
    {
        Novabullet bullet = NovaFinish.GetComponent<Novabullet>(); // 총알 스크립트 참조
        return bullet.bulletDamage + (playerStats.nova1Count + playerStats.nova2Count + playerStats.nova3Count);
    }
    
    private void ReturnToPool()
    {
        bulletPool.ReturnObject(gameObject); // 오브젝트 풀로 반환
        gameObject.SetActive(false); // 오브젝트 비활성화
    }
    private void PlayCollisionParticle(Vector3 position)
    {
        if (collisionParticle != null)
        {
            GameObject particleObject = Instantiate(collisionParticlePrefab, position, Quaternion.identity);
            ParticleSystem particle = particleObject.GetComponent<ParticleSystem>();
            if (particle != null)
            {
                particle.Play();
                StartCoroutine(DestroyParticleAfterDuration(particleObject, 2f));
            }
            else
            {
                Destroy(particleObject);
            }
        }
    }
    IEnumerator DestroyParticleAfterDuration(GameObject particleObject, float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(particleObject);
    }


}
