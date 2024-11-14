using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FireMoveSkill : MonoBehaviour
{

    public Playerstats player;
    private MouseMove Move;

    public float defaultSpeed = 8.0f;
    public ParticleSystem fireMovePrefab; // ������Ʈ ��ƼŬ �ý���

    private NavMeshAgent navMeshAgent; // �׺�޽� ������Ʈ ������Ʈ
    private bool isSprinting = false; // ������Ʈ ������ ����
    private float sprintTimer = 1.0f; // ������Ʈ Ÿ�̸�

    private ParticleSystem fireMoveInstance;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Move = GetComponent<MouseMove>();
        navMeshAgent.speed = Move.MoveSpeed;
    }
    void Update()
    {
        // Q Ű�� ������ ������Ʈ ����
        if (Input.GetKeyDown(KeyCode.Q) && !isSprinting)
        {
            FireMoveing();
        }
    }
    public void FireMoveing()
    {
        if (isSprinting == false)
        {
            Move.MoveSpeed = 16.0f;
            StartCoroutine(ResetSpeed());
            if (fireMovePrefab != null)
            {
                if (fireMoveInstance == null)
                {   
                    //�÷��̾��� ���ʿ��� ��ƼŬ ����
                    Vector3 spawnPosition = transform.position - transform.forward;
                    fireMoveInstance = Instantiate(fireMovePrefab, transform.position, Quaternion.identity);
                    //��ƼŬ �ý����� �÷��̾��� �ڽ����� ����
                    fireMoveInstance.transform.SetParent(transform);
                }                
                //�÷��̾���z ����� ��ġ�ϰ� �ϴ� ���Ⱚ
                Vector3 forward = transform.forward;
                forward.z = transform.forward.z;
                fireMoveInstance.transform.forward = forward;
                fireMoveInstance.Play();
            }
            
        }
    }
    IEnumerator ResetSpeed()
    {
            isSprinting = true;
            yield return new WaitForSeconds(sprintTimer);
            isSprinting = false;
            Move.MoveSpeed = defaultSpeed;

        if (fireMoveInstance != null)
        {
            fireMoveInstance.Stop();
            StartCoroutine(DestroyParticleAfterDelay(fireMoveInstance, 2f));
        }

    }
    IEnumerator DestroyParticleAfterDelay(ParticleSystem particleSystem, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (particleSystem != null)
        {
            Destroy(particleSystem.gameObject);
        }
    }
}
