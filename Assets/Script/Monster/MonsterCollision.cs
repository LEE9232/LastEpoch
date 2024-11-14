using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollision : MonoBehaviour
{   
    public MonsterStat monsterStat; // ���� �������ͽ� ��ũ��Ʈ�� ���� ����
    private Playerstats playerStat;
    private Bullet bullet;
    private NovaSkill novaSkill;
    private Novabullet novabullet;
    private NovafinlshSkill novafiniSkill;
    private void Awake()
    {
        monsterStat = GetComponent<MonsterStat>(); // ���� �������ͽ� ��ũ��Ʈ ��������
    }
    private void OnCollisionEnter(Collision collision)
    {       
        // �浹�� ������Ʈ�� �÷��̾����� Ȯ��
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("( �ݸ��� )�ν� �߽��ϴ�.");

            playerStat = collision.gameObject.GetComponent<Playerstats>(); // �÷��̾� �������ͽ� ��ũ��Ʈ ��������
            if (playerStat != null)
            {
                // �÷��̾�� ������ ���ݷ¸�ŭ ������ ������
                playerStat.TakeDamage(monsterStat.attackDamage);
                Debug.Log("( �ݸ��� )�������� �Ծ����ϴ�.");
            }
        }  
        // �浹�� ������Ʈ�� �Ѿ����� Ȯ��
        if (collision.gameObject.CompareTag("Skill"))
        {
            // �Ѿ˿� ���� �������� ������           
            bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                // ���Ϳ��� �Ѿ��� ��������ŭ ������ ������
                monsterStat.TakeDamage(bullet.bulletDamage);
                Debug.Log("( �� �ݸ��� )�������� �������ϴ�.");
                // �浹�� �Ѿ��� ��Ȱ��ȭ�ϰ� Ǯ�� ��ȯ�ϵ��� Bullet Ŭ�������� ó��
                bullet.gameObject.SetActive(false);
                if (monsterStat.currentHealth <= 0)
                {
                    monsterStat.Die(); // ü���� 0 �����̸� Die ȣ��
                    Debug.Log("( �� �ݸ��� )���������� �׾����ϴ�.");
                }
            }
        }
        if (collision.gameObject.CompareTag("Skill"))
        {
            novaSkill = collision.gameObject.GetComponent<NovaSkill>();
            if (novaSkill != null)
            {
                // ���Ϳ��� �Ѿ��� ��������ŭ ������ ������
                monsterStat.TakeDamage(novaSkill.novaDamage);
                Debug.Log("( ��� �ݸ��� )�������� �������ϴ�.");
                novaSkill.gameObject.SetActive(false);
                if (monsterStat.currentHealth <= 0)
                {
                    monsterStat.Die(); // ü���� 0 �����̸� Die ȣ��
                    Debug.Log("( ��� �ݸ��� )���������� �׾����ϴ�.");
                }
            }
        }
        if (collision.gameObject.CompareTag("Skill"))
        {
            novabullet = collision.gameObject.GetComponent<Novabullet>();
            if (novabullet != null)
            {
                // ���Ϳ��� �Ѿ��� ��������ŭ ������ ������
                monsterStat.TakeDamage(novabullet.bulletDamage);
                Debug.Log("( ��� �� )�������� �������ϴ�.");
                if (monsterStat.currentHealth <= 0)
                {
                    monsterStat.Die(); // ü���� 0 �����̸� Die ȣ��
                    Debug.Log("( ��ٺ� �ݸ��� )���������� �׾����ϴ�.");
                }
            }
        }    
        if (collision.gameObject.CompareTag("Skill"))
        {
            novafiniSkill = collision.gameObject.GetComponent<NovafinlshSkill>();
            if (novafiniSkill != null)
            {
                Vector3 collisionPoint = collision.contacts[0].point; // �浹 ������ ������
                // ���Ϳ��� �Ѿ��� ��������ŭ ������ ������
                monsterStat.TakeDamage(novafiniSkill.NovaEndDamage);           
                Debug.Log("( ��� �ǴϽ� )�������� �������ϴ�.");
                if (monsterStat.currentHealth <= 0)
                {
                    monsterStat.Die(); // ü���� 0 �����̸� Die ȣ��
                    Debug.Log("( ��� �ǴϽ� �ݸ��� )���������� �׾����ϴ�.");
                }
            }
        }      
    }
}