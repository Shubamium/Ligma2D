using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Launcher))]
public class Launcher_AreaOnly : MonoBehaviour
{
    private Launcher launcher;
    private bool alwaysOn;

    public bool AlwaysOn { get => alwaysOn; set => alwaysOn = value; }

    private void Awake()
    {
        launcher = GetComponent<Launcher>();
    }

    public void SwitchLauncher(bool state)
    {
        if (AlwaysOn)
        {
            launcher.SwitchState(true);
        }
        else
        {
            launcher.SwitchState(state);
        }
    }
}
