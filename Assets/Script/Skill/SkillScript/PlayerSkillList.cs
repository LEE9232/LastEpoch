using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillList : MonoBehaviour
{
    [SerializeField] public Playerstats player;

    private float HealHP;   // HP 초기
    public int SkillDamege = 10; // 스킬 데미지
    private bool HealCool = true;
    private bool SkillCool = true;
    private bool SkillCool2 = true;
    private bool SkillCool3 = true;
    private float HPcooldownTime = 10.0f; // HP 쿨 타임
    private float SkillcooldownTime = 1.0f;
    private float SkillcooldownTime2 = 0.5f;
    public PlayerAnimation Anim;
    //스킬
    private SkillCoolDown CoolDown;
    //쿨타임 이미지
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
    // 힐 
    public void Heal()
    {
        if (Input.GetKeyDown(KeyCode.F) && HealCool)
        {
            player.currentHP = player.maxHP;
            CoolDown.Heal();
            player.healthBar.UpdateHealth(player.currentHP, player.maxHP);
        }
    }
    // HP 회복 쿨타임 코루틴
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
        //블렛으로 퉁...
    }
    public void Nova1()
    {
        CoolDown.UseSkill2();
        // 쿨
    }
    public void Nova2()
    {
        // 그냥 스킬 조건용 
    }
    public void Nova3()
    {
        // 그냥 스킬 조건용 
    }
    public void NovaFinish()
    {
       // SkillDamege *= player.nova1Count + player.nova2Count + player.nova3Count;
        // 모든 노바 카운트를 합산해 2배로 적용하겠다.
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
        //스킬 조합기 이기에 x 
    }

}
