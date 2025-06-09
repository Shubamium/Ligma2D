using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DesignChanger_Toggle : MonoBehaviour
{
    [SerializeField]
    private int toChange;

    [SerializeField]
    private Image target;

    [SerializeField]
    private SpriteCollections col;

    private void OnEnable()
    {
        target.sprite = col.Sprites[toChange];
    }
    public void ChangeSprite(bool toggle)
    {
        if (toggle)
        {
            PlayerPrefs.SetInt("P_Design", toChange);
        }
    }
}
