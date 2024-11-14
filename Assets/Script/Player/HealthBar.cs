using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Material healthBarMaterial;

    // 체력바 초기화 메서드
    public void Initialize(float maxHP)
    {
        UpdateHealth(maxHP, maxHP);
    }

    // 체력바 업데이트 메서드
    public void UpdateHealth(float currentHP, float maxHP)
    {
        if (healthBarMaterial != null)
        {
            healthBarMaterial.SetFloat("_FillLevel", currentHP / maxHP);
        }
        else
        {
            Debug.LogError("Health Bar Material is not assigned.");
        }
    }
}
