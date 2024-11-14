using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MouseMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private bool isDead = false;
    public float MoveSpeed = 8.0f; // 기본속도
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.speed = MoveSpeed;
    }
    private void Update()
    {
        if (!isDead)
        {
            MouseMoving();
        }
    }
    public void MouseMoving()
    {
        // 좌클 이동
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                agent.speed = MoveSpeed;
                anim.SetFloat("Runing", 3.0f);
                agent.isStopped = false;
            }
        }
        // 도착시 멈춤
        if (Vector3.Distance(transform.position, agent.destination) <= 1.0f)
        {
            agent.isStopped = true;
            anim.SetFloat("Runing", 0.0f);
        }
        // 우클 스킬 / 제자리 멈춤
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //멈추기  
                agent.SetDestination(transform.position);
                agent.isStopped = true;
                anim.SetFloat("Runing", 0.0f);
                // 제자리에서 회전
                Vector3 lookDirection = hit.point - transform.position;
                lookDirection.y = 0;  // 수평으로만 회전하게 만듭니다
                transform.rotation = Quaternion.LookRotation(lookDirection);
                agent.SetDestination(hit.point);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            // 마우스커서 스크린 상의 위치
            Vector3 mousePosition = Input.mousePosition;
            // 카메라를 통해 위치를 월드 좌표 변환
            Vector3 worldCursorPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));

            // 플레이어의 위치를 기준으로 커서 위치를 계산
            Vector3 shootDirection = worldCursorPosition - transform.position;
            shootDirection.y = 0;

            // 플레이어를 커서 방향을 바라보도록 회전
            transform.rotation = Quaternion.LookRotation(shootDirection);

            // 플레이어의 이동을 멈춤
            agent.SetDestination(transform.position);
            agent.isStopped = true;
            anim.SetFloat("Runing", 0.0f);

        }
    }
    public void Die()
    {
        isDead = true;
        agent.isStopped = true;
        anim.SetFloat("Runing", 0.0f);
        anim.SetBool("Die", true);
    }
    public void Respawn()
    {
        isDead = false;
        anim.SetBool("Die", false);
        anim.SetFloat("Runing", 0.0f);
    } 
}
