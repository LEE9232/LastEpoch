using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemDrop : MonoBehaviour
{

    
    public List<Items> itemList; // ������ ����Ʈ
    public GameObject itemPrefab; // ������ ������
    public List<GameObject> itemPrefabs; // ������ ������ ����Ʈ
    //public string itemTag = "Item"; // �������� �ĺ��ϱ� ���� �±�
  



    private void Start()
    {
        // ������ ����Ʈ �ʱ�ȭ
        itemList = new List<Items>();

        // ������ ���� �߰�
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
        // �������� ������ ����
        int prefabIndex = Random.Range(0, itemPrefabs.Count);
        GameObject selectedPrefab = itemPrefabs[prefabIndex];
        GameObject itemGO = Instantiate(selectedPrefab, dropPosition, Quaternion.identity);
        // ItemPickup ������Ʈ ��������
        ItemPickup itemPickup = itemGO.GetComponent<ItemPickup>();
        // Ŭ�� �̺�Ʈ ������ ����
        itemGO.GetComponent<Button>().onClick.AddListener(() => itemPickup.OnItemClick());
    }
}

     