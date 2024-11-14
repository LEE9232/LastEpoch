using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPbar : MonoBehaviour
{
    [SerializeField] private Slider BossHPSlider; // Inspector���� ����

    
    public void BossHP(int maxHP)
    {
        if (BossHPSlider != null)
        {
            BossHPSlider.maxValue = maxHP; // �ִ� ����ġ ����
            BossHPSlider.value = 0; // ���� ����ġ �ʱ�ȭ
        }
        else
        {
            Debug.LogError(" ���� HP ���Ҿ���");
        }
    }

    // ����ġ �� ������Ʈ �޼���
    public void UpdateHP(int currentHP, int maxHP)
    {
        if (BossHPSlider != null)
        {
            BossHPSlider.maxValue = maxHP; // �ִ� ����ġ ������Ʈ
            BossHPSlider.value = currentHP; // ���� ����ġ ������Ʈ
        }
        else
        {
            Debug.LogError("HP Slider is not assigned.");
        }
    }
}
