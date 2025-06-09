using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonObject : MonoBehaviour
{
    private static GameObject gob;

    private void Awake()
    {
        if(gob == null)
        {
            gob = gameObject;
            DontDestroyOnLoad(gob);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
