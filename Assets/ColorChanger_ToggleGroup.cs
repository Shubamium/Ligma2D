using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorChanger_ToggleGroup : MonoBehaviour
{

    private void Start()
    {
        SetToggles(PlayerPrefs.GetInt("P_Color"));
    }
    private Toggle GetSelectedToggle()
    {
        Toggle[] toggles = GetComponentsInChildren<Toggle>();
        foreach (var t in toggles)
            if (t.isOn) return t;  //returns selected toggle
        return null;           // if nothing is selected return null
    }
    private void SetToggles(int index)
    {
        Toggle[] toggles = GetComponentsInChildren<Toggle>();

        for(int i = 0;i<toggles.Length; i++)
        {
            if(i == index)
            {
                toggles[i].isOn = true;
            }
        }
    }
}
