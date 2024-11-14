using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemPickup : MonoBehaviour
{
    private Items item; // 아이템 정보
    private Transform player; // 플레이어의 Transform
    public float pickupDistance = 3f; // 클릭 가능한 최대 거리
    private Inventory inventory; // 인벤토리 참조

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }
    void Update()
    {
        OnItemClick();
        
        // 마우스 왼쪽 버튼이 클릭되었는지 확인
        if (Input.GetMouseButtonUp(0))
        {
            // 마우스 위치에서 레이를 쏴서 클릭된 오브젝트 확인
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // 클릭된 오브젝트가 자신인 경우, 플레이어와의 거리를 계산
                if (hit.collider.gameObject == gameObject)
                {
                    float distance = Vector3.Distance(transform.position, player.position);

                    // 플레이어와의 거리가 일정 거리 안에 있는지 확인하고 삭제
                    if (distance <= pickupDistance)
                    {
                        //Destroy(gameObject);
                        // 인벤토리에 아이템을 추가
                        if (inventory.AddItem(item))
                        {
                            // 인벤토리에 성공적으로 추가되면 아이템 오브젝트를 삭제
                            Destroy(gameObject);
                        }
                        else
                        {
                            // 인벤토리가 꽉 찬 경우에 대한 처리
                            Debug.Log("Inventory is full!");
                        }
                    }
                }
            }
        }
    }


    // 아이템 설정 함수
    public void SetItem(Items newItem)
    {
        item = newItem;
        // 아이템 이름을 텍스트로 표시
        GetComponentInChildren<Text>().text = item.itemName;
    }

    // 아이템 클릭 시 호출되는 함수
    public void OnItemClick()
    {
        // 플레이어와의 거리를 계산
        float distance = Vector3.Distance(transform.position, player.position);

        // 플레이어와의 거리가 일정 거리 안에 있는지 확인하고 삭제
        if (distance <= pickupDistance)
        {
             Destroy(gameObject);
            // 인벤토리에 아이템을 추가
            if (inventory.AddItem(item))
            {
                // 인벤토리에 성공적으로 추가되면 아이템 오브젝트를 삭제
                Destroy(gameObject);
            }
            else
            {
                // 인벤토리가 꽉 찬 경우에 대한 처리
                Debug.Log("Inventory is full!");
            }
        }
    }
}
