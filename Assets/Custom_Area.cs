using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Area : MonoBehaviour
{
    public Launcher_AreaOnly area;

    private void Awake()
    {
       area.AlwaysOn = !IntToBool(PlayerPrefs.GetInt("C_Area", 1));
    }
    private bool IntToBool(int toBool) => toBool == 1 ? true : false;
}
