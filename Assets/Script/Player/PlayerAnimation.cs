using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    public Animator anim;
    private Camera mainCam;

    void Awake()
    {
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
    }
    public void Moving()
    {
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Attack");
        }




    }
}
