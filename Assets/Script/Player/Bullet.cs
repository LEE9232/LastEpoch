using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;           // 방향
    public GameObject bulletPrefab;     // 스킬 프리팹
    public GameObject SkillPosObject; // 발사 위치
    public float bulletSpeed = 25f; // 속도
    public int bulletDamage = 1;   // 데미지
    public float bulletLifetime = 1.0f; // 비활성 시간
    public float cooldownTime = 0.0f; // 쿨타임
    private PlayerAnimation playerainm;   // 플레이어 애니메이션 스크립트 참조
    private Queue<GameObject> bulletPool = new Queue<GameObject>();
    private Playerstats playerStats;
    private void Start()
    {
        playerainm = GetComponent<PlayerAnimation>();
        playerStats = GetComponent<Playerstats>();
        // 레이어 태그로 플레이어와 블렛의 충돌 회피
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),
        LayerMask.NameToLayer("Skill"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Skill"),
        LayerMask.NameToLayer("Skill"));
        InitializeBulletPool();
    }
    private void InitializeBulletPool()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            // 총알 발사 시 마나를 5만큼 사용합니다.
            if (playerStats != null && playerStats.currentMP >= 1)
            {
                // 마나 소모
                playerStats.UseMana(1);
                FireBullet();
                playerainm.anim.SetTrigger("Attack"); // Attack 애니메이션 트리거 호출          
            }
        }
    }
    private void FireBullet()
    {
        GameObject bullet = GetBulletFromPool();
        if (bullet != null)
        {
            bullet.transform.position = SkillPosObject.transform.position;
            bullet.SetActive(true);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 fireDirection = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
                fireDirection.Normalize();
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = fireDirection * bulletSpeed;
                }
            }
            StartCoroutine(DisableBulletAfterTime(bullet, bulletLifetime));
        }
    }
    GameObject GetBulletFromPool()
    {
        if (bulletPool.Count > 0)
        {
            return bulletPool.Dequeue();
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            return bullet;
        }
    }
    IEnumerator DisableBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            MonsterStat monsterStat = collision.gameObject.GetComponent<MonsterStat>();
            if (monsterStat != null)
            {
                monsterStat.TakeDamage(bulletDamage);
            }
        }
    }
}