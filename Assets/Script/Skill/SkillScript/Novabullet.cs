using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Novabullet : MonoBehaviour
{
    public Vector3 direction;           // ����
    public GameObject bulletPrefab;     // ��ų ������
    public GameObject SkillPosObject; // �߻� ��ġ
    public float bulletSpeed = 25f; // �ӵ�
    public int bulletDamage = 100;   // ������
    public float bulletLifetime = 1.0f; // ��Ȱ�� �ð�
    public LayerMask enemyLayer;        // �� ���̾�
    private PlayerAnimation playerainm;   // �÷��̾� �ִϸ��̼� ��ũ��Ʈ ����
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
        bulletPool = new ObjectPool(bulletPrefab, Vector3.zero, Quaternion.identity, 30); // �ʱ� Ǯ ũ��� 20
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // �Ѿ� �߻� �� ������ 5��ŭ ����մϴ�.
            if (playerStats != null && playerStats.currentMP >= 10)
            {
                playerainm.anim.SetTrigger("Attack"); // Attack �ִϸ��̼� Ʈ���� ȣ��
                // ���� �Ҹ�
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
            Vector3 collisionPoint = collision.contacts[0].point; // �浹 ������ ������
            MonsterStat monsterStat = collision.gameObject.GetComponent<MonsterStat>();
            if (monsterStat != null)
            {
                monsterStat.TakeDamage(bulletDamage);
            }
        }
    }
}
