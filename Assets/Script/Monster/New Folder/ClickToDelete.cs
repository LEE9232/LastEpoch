using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDelete : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform

    public float deleteDistance = 3f; // 삭제할 수 있는 최대 거리

    void Update()
    {
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
                    if (distance <= deleteDistance)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
