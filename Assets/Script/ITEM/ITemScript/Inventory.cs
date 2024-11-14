using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> slots = new List<InventorySlot>();

    // 슬롯에 아이템을 추가하는 함수
    public bool AddItem(Items item)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.SetItem(item);
                return true;
            }
        }
        return false; // 인벤토리가 꽉 찬 경우
    }
    public InventorySlot FindEmptySlot()
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.IsEmpty)
            {
                return slot;
            }
        }
        return null; // 비어있는 슬롯이 없는 경우
    }
}
