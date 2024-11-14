using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaParticle : MonoBehaviour
{
    public GameObject particlePrefab1; // ��ƼŬ ������
    public GameObject particlePrefab2; // ��ƼŬ ������
    public GameObject particlePrefab3; // ��ƼŬ ������
    public GameObject particlePrefab4; // ��ƼŬ ������
    private ObjectPool particlePool1;
    private ObjectPool particlePool2;
    private ObjectPool particlePool3;
    private ObjectPool particlePool4;

    public float particleLifetime = 2.0f; // ��ƼŬ�� ����
    private void Start()
    {
        // ��ƼŬ Ǯ �ʱ�ȭ
        particlePool1 = new ObjectPool(particlePrefab1, Vector3.zero, Quaternion.identity, 20); // �ʱ� Ǯ ũ��� 10
        particlePool2 = new ObjectPool(particlePrefab2, Vector3.zero, Quaternion.identity, 20); // �ʱ� Ǯ ũ��� 10
        particlePool3 = new ObjectPool(particlePrefab3, Vector3.zero, Quaternion.identity, 20); // �ʱ� Ǯ ũ��� 10
        particlePool4 = new ObjectPool(particlePrefab4, Vector3.zero, Quaternion.identity, 20); // �ʱ� Ǯ ũ��� 10

        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Skill"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Skill"), LayerMask.NameToLayer("Skill"));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject particleInstance1 = particlePool1.GetObject();
            GameObject particleInstance2 = particlePool2.GetObject();
            GameObject particleInstance3 = particlePool3.GetObject();
            GameObject particleInstance4 = particlePool4.GetObject();

            Vector3 collisionPoint = collision.contacts[0].point;

            particleInstance1.transform.position = collisionPoint;
            particleInstance2.transform.position = collisionPoint;
            particleInstance3.transform.position = collisionPoint;
            particleInstance4.transform.position = collisionPoint;


        
            StartCoroutine(ReturnParticleAfterTime(particleInstance1, particleLifetime, particlePool1)); 
            StartCoroutine(ReturnParticleAfterTime(particleInstance2, particleLifetime, particlePool2)); 
            StartCoroutine(ReturnParticleAfterTime(particleInstance3, particleLifetime, particlePool3)); 
            StartCoroutine(ReturnParticleAfterTime(particleInstance4, particleLifetime, particlePool4));                                                                
        }
    }
    
    private IEnumerator ReturnParticleAfterTime(GameObject particleInstance, float time, ObjectPool pool)
    {
        yield return new WaitForSeconds(time);
        particleInstance.SetActive(false); // Ȱ��ȭ�� ��ƼŬ�� ��Ȱ��ȭ�� ����
        pool.ReturnObject(particleInstance); // ��ƼŬ�� �ش� Ǯ�� ��ȯ
    
    }
}
