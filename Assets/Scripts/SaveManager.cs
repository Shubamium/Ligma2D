using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField]
    private List<SaveData> saves;
    [SerializeField]
    private int activeSaveIndex;

    public delegate void publicEvent();
    public delegate void publicEventReturn(SaveData data);


    public static event publicEventReturn OnLoad;
    public static event publicEvent OnSave;


    public static SaveManager instance;

    public SaveData ActiveSave { get => saves[activeSaveIndex]; set => saves[activeSaveIndex] = value; }

    private int loadcode;
    private bool HasSave()
    {
        return saves.Count > 0;
    }

    private void Awake()
    {
        #region Singleton
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        #endregion
        ///Starting Logic-----------------------------------
        loadcode =  PlayerPrefs.GetInt("LoadCode");
       // loadcode = 2;
        if(loadcode != 0)
        {
            Load(loadcode - 1);
        }


    }
    private void Update()
    {
 
    }
    public void GameSave()
    {
        OnSave?.Invoke();
    }

    public void Save()
    {
        if(loadcode == 0)
        {
            SaveNew();
        }
        else
        {
            SaveOverwrite(loadcode-1);
        }
    }
    private void SaveOverwrite(int id)
    {
        saves[id] = saves[loadcode-1];
        OnSave?.Invoke();
    }
    private void SaveNew()
    {
        saves.Add(new SaveData());
        activeSaveIndex = saves.Count-1;
        loadcode = activeSaveIndex;
        OnSave?.Invoke();
    }
    private void Load(int id)
    {
        if (!HasSave() || id == 0) return;
        //ActiveSave = saves[id];
        activeSaveIndex = id;
        OnLoad?.Invoke(ActiveSave);
    }
}

[System.Serializable]
public class SaveData 
{
    [SerializeField]
    private Vector2 playerPos = new Vector2(0,48);
    [SerializeField]
    private Vector2 playerVel;
    [SerializeField]
    private int jumpCount;
    [SerializeField]
    private float timeElapsed;
    [SerializeField]
    private float progress;
    [SerializeField]
    private int diffInt;

    public Vector2 PlayerPos { get => playerPos; set => playerPos = value; }
    public Vector2 PlayerVel { get => playerVel; set => playerVel = value; }
    public int JumpCount { get => jumpCount; set => jumpCount = value; }
    public float TimeElapsed { get => timeElapsed; set => timeElapsed = value; }
    public float Progress { get => progress; set => progress = value; }
    public Difficulty Difficulty { get => (Difficulty)diffInt; set => diffInt = (int)value; }

    /*public void OnAfterDeserialize()
    {
        difficulty = (Difficulty)diffInt;
    }

    public void OnBeforeSerialize()
    {
        diffInt = (int)difficulty;
    }*/
}
