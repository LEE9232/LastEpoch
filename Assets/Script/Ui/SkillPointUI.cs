using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPointUI : MonoBehaviour
{
    [SerializeField] private Playerstats playerPoint;
    public GameObject SkillPointImageUI;
    public GameObject SkillPointScore;

    MenuBackGourdList meUi;

    bool activeSkillpointMesege = false;
    bool activeSkillPoScore = false;
    void Start()
    {
        SkillPointImageUI.SetActive(false);
        SkillPointScore.SetActive(false);
        meUi = GetComponent<MenuBackGourdList>();
    }

    
    void Update()
    {                                
            SkillTree();
            SkillplusImage();
    }

    // ��ų ����Ʈ�� 0�̸� false �� �÷��� ������ ��Ȱ�� / 0�̻��̸� true �� Ȱ��
    void SkillplusImage()
    {
        if (playerPoint.skillPoint == 0)
        {
            activeSkillpointMesege = false;
            SkillPointImageUI.SetActive(activeSkillpointMesege);
        }
        else
        {
            activeSkillpointMesege = true; // ��ų ����Ʈ�� 0�� �ƴ� �� true�� ����
            SkillPointImageUI.SetActive(activeSkillpointMesege);
        }
    }
    // �÷��� ��ư ������ ��ųâ ����
    public void ButtonSkillTree()
    {
        activeSkillPoScore = true;
        SkillPointScore.SetActive(activeSkillPoScore);
    }

    // k �� ������ ��ųâ ����
    public void SkillTree()
    {
        if (Input.GetKeyDown(KeyCode.K) || meUi)
        {
            activeSkillPoScore = !activeSkillPoScore;
            SkillPointScore.SetActive(activeSkillPoScore);
        }
    }
    // x ������ ������ ����
    public void Escbutton()
    {
        activeSkillPoScore = false;
        SkillPointScore.SetActive(activeSkillPoScore); // ��ųâ ��Ȱ��
    }
}
