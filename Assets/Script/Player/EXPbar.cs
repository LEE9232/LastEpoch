using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPbar : MonoBehaviour
{
    [SerializeField] private Slider expSlider; // Inspector에서 설정

    // 경험치 바 초기화 메서드
    public void Initialize(int maxExp)
    {
        if (expSlider != null)
        {
            expSlider.maxValue = maxExp; // 최대 경험치 설정
            expSlider.value = 0; // 현재 경험치 초기화
        }
        else
        {
            Debug.LogError("EXP Slider is not assigned.");
        }
    }

    // 경험치 바 업데이트 메서드
    public void UpdateEXP(int currentExp, int maxExp)
    {
        if (expSlider != null)
        {
            expSlider.maxValue = maxExp; // 최대 경험치 업데이트
            expSlider.value = currentExp; // 현재 경험치 업데이트
        }
        else
        {
            Debug.LogError("EXP Slider is not assigned.");
        }
    }
}
