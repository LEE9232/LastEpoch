using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsChoise : MonoBehaviour
{
    public GameObject Choise1;
    public GameObject Choise2;
    public GameObject Choise3;
    public bool Action = false;
    void Start()
    { 
        Choise1.SetActive(Action);
        Choise2.SetActive(Action);
        Choise3.SetActive(Action);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Action = !Action; // Action 값을 반전시킴
                Choise1.SetActive(Action);
                Choise2.SetActive(Action);
                Choise3.SetActive(Action);
            }
        }
    }
}