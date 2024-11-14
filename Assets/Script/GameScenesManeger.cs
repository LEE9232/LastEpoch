using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesManeger : MonoBehaviour
{
    public void GameScnensCtrl()
    {
        SceneManager.LoadScene("Village");// 씬 이름 지정
        
    }
    public void BattleField()
    {
        SceneManager.LoadScene("terrain shader");
        
    }
    public void BattleField2()
    {
        SceneManager.LoadScene("Demo1");
       
    }

    public void Choise()
    {
        SceneManager.LoadScene("Choice");
    }







}
