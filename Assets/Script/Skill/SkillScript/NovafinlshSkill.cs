using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovafinlshSkill : MonoBehaviour
{
    public Playerstats playerStats;
    public GameObject SkillPosObject;   // �߻� ��ġ
    public GameObject NovaFinish;       // ��ٵ��
    public int NovaEndDamage;           // ��ٵ����� ���� ����
    public int NovaFINISHDagage = 10;
    private Bullet bullet;
    private ObjectPool bulletPool;
    public ParticleSystem collisionParticle; // �浹 ��ƼŬ
    public GameObject collisionParticlePrefab; // �浹 ��ƼŬ ������
    public LayerMask enemyLayer;
    private void Start()
    {
        bullet = GetComponent<Bullet>(); // �Ѿ� ��ũ��Ʈ ����
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Skill"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Skill"), LayerMask.NameToLayer("Skill"));
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Playerstats>(); // �÷��̾� ���� ����
        NovaEndDamage *= NovaFINISHDagage + (playerStats.nova1Count + playerStats.nova2Count + playerStats.nova3Count);
        bulletPool = new ObjectPool(NovaFinish, Vector3.zero, Quaternion.identity, 20); // �Ѿ� ������Ʈ Ǯ ����
       
    }
        
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            MonsterStat monsterStat = collision.gameObject.GetComponent<MonsterStat>();
            if (monsterStat != null)
            {
                NovaEndDamage = CalculateNovaEndDamage(); // ��� ������ ���
                monsterStat.TakeDamage(NovaEndDamage);
            }
            PlayCollisionParticle(collision.contacts[0].point); // �浹 ������ ��ƼŬ ��� �Լ��� ����

            ReturnToPool();
        }
    }
    
    private int CalculateNovaEndDamage()
    {
        Novabullet bullet = NovaFinish.GetComponent<Novabullet>(); // �Ѿ� ��ũ��Ʈ ����
        return bullet.bulletDamage + (playerStats.nova1Count + playerStats.nova2Count + playerStats.nova3Count);
    }
    
    private void ReturnToPool()
    {
        bulletPool.ReturnObject(gameObject); // ������Ʈ Ǯ�� ��ȯ
        gameObject.SetActive(false); // ������Ʈ ��Ȱ��ȭ
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
