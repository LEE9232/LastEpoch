using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDelete : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform

    public float deleteDistance = 3f; // ������ �� �ִ� �ִ� �Ÿ�

    void Update()
    {
        // ���콺 ���� ��ư�� Ŭ���Ǿ����� Ȯ��
        if (Input.GetMouseButtonUp(0))
        {
            // ���콺 ��ġ���� ���̸� ���� Ŭ���� ������Ʈ Ȯ��
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Ŭ���� ������Ʈ�� �ڽ��� ���, �÷��̾���� �Ÿ��� ���
                if (hit.collider.gameObject == gameObject)
                {
                    float distance = Vector3.Distance(transform.position, player.position);

                    // �÷��̾���� �Ÿ��� ���� �Ÿ� �ȿ� �ִ��� Ȯ���ϰ� ����
                    if (distance <= deleteDistance)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
