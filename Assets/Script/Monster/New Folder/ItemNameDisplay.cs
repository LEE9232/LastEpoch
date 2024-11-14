using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNameDisplay : MonoBehaviour
{
    public GameObject player; // �÷��̾� GameObject
    private GameObject[] items; // ������ GameObject �迭

    void Start()
    {
        // ������ GameObject�� ��������
        items = GameObject.FindGameObjectsWithTag("Item");
    }

    void Update()
    {
        // ��� �����ۿ� ���� ó��
        foreach (GameObject item in items)
        {
            // �����۰� �÷��̾� ������ �Ÿ� ���
            float distance = Vector3.Distance(item.transform.position, player.transform.position);

            // ������ �̸��� ǥ�õǴ� �Ÿ� ���� (��: 5 ����Ƽ ����)
            if (distance <= 5f)
            {
                // ������ ������Ʈ�� ��ġ�� �÷��̾� �Ӹ� ���� ����
                Vector3 playerNamePos = player.transform.position + new Vector3(0f, 2f, 0f);
                item.transform.position = playerNamePos;
            }
        }
    }
}
