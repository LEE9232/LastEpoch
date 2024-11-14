using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Material healthBarMaterial;

    // ü�¹� �ʱ�ȭ �޼���
    public void Initialize(float maxHP)
    {
        UpdateHealth(maxHP, maxHP);
    }

    // ü�¹� ������Ʈ �޼���
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
