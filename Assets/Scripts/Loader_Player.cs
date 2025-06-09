using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader_Player : Loader
{
    public override void OnEnable()
    {
        base.OnEnable();
    }
    public override void OnDisable()
    {
        base.OnDisable();
    }
    public override void Load(SaveData data)
    {

    }

    public override void Save()
    {
        SaveManager.instance.ActiveSave.PlayerPos = transform.position;
        SaveManager.instance.ActiveSave.PlayerVel = GetComponent<Rigidbody2D>().velocity;
    }
}
