using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectActiveOnPrefs : MonoBehaviour
{
    [SerializeField]
    private string prefCode;
    private void OnEnable()
    {
        gameObject.SetActive(PlayerPrefs.GetInt(prefCode,1) == 1 ? true : false);
    }
}
