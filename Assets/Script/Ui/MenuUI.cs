using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MenuUI : MonoBehaviour
{
    public GameObject MenuBackGround;

    bool activeMenuList = false;

    void Start()
    {
        // �޴�â ��Ȱ������
        MenuBackGround.SetActive(activeMenuList);
    }

    public void MenuButton()
    {
        activeMenuList = !activeMenuList;
        MenuBackGround.SetActive(activeMenuList);
    }
    

}
