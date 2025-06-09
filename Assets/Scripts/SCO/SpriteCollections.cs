using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sprite Col", menuName = "SCO/Sprite Col", order = 1)]
public class SpriteCollections : ScriptableObject
{
    [SerializeField]
    private Sprite[] sprites;

    public Sprite[] Sprites { get => sprites; set => sprites = value; }
}
