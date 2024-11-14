using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 정의
public class Items
{
    public string itemName; // 아이템 이름
    public Sprite itemImage; // 아이템 이미지
    public int itemID; // 아이템 번호
    public string description; // 아이템 설명

    public Items(string name, Sprite image, int id, string desc)
    {
        itemName = name;
        itemImage = image;
        itemID = id;
        description = desc;
    }
}
