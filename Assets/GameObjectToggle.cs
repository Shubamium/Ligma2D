using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectToggle : MonoBehaviour
{
    public void ToggleActive(bool toggle)
    {
        gameObject.SetActive(toggle);
    }
}
