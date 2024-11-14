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

    // 스킬 포인트가 0이면 false 로 플러스 아이콘 비활성 / 0이상이면 true 로 활성
    void SkillplusImage()
    {
        if (playerPoint.skillPoint == 0)
        {
            activeSkillpointMesege = false;
            SkillPointImageUI.SetActive(activeSkillpointMesege);
        }
        else
        {
            activeSkillpointMesege = true; // 스킬 포인트가 0이 아닐 때 true로 설정
            SkillPointImageUI.SetActive(activeSkillpointMesege);
        }
    }
    // 플러스 버튼 누르면 스킬창 오픈
    public void ButtonSkillTree()
    {
        activeSkillPoScore = true;
        SkillPointScore.SetActive(activeSkillPoScore);
    }

    // k 를 누르면 스킬창 오픈
    public void SkillTree()
    {
        if (Input.GetKeyDown(KeyCode.K) || meUi)
        {
            activeSkillPoScore = !activeSkillPoScore;
            SkillPointScore.SetActive(activeSkillPoScore);
        }
    }
    // x 아이콘 누르면 종료
    public void Escbutton()
    {
        activeSkillPoScore = false;
        SkillPointScore.SetActive(activeSkillPoScore); // 스킬창 비활성
    }
}
