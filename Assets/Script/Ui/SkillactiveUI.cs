using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillactiveUI : MonoBehaviour
{
    [SerializeField] private Playerstats player;
    private int SkillUP = 1;
    private int maxSkillPoints = 20; //  �ִ� �������ִ� ����Ʈ
    public void ManaBall()  // ������
    {
        if (player.skillPoint >= 1 && player.manaBall <= maxSkillPoints)
        {
            player.skillPoint -= SkillUP;
            player.manaBall++;
        }
    }
    public void Nova1()  // ��� 1
    {
        if (player.skillPoint >= 1 && player.nova1Count <= maxSkillPoints)
        {
            player.skillPoint -= SkillUP;
            player.nova1Count++;
            Debug.Log(" ���1 ���� ");
        }
        else if(player.nova1Count == maxSkillPoints)
        {
            Debug.Log(" ��ų�� �ִ�� �Ҵ��߽��ϴ�. ");
        }
        else
        {
            Debug.Log(" ����Ʈ�� ���� ");
        }
    }
    public void Nova2() // ��� 2
    {
        if (player.skillPoint >= 1 && player.nova2Count <= maxSkillPoints)
        {
            player.skillPoint -= SkillUP;
            player.nova2Count++;
            Debug.Log(" ���2 ���� ");
        }
        else if (player.nova2Count == maxSkillPoints)
        {
            Debug.Log(" ��ų�� �ִ�� �Ҵ��߽��ϴ�. ");
        }
        else
        {
            Debug.Log(" ����Ʈ�� ���� ");
        }
    }
    public void Nova3() // ��� 3
    {
        if (player.skillPoint >= 1 && player.nova3Count <= maxSkillPoints)
        {
            player.skillPoint -= SkillUP;
            player.nova3Count++;
            Debug.Log(" ���3 ���� ");
        }
        else if (player.nova3Count == maxSkillPoints)
        {
            Debug.Log(" ��ų�� �ִ�� �Ҵ��߽��ϴ�. ");
        }
        else
        {
            Debug.Log(" ����Ʈ�� ���� ");
        }
    }
    public void Novafinish() // 3���� �������� ���
    {
        if (player.skillPoint >= 1 && player.combinatorCount == 1 && player.novafinishCount <= 100)
        {
            player.skillPoint -= SkillUP;
            player.novafinishCount++;
            Debug.Log(" ����ǴϽ� ���� ");
        }
        else if (player.novafinishCount == 100)
        {
            Debug.Log(" ��ų�� �ִ�� �Ҵ��߽��ϴ�. ");
        }
        if(player.combinatorCount != 1 && player.level <= 60 || player.level >= 60)
        {
            Debug.Log(" ������ �������� �ʾҽ��ϴ�. ");
            Debug.Log(" ���� ���� : 60 ");
            Debug.Log(" ���ձ� ���� : 1 ");
        }
        else
        {
            Debug.Log(" ����Ʈ�� ���� ");
        }
    }
    public void MovingFire() // �̵���
    {
        if (player.skillPoint >= 1 && player.movingFireCount <= maxSkillPoints)
        {
            player.skillPoint -= SkillUP;
            player.movingFireCount++;
            Debug.Log(" �̵��� ���� ");
        }
        else if (player.movingFireCount == maxSkillPoints)
        {
            Debug.Log(" ��ų�� �ִ�� �Ҵ��߽��ϴ�. ");
        }
        else
        {
            Debug.Log(" ����Ʈ�� ���� ");
        }
    }
    public void Aura()  // �ƿ��
    {
        if (player.skillPoint >= 1 && player.auraCount <= maxSkillPoints)
        {
            player.skillPoint -= SkillUP;
            player.auraCount++;
            Debug.Log(" �ƿ�� ���� ");
        }
        else if (player.auraCount == maxSkillPoints)
        {
            Debug.Log(" ��ų�� �ִ�� �Ҵ��߽��ϴ�. ");
        }
        else
        {
            Debug.Log(" ����Ʈ�� ���� ");
        }
    }
    public void Combinator() // ���ձ�
    {
        if (player.skillPoint >= 1 && player.nova1Count > 5 && player.nova2Count > 5
            && player.nova3Count > 5 && player.combinatorCount < 2)
        {
            player.skillPoint -= SkillUP;
            player.combinatorCount++;
            Debug.Log(" ���ձ� ���� ");
        }
        else if (player.combinatorCount == 1)
        {
            Debug.Log(" ��ų�� �ִ�� �Ҵ��߽��ϴ�. ");
        }
        if(player.level <= 40 || player.level >= 40 && player.nova1Count <= 5 && player.nova2Count <= 5 && player.nova3Count <= 5 && player.combinatorCount < 2)
        {
            Debug.Log(" ������ �������� �ʾҽ��ϴ�. ");
            Debug.Log(" ���� ���� : 40 ");
            Debug.Log(" ���1 : 5 �̻�, ���2 : 5 �̻�, ���3 : 5 �̻�, ���ձ� : 1 ");
        }
        else
        {
            Debug.Log(" ����Ʈ�� ���� ");
        }
    }
}
