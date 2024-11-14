using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    public Material manaBarMaterial;

    // 마나바 초기화 메서드
    public void Initialize(float maxMP)
    {
        UpdateMana(maxMP, maxMP);
    }

    // 마나바 업데이트 메서드
    public void UpdateMana(float currentMP, float maxMP)
    {
        if (manaBarMaterial != null)
        {
            manaBarMaterial.SetFloat("_FillLevel", currentMP / maxMP);
        }
        else
        {
            Debug.LogError("Mana Bar Material is not assigned.");
        }
    }
}
