using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Palette",menuName = "SCO/Palette",  order = 1)]
public class Palette : ScriptableObject
{
    [SerializeField]
    private Color[] colors;

    public Color[] Colors { get => colors; set => colors = value; }
}
