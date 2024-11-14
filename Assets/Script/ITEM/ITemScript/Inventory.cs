using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> slots = new List<InventorySlot>();

    // ���Կ� �������� �߰��ϴ� �Լ�
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
        return false; // �κ��丮�� �� �� ���
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
        return null; // ����ִ� ������ ���� ���
    }
}
