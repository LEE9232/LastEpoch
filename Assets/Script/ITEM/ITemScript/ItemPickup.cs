using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemPickup : MonoBehaviour
{
    private Items item; // ������ ����
    private Transform player; // �÷��̾��� Transform
    public float pickupDistance = 3f; // Ŭ�� ������ �ִ� �Ÿ�
    private Inventory inventory; // �κ��丮 ����

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }
    void Update()
    {
        OnItemClick();
        
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
                    if (distance <= pickupDistance)
                    {
                        //Destroy(gameObject);
                        // �κ��丮�� �������� �߰�
                        if (inventory.AddItem(item))
                        {
                            // �κ��丮�� ���������� �߰��Ǹ� ������ ������Ʈ�� ����
                            Destroy(gameObject);
                        }
                        else
                        {
                            // �κ��丮�� �� �� ��쿡 ���� ó��
                            Debug.Log("Inventory is full!");
                        }
                    }
                }
            }
        }
    }


    // ������ ���� �Լ�
    public void SetItem(Items newItem)
    {
        item = newItem;
        // ������ �̸��� �ؽ�Ʈ�� ǥ��
        GetComponentInChildren<Text>().text = item.itemName;
    }

    // ������ Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnItemClick()
    {
        // �÷��̾���� �Ÿ��� ���
        float distance = Vector3.Distance(transform.position, player.position);

        // �÷��̾���� �Ÿ��� ���� �Ÿ� �ȿ� �ִ��� Ȯ���ϰ� ����
        if (distance <= pickupDistance)
        {
             Destroy(gameObject);
            // �κ��丮�� �������� �߰�
            if (inventory.AddItem(item))
            {
                // �κ��丮�� ���������� �߰��Ǹ� ������ ������Ʈ�� ����
                Destroy(gameObject);
            }
            else
            {
                // �κ��丮�� �� �� ��쿡 ���� ó��
                Debug.Log("Inventory is full!");
            }
        }
    }
}
