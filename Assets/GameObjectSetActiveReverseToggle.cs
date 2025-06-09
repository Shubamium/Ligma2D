using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSetActiveReverseToggle : MonoBehaviour
{

    public void SetActiveReverse(bool value)
    {
        gameObject.SetActive(!value);

    }
}
