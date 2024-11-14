using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillactiveUI : MonoBehaviour
{
    [SerializeField] private Playerstats player;
    private int SkillUP = 1;
    private int maxSkillPoints = 20; //  최대 찍을수있는 포인트
    public void ManaBall()  // 마나볼
    {
        if (player.skillPoint >= 1 && player.manaBall <= maxSkillPoints)
        {
            player.skillPoint -= SkillUP;
            player.manaBall++;
        }
    }
    public void Nova1()  // 노바 1
    {
        if (player.skillPoint >= 1 && player.nova1Count <= maxSkillPoints)
        {
            player.skillPoint -= SkillUP;
            player.nova1Count++;
            Debug.Log(" 노바1 업업 ");
        }
        else if(player.nova1Count == maxSkillPoints)
        {
            Debug.Log(" 스킬을 최대로 할당했습니다. ");
        }
        else
        {
            Debug.Log(" 포인트가 부족 ");
        }
    }
    public void Nova2() // 노바 2
    {
        if (player.skillPoint >= 1 && player.nova2Count <= maxSkillPoints)
        {
            player.skillPoint -= SkillUP;
            player.nova2Count++;
            Debug.Log(" 노바2 업업 ");
        }
        else if (player.nova2Count == maxSkillPoints)
        {
            Debug.Log(" 스킬을 최대로 할당했습니다. ");
        }
        else
        {
            Debug.Log(" 포인트가 부족 ");
        }
    }
    public void Nova3() // 노바 3
    {
        if (player.skillPoint >= 1 && player.nova3Count <= maxSkillPoints)
        {
            player.skillPoint -= SkillUP;
            player.nova3Count++;
            Debug.Log(" 노바3 업업 ");
        }
        else if (player.nova3Count == maxSkillPoints)
        {
            Debug.Log(" 스킬을 최대로 할당했습니다. ");
        }
        else
        {
            Debug.Log(" 포인트가 부족 ");
        }
    }
    public void Novafinish() // 3가지 합쳤을때 기술
    {
        if (player.skillPoint >= 1 && player.combinatorCount == 1 && player.novafinishCount <= 100)
        {
            player.skillPoint -= SkillUP;
            player.novafinishCount++;
            Debug.Log(" 노바피니쉬 업업 ");
        }
        else if (player.novafinishCount == 100)
        {
            Debug.Log(" 스킬을 최대로 할당했습니다. ");
        }
        if(player.combinatorCount != 1 && player.level <= 60 || player.level >= 60)
        {
            Debug.Log(" 조건이 충족되지 않았습니다. ");
            Debug.Log(" 레벨 제한 : 60 ");
            Debug.Log(" 조합기 레벨 : 1 ");
        }
        else
        {
            Debug.Log(" 포인트가 부족 ");
        }
    }
    public void MovingFire() // 이동기
    {
        if (player.skillPoint >= 1 && player.movingFireCount <= maxSkillPoints)
        {
            player.skillPoint -= SkillUP;
            player.movingFireCount++;
            Debug.Log(" 이동기 업업 ");
        }
        else if (player.movingFireCount == maxSkillPoints)
        {
            Debug.Log(" 스킬을 최대로 할당했습니다. ");
        }
        else
        {
            Debug.Log(" 포인트가 부족 ");
        }
    }
    public void Aura()  // 아우라
    {
        if (player.skillPoint >= 1 && player.auraCount <= maxSkillPoints)
        {
            player.skillPoint -= SkillUP;
            player.auraCount++;
            Debug.Log(" 아우라 업업 ");
        }
        else if (player.auraCount == maxSkillPoints)
        {
            Debug.Log(" 스킬을 최대로 할당했습니다. ");
        }
        else
        {
            Debug.Log(" 포인트가 부족 ");
        }
    }
    public void Combinator() // 조합기
    {
        if (player.skillPoint >= 1 && player.nova1Count > 5 && player.nova2Count > 5
            && player.nova3Count > 5 && player.combinatorCount < 2)
        {
            player.skillPoint -= SkillUP;
            player.combinatorCount++;
            Debug.Log(" 조합기 업업 ");
        }
        else if (player.combinatorCount == 1)
        {
            Debug.Log(" 스킬을 최대로 할당했습니다. ");
        }
        if(player.level <= 40 || player.level >= 40 && player.nova1Count <= 5 && player.nova2Count <= 5 && player.nova3Count <= 5 && player.combinatorCount < 2)
        {
            Debug.Log(" 조건이 충족되지 않았습니다. ");
            Debug.Log(" 레벨 제한 : 40 ");
            Debug.Log(" 노바1 : 5 이상, 노바2 : 5 이상, 노바3 : 5 이상, 조합기 : 1 ");
        }
        else
        {
            Debug.Log(" 포인트가 부족 ");
        }
    }
}
