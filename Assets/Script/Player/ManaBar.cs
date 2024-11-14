using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    public Material manaBarMaterial;

    // ������ �ʱ�ȭ �޼���
    public void Initialize(float maxMP)
    {
        UpdateMana(maxMP, maxMP);
    }

    // ������ ������Ʈ �޼���
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
