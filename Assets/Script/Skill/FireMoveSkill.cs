using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FireMoveSkill : MonoBehaviour
{

    public Playerstats player;
    private MouseMove Move;

    public float defaultSpeed = 8.0f;
    public ParticleSystem fireMovePrefab; // 스프린트 파티클 시스템

    private NavMeshAgent navMeshAgent; // 네비메시 에이전트 컴포넌트
    private bool isSprinting = false; // 스프린트 중인지 여부
    private float sprintTimer = 1.0f; // 스프린트 타이머

    private ParticleSystem fireMoveInstance;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Move = GetComponent<MouseMove>();
        navMeshAgent.speed = Move.MoveSpeed;
    }
    void Update()
    {
        // Q 키를 누르면 스프린트 시작
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
                    //플레이어의 뒤쪽에서 파티클 시작
                    Vector3 spawnPosition = transform.position - transform.forward;
                    fireMoveInstance = Instantiate(fireMovePrefab, transform.position, Quaternion.identity);
                    //파티클 시스템을 플레이어의 자식으로 설정
                    fireMoveInstance.transform.SetParent(transform);
                }                
                //플레이어의z 방향과 일치하게 하는 방향값
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
