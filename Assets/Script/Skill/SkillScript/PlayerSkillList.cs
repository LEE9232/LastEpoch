using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillList : MonoBehaviour
{
    [SerializeField] public Playerstats player;

    private float HealHP;   // HP �ʱ�
    public int SkillDamege = 10; // ��ų ������
    private bool HealCool = true;
    private bool SkillCool = true;
    private bool SkillCool2 = true;
    private bool SkillCool3 = true;
    private float HPcooldownTime = 10.0f; // HP �� Ÿ��
    private float SkillcooldownTime = 1.0f;
    private float SkillcooldownTime2 = 0.5f;
    public PlayerAnimation Anim;
    //��ų
    private SkillCoolDown CoolDown;
    //��Ÿ�� �̹���
    private void Start()
    {
        CoolDown = GetComponent<SkillCoolDown>();

        player = GetComponent<Playerstats>();
        Anim = GetComponent<PlayerAnimation>();
        HealHP = player.maxHP ;
    }  
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && HealCool)
        {
            Heal();
            StartCoroutine(HPCooldownCoroutine());
           
        }
        if(Input.GetKeyDown(KeyCode.Q) && SkillCool2)
        {
            
            MovingFire();
            StartCoroutine(Skill2CooldownCoroutine());
        }
        if (Input.GetKeyDown(KeyCode.W) && SkillCool)
        {
           
            Nova1();
            StartCoroutine(SkillCooldownCoroutine());
        }
        if (Input.GetKeyDown(KeyCode.E) && SkillCool3)
        {
            Anim.Moving();
            Aura();
            StartCoroutine(Skill3CooldownCoroutine());
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            Anim.Moving();
        }
        
        if(Input.GetMouseButtonDown(1))
        {
            Anim.Moving();
            NovaFinish();
        }
    }
    // �� 
    public void Heal()
    {
        if (Input.GetKeyDown(KeyCode.F) && HealCool)
        {
            player.currentHP = player.maxHP;
            CoolDown.Heal();
            player.healthBar.UpdateHealth(player.currentHP, player.maxHP);
        }
    }
    // HP ȸ�� ��Ÿ�� �ڷ�ƾ
    IEnumerator HPCooldownCoroutine()
    {
        HealCool = false;
        yield return new WaitForSeconds(HPcooldownTime);
        HealCool = true;
    }
    IEnumerator SkillCooldownCoroutine()
    {
        SkillCool = false;
        yield return new WaitForSeconds(SkillcooldownTime);
        SkillCool = true;
    }
    IEnumerator Skill2CooldownCoroutine()
    {
        SkillCool2 = false;
        yield return new WaitForSeconds(SkillcooldownTime2);
        SkillCool2 = true;
    }
    IEnumerator Skill3CooldownCoroutine()
    {
        SkillCool3 = false;
        yield return new WaitForSeconds(SkillcooldownTime2);
        SkillCool3 = true;
    }
    public void ManaBoll()
    {
        //������ ��...
    }
    public void Nova1()
    {
        CoolDown.UseSkill2();
        // ��
    }
    public void Nova2()
    {
        // �׳� ��ų ���ǿ� 
    }
    public void Nova3()
    {
        // �׳� ��ų ���ǿ� 
    }
    public void NovaFinish()
    {
       // SkillDamege *= player.nova1Count + player.nova2Count + player.nova3Count;
        // ��� ��� ī��Ʈ�� �ջ��� 2��� �����ϰڴ�.
    }
    public void Aura()
    {
        CoolDown.UseSkill3();
    }
    public void MovingFire()
    {
        CoolDown.UseSkill1();
    }
    public void Combinator()
    {
        //��ų ���ձ� �̱⿡ x 
    }

}
