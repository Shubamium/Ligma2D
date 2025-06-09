using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSwitcher : MonoBehaviour
{

    public GameObject target;
    public void Switch()
    {
        target.SetActive(!target.activeInHierarchy);
    }
}
