using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisableSaveData : MonoBehaviour
{
    public Button button;
    private void Start()
    {
        button.interactable = SaveSystemNew.SaveFileExists();
    }
}
