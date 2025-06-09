using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveSystemNew : MonoBehaviour 
{
    [SerializeField]
    private SaveData activeSaveData;

    private static SaveSystemNew instance;

    public SaveData ActiveSaveData { get => activeSaveData; set => activeSaveData = value; }
    public static SaveSystemNew Instance { get => instance; set => instance = value; }

    public static string GetSavePath()
    {
        return Application.persistentDataPath + "/Data.json";
    }

    public delegate void loadelegate(SaveData data);
    public delegate void saves();

    public static event loadelegate OnLoad;
    public static event saves OnSave;

    public LevelLoader loader;
    private void Awake()
    {
        #region Singleton
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        #endregion



    }

   
    private void Start()
    {
        int loadcode = PlayerPrefs.GetInt("LoadCode");
        // loadcode = 2;
        if (loadcode != 0)
        {
            Load();
        }
        else
        {
            SaveData();
            SaveSystemNew.Instance.activeSaveData.Difficulty = (Difficulty)PlayerPrefs.GetInt("diff");
        }

    }
    private void Update()
    {
      /*  if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Load();
        }*/
    }

    public void SaveData()
    {
        if (PlayerPrefs.GetInt("C_Active", 0) == 1) return;
        StartCoroutine(Save());
    }

    private IEnumerator Save()
    {
        OnSave?.Invoke();
        yield return 0;

       
        string save = JsonUtility.ToJson(ActiveSaveData);
       
        File.WriteAllText(GetSavePath(), save);
        Debug.Log("Save");
        Debug.Log(save);
    }

    public void SaveDataBack()
    {
        StartCoroutine(SaveBack());
    }

    private IEnumerator SaveBack()
    {
        if (PlayerPrefs.GetInt("C_Active", 0) == 0)
        {
            OnSave?.Invoke();
            yield return 0;


            string save = JsonUtility.ToJson(ActiveSaveData);

            File.WriteAllText(GetSavePath(), save);
            Debug.Log("Save");
            Debug.Log(save);
        }
        loader.LoadScene(0);

    }
    /// <summary>
    /// Updating the active save data without actually saving it
    /// </summary>
    public void UpdateActiveSaveData()
    {
        OnSave?.Invoke();
    }
    private void Load()
    {
        if (!SaveFileExists())
        {
            return;
        }
        Debug.Log("load");
        ActiveSaveData = GetSaveData();
        OnLoad?.Invoke(activeSaveData);
    }

    public static SaveData GetSaveData()
    {
        return JsonUtility.FromJson<SaveData>(File.ReadAllText(GetSavePath()));
    }

    public static bool SaveFileExists()
    {
        return File.Exists(GetSavePath());
    }
    public static void ClearData()
    {
        SaveData data = new SaveData();
        string save = JsonUtility.ToJson(data);

        File.WriteAllText(GetSavePath(), save);
    }

 
}
