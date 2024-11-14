using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPbar : MonoBehaviour
{
    [SerializeField] private Slider BossHPSlider; // Inspector에서 설정

    
    public void BossHP(int maxHP)
    {
        if (BossHPSlider != null)
        {
            BossHPSlider.maxValue = maxHP; // 최대 경험치 설정
            BossHPSlider.value = 0; // 현재 경험치 초기화
        }
        else
        {
            Debug.LogError(" 보스 HP 감소안함");
        }
    }

    // 경험치 바 업데이트 메서드
    public void UpdateHP(int currentHP, int maxHP)
    {
        if (BossHPSlider != null)
        {
            BossHPSlider.maxValue = maxHP; // 최대 경험치 업데이트
            BossHPSlider.value = currentHP; // 현재 경험치 업데이트
        }
        else
        {
            Debug.LogError("HP Slider is not assigned.");
        }
    }
}
