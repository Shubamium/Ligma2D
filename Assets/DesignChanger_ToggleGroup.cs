using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DesignChanger_ToggleGroup : MonoBehaviour
{
    public GameObject[] toggleGroup;
    private void Start()
    {
        SetToggles(PlayerPrefs.GetInt("P_Design"));
    }
    private Toggle GetSelectedToggle()
    {
        List<Toggle> toggleGroupR = GetAllToggles();
        foreach (var t in toggleGroupR)
            if (t.isOn) return t;  //returns selected toggle
        return null;           // if nothing is selected return null
    }

    private List<Toggle> GetAllToggles()
    {
        List<Toggle> toggleGroupR = new List<Toggle>();
        foreach (GameObject t in toggleGroup)
        {
            toggleGroupR.AddRange(t.GetComponentsInChildren<Toggle>());
        }

        return toggleGroupR;
    }

    private void SetToggles(int index)
    {
        Debug.Log("selected" + index);

        Toggle[] toggles = GetAllToggles().ToArray();

        for (int i = 0; i < toggles.Length; i++)
        {
            if (i == index)
            {
                toggles[i].isOn = true;
            }
        }
    }
}
