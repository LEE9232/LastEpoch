using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum MonsState
{
    Idle,
    Run,
    Attack,
    Die
}
public class MonsterAi : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public Animator anim;
    public MonsterStat monsterStat;
    private Playerstats player;
    public MonsState m_State;
    public Transform Playertransform;
    public float attackDistance = 2.0f;
    public float ChaseDistance = 10.0f;
    public float attackCoolDown = 2.0f;
    public float attackDelay = 3.0f;   
    public float damageDelay = 0.5f;   
    private float lastAttackTime;
    private bool isAttacking;
    private bool hasEnteredRunState = false;
    private GameObject instantiatedObject;
    private void Awake()
    {
        player = GetComponent<Playerstats>();
        player = GetComponent<Playerstats>();
        m_State = MonsState.Idle;
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        monsterStat = GetComponent<MonsterStat>();
        lastAttackTime = -attackCoolDown;
    }
    private void Update()
    {
        switch (m_State)
        {
            case MonsState.Idle:
                HandleIdleState();
                break;
            case MonsState.Run:
                HandleRunState();
                break;
            case MonsState.Attack:
                HandleAttackState();
                break;
            case MonsState.Die:
                HandleDieState();
                break;
        }
    }

    private void HandleIdleState()
    {
        if (Vector3.Distance(transform.position, Playertransform.position) <= ChaseDistance)
        {
            m_State = MonsState.Run;
            anim.SetBool("Run", true);
            hasEnteredRunState = true;
        }
        if (monsterStat.currentHealth <= 0)
        {
            m_State = MonsState.Die;
        }
    }

    private void HandleRunState()
    {
        navAgent.SetDestination(Playertransform.position);
        if (Vector3.Distance(transform.position, Playertransform.position) <= attackDistance)
        {
            m_State = MonsState.Attack;
            anim.SetBool("Run", false);
        }
        if (monsterStat.currentHealth <= 0)
        {
            m_State = MonsState.Die;
        }
    }
    private void HandleAttackState()
    {
        navAgent.SetDestination(transform.position); // 공격 중에는 움직이지 않음
        if (!isAttacking && Time.time - lastAttackTime >= attackCoolDown)
        {
            anim.SetTrigger("Attack");
            StartCoroutine(AttackWithDelay());
        }
        // 범위 벗어나면 따라감
        if (Vector3.Distance(transform.position, Playertransform.position) > attackDistance)
        {
            m_State = MonsState.Run;
            anim.SetBool("Run", true);
        }
        if(monsterStat.currentHealth <= 0)
        {
            m_State = MonsState.Die;       
        }
    }
    private void HandleDieState()
    {
            navAgent.SetDestination(transform.position);
            anim.SetBool("Run", false);
            anim.SetBool("Die", true);
            monsterStat.Die();
    }

    private IEnumerator AttackWithDelay()
    {
        isAttacking = true; // 공격중    
        yield return new WaitForSeconds(attackDelay);
        anim.SetTrigger("Attack");
        if (Vector3.Distance(transform.position, Playertransform.position) <= attackDistance)
        {
            monsterStat.TakeDamage(monsterStat.attackDamage);
        }
        Vector3 directionToPlayer = (Playertransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0, directionToPlayer.z));
        transform.rotation = lookRotation;
        isAttacking = false;
        lastAttackTime = Time.time;
        if (Vector3.Distance(transform.position, Playertransform.position) <= attackDistance)
        {
            m_State = MonsState.Run;
            anim.SetBool("Run", true);
        }
    }
}

