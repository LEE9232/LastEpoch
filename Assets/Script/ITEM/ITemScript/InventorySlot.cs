using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    private Items item;

    public bool IsEmpty { get { return item == null; } }

    public void SetItem(Items newItem)
    {
        item = newItem;
        icon.sprite = item.itemImage;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
