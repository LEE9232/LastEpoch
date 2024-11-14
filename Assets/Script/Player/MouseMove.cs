using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MouseMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private bool isDead = false;
    public float MoveSpeed = 8.0f; // �⺻�ӵ�
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
        // ��Ŭ �̵�
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
        // ������ ����
        if (Vector3.Distance(transform.position, agent.destination) <= 1.0f)
        {
            agent.isStopped = true;
            anim.SetFloat("Runing", 0.0f);
        }
        // ��Ŭ ��ų / ���ڸ� ����
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //���߱�  
                agent.SetDestination(transform.position);
                agent.isStopped = true;
                anim.SetFloat("Runing", 0.0f);
                // ���ڸ����� ȸ��
                Vector3 lookDirection = hit.point - transform.position;
                lookDirection.y = 0;  // �������θ� ȸ���ϰ� ����ϴ�
                transform.rotation = Quaternion.LookRotation(lookDirection);
                agent.SetDestination(hit.point);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            // ���콺Ŀ�� ��ũ�� ���� ��ġ
            Vector3 mousePosition = Input.mousePosition;
            // ī�޶� ���� ��ġ�� ���� ��ǥ ��ȯ
            Vector3 worldCursorPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));

            // �÷��̾��� ��ġ�� �������� Ŀ�� ��ġ�� ���
            Vector3 shootDirection = worldCursorPosition - transform.position;
            shootDirection.y = 0;

            // �÷��̾ Ŀ�� ������ �ٶ󺸵��� ȸ��
            transform.rotation = Quaternion.LookRotation(shootDirection);

            // �÷��̾��� �̵��� ����
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
