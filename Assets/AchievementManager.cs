using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class AchievementManager : MonoBehaviour
{
    private static AchievementManager instance;

    public static AchievementManager Instance { get => instance; set => instance = value; }
    public Achievements Achievements { get => achievements; set => achievements = value; }

    public List<Sprite> icons;

    // [SerializeField]
    //private List<Achievement> achievements;
    public delegate void evenRet(int achievementId);
    public static event evenRet OnAchievementUnlocked;

    [SerializeField]
    private Achievements achievements;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            //first time only
            if (!SaveFileExist())
            {
                Save();
                SetIcon();
            }
            else
            {
                Load();
            }
        }
        else
        {
            Destroy(gameObject);
        }
        

    }

    private void SetIcon()
    {
        for(int i = 0;i < icons.Capacity; i++)
        {
            achievements.achievements[i].Icon = icons[i];
        }
    }
    private void Load()
    {
        string json = File.ReadAllText(GetSavePath());
        Achievements = JsonUtility.FromJson<Achievements>(json);
        SetIcon();
    }

    private bool SaveFileExist()
    {
        return File.Exists(GetSavePath());
    }
    public static string GetSavePath()
    {
        return Application.persistentDataPath + "/Achievement.json";
    }

    public int UnlockedCount()
    {
        int toret = 0;
        for(int i = 0; i < achievements.achievements.Count; i++)
        {
            if (achievements.achievements[i].IsUnlocked) toret++;
        }
        return toret;
    }
    public string GetFormattedAchievementsCount()
    {
        string toret = UnlockedCount() +"/"+ achievements.achievements.Count;
        return toret;
    }
    /// <summary>
    /// Unlock an Achievements by the id in the list
    /// </summary>
    /// <param name="achievementsID">The id of the achievements to unlock</param>
    public void UnlockAchievement(int achievementsID)
    {
        if (Achievements.achievements[achievementsID].IsUnlocked == true) return;
        Achievements.achievements[achievementsID].IsUnlocked = true;
        Save();
        OnAchievementUnlocked?.Invoke(achievementsID);
    }

    /// <summary>
    /// Check if a certain achievements has been unlocked
    /// </summary>
    /// <param name="achievementsID">the id of the achievements to check</param>
    /// <returns></returns>
    public bool IsAchievementUnlocked(int achievementsID)
    {
        return Achievements.achievements[achievementsID].IsUnlocked;
    }
    private static void SaveAchievements(Achievements toSave)
    {
        string data = JsonUtility.ToJson(toSave);
        Debug.Log(data);
        File.WriteAllText(GetSavePath(), data);
    }
    private void Save()
    {
        if (!SaveFileExist())
        {
            File.CreateText(GetSavePath()).Dispose();
        }
        SaveAchievements(Achievements);
    }
}

[Serializable]
public class Achievement
{

    [SerializeField]
    string name;
    public Sprite icon;
    [SerializeField]
    string description;
    [SerializeField]
    bool isUnlocked;
    //string displayerData ----> add a function to set it 
       public bool IsUnlocked { get => isUnlocked; set => isUnlocked = value; }
    public string Name { get => name; set => name = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public string Description { get => description; set => description = value; }
}

[Serializable]
public class Achievements
{
    public List<Achievement> achievements;
}
