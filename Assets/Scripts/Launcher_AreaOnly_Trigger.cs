using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher_AreaOnly_Trigger : MonoBehaviour
{
    private Launcher_AreaOnly controller;
    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("Launcher").GetComponent<Launcher_AreaOnly>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("Player Enabled");
        if(collision.gameObject.tag == "Launcher")
        {
            controller.SwitchLauncher(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Player Disabled");
        if (collision.gameObject.tag == "Launcher")
        {
            controller.SwitchLauncher(false);
        }

    }
}
