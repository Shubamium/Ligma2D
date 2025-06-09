using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorChanger_Toggle : MonoBehaviour
{
    [SerializeField]
    private int toChange;

    [SerializeField]
    private Image target;

    [SerializeField]
    private Palette colorList;

    private void OnEnable()
    {
        target.color = colorList.Colors[toChange];
    }
    public void ChangeColor(bool toggle)
    {
        if (toggle)
        {
            PlayerPrefs.SetInt("P_Color", toChange);
        }
    }
}
