using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{

    public GameObject invenPlayerObj;  // �κ� + �÷��̾� ���â
    //public GameObject invenItemObj;     // �κ��丮 â
    bool activeInventory = false;


    void Start()
    {
        // ���۽� �κ��丮â �ΰ��� ��Ȱ��ȭ�� �����ϰڴ�.
        invenPlayerObj.SetActive(activeInventory);
        //invenItemObj.SetActive(activeInventory);
    }

    
    void Update()
    {
        InvecToryWindow();
    }

    public void InvecToryWindow()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            // �κ��丮 Ȱ��ȭ
            invenPlayerObj.SetActive(activeInventory);
            // invenItemObj.SetActive(activeInventory);
        }
    }


    // x ������ ������ ����
    public void Escbutton()
    {
        activeInventory = false;
        invenPlayerObj.SetActive(activeInventory);
    }



}
