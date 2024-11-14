using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNameDisplay : MonoBehaviour
{
    public GameObject player; // 플레이어 GameObject
    private GameObject[] items; // 아이템 GameObject 배열

    void Start()
    {
        // 아이템 GameObject들 가져오기
        items = GameObject.FindGameObjectsWithTag("Item");
    }

    void Update()
    {
        // 모든 아이템에 대해 처리
        foreach (GameObject item in items)
        {
            // 아이템과 플레이어 사이의 거리 계산
            float distance = Vector3.Distance(item.transform.position, player.transform.position);

            // 아이템 이름이 표시되는 거리 설정 (예: 5 유니티 단위)
            if (distance <= 5f)
            {
                // 아이템 오브젝트의 위치를 플레이어 머리 위에 설정
                Vector3 playerNamePos = player.transform.position + new Vector3(0f, 2f, 0f);
                item.transform.position = playerNamePos;
            }
        }
    }
}
