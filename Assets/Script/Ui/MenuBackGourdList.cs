using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBackGourdList : MonoBehaviour
{

    public void VILL()
    {
      
        SceneManager.LoadScene("Village");
     
    }

    public void BOSSMAP()
    {
     

        SceneManager.LoadScene("terrain shader");


    }
    public void STAGE()
    {
      
        SceneManager.LoadScene("Demo1");
    }


}
