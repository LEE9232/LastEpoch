using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaParticle : MonoBehaviour
{
    public GameObject particlePrefab1; // 파티클 프리팹
    public GameObject particlePrefab2; // 파티클 프리팹
    public GameObject particlePrefab3; // 파티클 프리팹
    public GameObject particlePrefab4; // 파티클 프리팹
    private ObjectPool particlePool1;
    private ObjectPool particlePool2;
    private ObjectPool particlePool3;
    private ObjectPool particlePool4;

    public float particleLifetime = 2.0f; // 파티클의 수명
    private void Start()
    {
        // 파티클 풀 초기화
        particlePool1 = new ObjectPool(particlePrefab1, Vector3.zero, Quaternion.identity, 20); // 초기 풀 크기는 10
        particlePool2 = new ObjectPool(particlePrefab2, Vector3.zero, Quaternion.identity, 20); // 초기 풀 크기는 10
        particlePool3 = new ObjectPool(particlePrefab3, Vector3.zero, Quaternion.identity, 20); // 초기 풀 크기는 10
        particlePool4 = new ObjectPool(particlePrefab4, Vector3.zero, Quaternion.identity, 20); // 초기 풀 크기는 10

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
        particleInstance.SetActive(false); // 활성화된 파티클을 비활성화로 변경
        pool.ReturnObject(particleInstance); // 파티클을 해당 풀에 반환
    
    }
}
