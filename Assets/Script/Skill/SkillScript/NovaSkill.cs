using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaSkill : MonoBehaviour
{
    public Playerstats player;
    public GameObject novaPrefab;
    public GameObject particlePrefab;
    private bool isNovating = false;
    private float novaTimer = 2.0f;
    public int novaDamage = 50;
    public int currentNovaDamage;
    private GameObject novaInstance;
    private GameObject particleInstance;
    private ObjectPool novaPool;
    private ObjectPool particlePool;
    private void Start()
    {
        //������Ʈ Ǯ �ʱ�ȭ
        novaPool = new ObjectPool(novaPrefab, Vector3.zero, Quaternion.identity, 10);
        particlePool = new ObjectPool(particlePrefab, Vector3.zero, Quaternion.identity, 10);
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Skill"));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isNovating)
        {
            Nova();
        }
    }
    public void Nova()
    {
        if (!isNovating)
        {          
            StartCoroutine(ActivateNova());      
        }
    }
    IEnumerator ActivateNova()
    {
        isNovating = true; // ��� ��ų ����
        novaInstance = novaPool.GetObject();
        novaInstance.transform.position = transform.position; // �÷��̾� ��ġ�� �̵�
        novaInstance.SetActive(true);
        particleInstance = particlePool.GetObject();  // ��ƼŬ ����
        particleInstance.transform.position = transform.position; // �÷��̾� ��ġ�� �̵�
        particleInstance.SetActive(true);
        yield return new WaitForSeconds(novaTimer);
        // ��� ��ų ��ȯ
        if (novaInstance != null)
        {
            novaPool.ReturnObject(novaInstance);
        }
        // ��ƼŬ ��ȯ
        if (particleInstance != null)
        {
            particlePool.ReturnObject(particleInstance);
        }
        isNovating = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            MonsterStat monsterStat = collision.gameObject.GetComponent<MonsterStat>();
            if (monsterStat != null)
            {
                monsterStat.TakeDamage(novaDamage *= player.nova1Count);
            }
        }
       
    }   
}



