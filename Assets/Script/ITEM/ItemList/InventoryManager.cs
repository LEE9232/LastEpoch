using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Transform inventoryParent; // �κ��丮 �θ� ������Ʈ
    public GameObject itemPrefab; // ������ ������

    private List<GameObject> instantiatedItems = new List<GameObject>(); // ������ ������ ������Ʈ���� ����Ʈ

    public void AddItemToInventory(Items item)
    {
        // �������� UI�� �߰�
        GameObject itemGO = Instantiate(itemPrefab, inventoryParent);
        itemGO.GetComponentInChildren<Text>().text = item.itemName; // ������ �̸� ǥ��
        itemGO.GetComponent<Image>().sprite = item.itemImage; // ������ �̹��� ǥ��

        // ��ư Ŭ�� �̺�Ʈ ����
        Button itemButton = itemGO.GetComponent<Button>();
        itemButton.onClick.AddListener(() => { OnItemClick(item); });

        instantiatedItems.Add(itemGO); // ������ �������� ����Ʈ�� �߰�
    }

    private void OnItemClick(Items item)
    {
        AddItemToInventory(item);
        // ������ Ŭ�� �� �κ��丮�� �߰�
        // ���⼭�� ������ ���÷� �������� ��� �߰��մϴ�.
        // ���� ���ӿ����� �ش� �������� �κ��丮�� �߰��ϴ� ������ ���⿡ �����մϴ�.
        Debug.Log("������ : " + item.itemName);
    }

    public void ClearInventory()
    {
        // �κ��丮 �ʱ�ȭ
        foreach (GameObject itemGO in instantiatedItems)
        {
            Destroy(itemGO);
        }
        instantiatedItems.Clear();
    }
}
