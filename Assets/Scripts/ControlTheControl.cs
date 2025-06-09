using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTheControl : MonoBehaviour
{
    [SerializeField]
    private Launcher toControl;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("called");
            SwitchControl(false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("called");
            SwitchControl(true);
        }
    }

    private void SwitchControl(bool state)
    {
        toControl.SwitchState(state);
    }
}
