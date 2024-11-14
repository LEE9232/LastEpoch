using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ����
public class Items
{
    public string itemName; // ������ �̸�
    public Sprite itemImage; // ������ �̹���
    public int itemID; // ������ ��ȣ
    public string description; // ������ ����

    public Items(string name, Sprite image, int id, string desc)
    {
        itemName = name;
        itemImage = image;
        itemID = id;
        description = desc;
    }
}
