using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolDown : MonoBehaviour
{
    // 각 스킬에 대한 쿨다운을 관리하는 구조체
    [System.Serializable] // 이 특성을 사용하면 Unity 에디터에서 구조체를 편집할 수 있습니다.
    public struct Skill
    {
        public Slider cooldownSlider; // 스킬의 쿨다운을 표시하는 슬라이더
        public GameObject cooldownImageObject; // 쿨타임 동안 표시할 이미지 오브젝트
        public float cooldownTime; // 스킬의 쿨다운 시간
        [HideInInspector] public float currentTime; // 현재 쿨다운 시간이 얼마나 남았는지
        [HideInInspector] public bool isCooldown; // 현재 쿨다운 중인지 여부
        // 쿨다운 업데이트 메서드
        public void UpdateCooldown()
        {
            if (isCooldown) // 만약 쿨다운 중이라면
            {
                currentTime -= Time.deltaTime; // 쿨다운 시간을 감소시킵니다.
                cooldownSlider.value = 1 - (currentTime / cooldownTime); // 슬라이더 값을 업데이트합니다.

                if (currentTime <= 0) // 쿨다운이 끝났다면
                {
                    isCooldown = false; // 쿨다운 상태를 해제합니다.
                    currentTime = 0; // 현재 시간을 0으로 설정합니다.
                    cooldownImageObject.SetActive(false); // 쿨타임 이미지를 비활성화합니다.
                }
            }
        }

        // 쿨다운 시작 메서드
        public void StartCooldown()
        {
            currentTime = cooldownTime; // 현재 시간을 쿨다운 시간으로 설정합니다.
            isCooldown = true; // 쿨다운 상태로 설정합니다.
            cooldownImageObject.SetActive(true); // 쿨타임 이미지를 활성화합니다.
        }
    }

    public Skill skill1; // 첫 번째 스킬에 대한 쿨다운 관리
    public Skill skill2; // 두 번째 스킬에 대한 쿨다운 관리
    public Skill skill3; // 세 번째 스킬에 대한 쿨다운 관리
    public Skill Heal1; // 세 번째 스킬에 대한 쿨다운 관리

    void Update()
    {
        // 각 스킬의 쿨다운을 업데이트합니다.
        skill1.UpdateCooldown();
        skill2.UpdateCooldown();
        skill3.UpdateCooldown();
        Heal1.UpdateCooldown();
    }

    // 스킬 사용 메서드 (예: UI 버튼이나 키보드 입력에 연결)
    public void UseSkill1()
    {
        if (!skill1.isCooldown) // 스킬이 쿨다운 중이 아니라면
        {
            // 스킬 사용 로직 추가 (예: 데미지, 이펙트 등)
            skill1.StartCooldown(); // 스킬의 쿨다운을 시작합니다.
        }
    }
    public void UseSkill2()
    {
        if (!skill2.isCooldown) // 스킬이 쿨다운 중이 아니라면
        {
            // 스킬 사용 로직 추가 (예: 데미지, 이펙트 등)
            skill2.StartCooldown(); // 스킬의 쿨다운을 시작합니다.
        }
    }
    public void UseSkill3()
    {
        if (!skill3.isCooldown) // 스킬이 쿨다운 중이 아니라면
        {
            // 스킬 사용 로직 추가 (예: 데미지, 이펙트 등)
            skill3.StartCooldown(); // 스킬의 쿨다운을 시작합니다.
        }
    }
    public void Heal()
    {
        if (!Heal1.isCooldown) // 스킬이 쿨다운 중이 아니라면
        {
            // 스킬 사용 로직 추가 (예: 데미지, 이펙트 등)
            Heal1.StartCooldown(); // 스킬의 쿨다운을 시작합니다.
        }
    }
}



