using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;           // ����
    public GameObject bulletPrefab;     // ��ų ������
    public GameObject SkillPosObject; // �߻� ��ġ
    public float bulletSpeed = 25f; // �ӵ�
    public int bulletDamage = 1;   // ������
    public float bulletLifetime = 1.0f; // ��Ȱ�� �ð�
    public float cooldownTime = 0.0f; // ��Ÿ��
    private PlayerAnimation playerainm;   // �÷��̾� �ִϸ��̼� ��ũ��Ʈ ����
    private Queue<GameObject> bulletPool = new Queue<GameObject>();
    private Playerstats playerStats;
    private void Start()
    {
        playerainm = GetComponent<PlayerAnimation>();
        playerStats = GetComponent<Playerstats>();
        // ���̾� �±׷� �÷��̾�� ���� �浹 ȸ��
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
            // �Ѿ� �߻� �� ������ 5��ŭ ����մϴ�.
            if (playerStats != null && playerStats.currentMP >= 1)
            {
                // ���� �Ҹ�
                playerStats.UseMana(1);
                FireBullet();
                playerainm.anim.SetTrigger("Attack"); // Attack �ִϸ��̼� Ʈ���� ȣ��          
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