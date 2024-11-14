using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Novabullet : MonoBehaviour
{
    public Vector3 direction;           // 방향
    public GameObject bulletPrefab;     // 스킬 프리팹
    public GameObject SkillPosObject; // 발사 위치
    public float bulletSpeed = 25f; // 속도
    public int bulletDamage = 100;   // 데미지
    public float bulletLifetime = 1.0f; // 비활성 시간
    public LayerMask enemyLayer;        // 적 레이어
    private PlayerAnimation playerainm;   // 플레이어 애니메이션 스크립트 참조
    private Playerstats playerStats;
    private ObjectPool bulletPool;
    private void Start()
    {
        playerainm = GetComponent<PlayerAnimation>();
        playerStats = GetComponent<Playerstats>();
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),
        LayerMask.NameToLayer("Skill"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Skill"),
       LayerMask.NameToLayer("Skill"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Item"),
      LayerMask.NameToLayer("Skill"));
        bulletPool = new ObjectPool(bulletPrefab, Vector3.zero, Quaternion.identity, 30); // 초기 풀 크기는 20
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // 총알 발사 시 마나를 5만큼 사용합니다.
            if (playerStats != null && playerStats.currentMP >= 10)
            {
                playerainm.anim.SetTrigger("Attack"); // Attack 애니메이션 트리거 호출
                // 마나 소모
                playerStats.UseMana(10);
                FireBullet();
            }
        }
    }
    private void FireBullet()
    {
        Vector3 bulletPosition = SkillPosObject.transform.position;
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = bulletPosition;
        bullet.transform.rotation = Quaternion.identity;
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


    IEnumerator DisableBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        bulletPool.ReturnObject(bullet);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 collisionPoint = collision.contacts[0].point; // 충돌 지점을 가져옴
            MonsterStat monsterStat = collision.gameObject.GetComponent<MonsterStat>();
            if (monsterStat != null)
            {
                monsterStat.TakeDamage(bulletDamage);
            }
        }
    }
}
