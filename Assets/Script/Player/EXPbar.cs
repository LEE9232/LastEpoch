using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPbar : MonoBehaviour
{
    [SerializeField] private Slider expSlider; // Inspector���� ����

    // ����ġ �� �ʱ�ȭ �޼���
    public void Initialize(int maxExp)
    {
        if (expSlider != null)
        {
            expSlider.maxValue = maxExp; // �ִ� ����ġ ����
            expSlider.value = 0; // ���� ����ġ �ʱ�ȭ
        }
        else
        {
            Debug.LogError("EXP Slider is not assigned.");
        }
    }

    // ����ġ �� ������Ʈ �޼���
    public void UpdateEXP(int currentExp, int maxExp)
    {
        if (expSlider != null)
        {
            expSlider.maxValue = maxExp; // �ִ� ����ġ ������Ʈ
            expSlider.value = currentExp; // ���� ����ġ ������Ʈ
        }
        else
        {
            Debug.LogError("EXP Slider is not assigned.");
        }
    }
}
