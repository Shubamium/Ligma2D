using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleGroupAdder : MonoBehaviour
{
    [SerializeField]
    private ToggleGroup groupToAdd;

    private void OnEnable()
    {
        foreach(Toggle t in GetComponentsInChildren<Toggle>())
        {
            groupToAdd.RegisterToggle(t);
        }
    }

}
