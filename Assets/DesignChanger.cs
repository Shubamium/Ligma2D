using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignChanger : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private SpriteCollections col;

    private void OnEnable()
    {
        sr.sprite = col.Sprites[PlayerPrefs.GetInt("P_Design", 0)];
    }
}
