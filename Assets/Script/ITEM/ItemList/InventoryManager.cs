using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Transform inventoryParent; // 인벤토리 부모 오브젝트
    public GameObject itemPrefab; // 아이템 프리팹

    private List<GameObject> instantiatedItems = new List<GameObject>(); // 생성된 아이템 오브젝트들의 리스트

    public void AddItemToInventory(Items item)
    {
        // 아이템을 UI에 추가
        GameObject itemGO = Instantiate(itemPrefab, inventoryParent);
        itemGO.GetComponentInChildren<Text>().text = item.itemName; // 아이템 이름 표시
        itemGO.GetComponent<Image>().sprite = item.itemImage; // 아이템 이미지 표시

        // 버튼 클릭 이벤트 설정
        Button itemButton = itemGO.GetComponent<Button>();
        itemButton.onClick.AddListener(() => { OnItemClick(item); });

        instantiatedItems.Add(itemGO); // 생성된 아이템을 리스트에 추가
    }

    private void OnItemClick(Items item)
    {
        AddItemToInventory(item);
        // 아이템 클릭 시 인벤토리에 추가
        // 여기서는 간단히 예시로 아이템을 즉시 추가합니다.
        // 실제 게임에서는 해당 아이템을 인벤토리에 추가하는 로직을 여기에 구현합니다.
        Debug.Log("아이템 : " + item.itemName);
    }

    public void ClearInventory()
    {
        // 인벤토리 초기화
        foreach (GameObject itemGO in instantiatedItems)
        {
            Destroy(itemGO);
        }
        instantiatedItems.Clear();
    }
}
