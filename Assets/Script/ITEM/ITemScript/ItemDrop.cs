using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemDrop : MonoBehaviour
{

    
    public List<Items> itemList; // 아이템 리스트
    public GameObject itemPrefab; // 아이템 프리팹
    public List<GameObject> itemPrefabs; // 아이템 프리팹 리스트
    //public string itemTag = "Item"; // 아이템을 식별하기 위한 태그
  



    private void Start()
    {
        // 아이템 리스트 초기화
        itemList = new List<Items>();

        // 아이템 종류 추가
        itemList.Add(new Items("Item1", null, 1, "Description 1"));
        itemList.Add(new Items("Item2", null, 2, "Description 2"));
        itemList.Add(new Items("Item3", null, 3, "Description 3"));
        itemList.Add(new Items("Item4", null, 4, "Description 4"));
        itemList.Add(new Items("Item5", null, 5, "Description 5"));
        itemList.Add(new Items("Item6", null, 6, "Description 6"));
        itemList.Add(new Items("Item7", null, 7, "Description 7"));
        itemList.Add(new Items("Item8", null, 8, "Description 8"));
        itemList.Add(new Items("Item9", null, 9, "Description 9"));
    }
   
    public void DropItem(Vector3 dropPosition)
    {
        // 랜덤으로 프리팹 선택
        int prefabIndex = Random.Range(0, itemPrefabs.Count);
        GameObject selectedPrefab = itemPrefabs[prefabIndex];
        GameObject itemGO = Instantiate(selectedPrefab, dropPosition, Quaternion.identity);
        // ItemPickup 컴포넌트 가져오기
        ItemPickup itemPickup = itemGO.GetComponent<ItemPickup>();
        // 클릭 이벤트 리스너 설정
        itemGO.GetComponent<Button>().onClick.AddListener(() => itemPickup.OnItemClick());
    }
}

     