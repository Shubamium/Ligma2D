using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public virtual void OnEnable()
    {
        SaveManager.OnSave += Save; 
        SaveManager.OnLoad += Load; 
    }
    public virtual void OnDisable()
    {
        SaveManager.OnSave -= Save;
    }
    public virtual void Save()
    {

    }
    public virtual void Load(SaveData data)
    {

    }
}
