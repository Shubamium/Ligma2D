using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private Palette colorList;

    private void OnEnable()
    {
        sr.color = colorList.Colors[PlayerPrefs.GetInt("P_Color", 0)];
    }
}
