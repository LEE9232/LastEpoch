using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{

    public GameObject invenPlayerObj;  // 인벤 + 플레이어 장비창
    //public GameObject invenItemObj;     // 인벤토리 창
    bool activeInventory = false;


    void Start()
    {
        // 시작시 인벤토리창 두개를 비활성화로 시작하겠다.
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
            // 인벤토리 활성화
            invenPlayerObj.SetActive(activeInventory);
            // invenItemObj.SetActive(activeInventory);
        }
    }


    // x 아이콘 누르면 종료
    public void Escbutton()
    {
        activeInventory = false;
        invenPlayerObj.SetActive(activeInventory);
    }



}
