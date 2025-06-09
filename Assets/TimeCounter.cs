using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    private float time;
    private void OnEnable()
    {
        SaveSystemNew.OnLoad += SaveSystemNew_OnLoad;
        SaveSystemNew.OnSave += SaveSystemNew_OnSave;
    }
     private void OnDisable()
    {
        SaveSystemNew.OnLoad -= SaveSystemNew_OnLoad;
        SaveSystemNew.OnSave -= SaveSystemNew_OnSave;

    }

    private void SaveSystemNew_OnSave()
    {
        SaveSystemNew.Instance.ActiveSaveData.TimeElapsed = time;
    }

    private void SaveSystemNew_OnLoad(SaveData data)
    {
        time = data.TimeElapsed;
    }

    private void Update()
    { 
        time += Time.deltaTime;

        if (PlayerPrefs.HasKey(GlobalStats.TotalPlaytime))
        {
            PlayerPrefs.SetFloat(GlobalStats.TotalPlaytime, PlayerPrefs.GetFloat(GlobalStats.TotalPlaytime) + Time.deltaTime);
            float tTime = PlayerPrefs.GetFloat(GlobalStats.TotalPlaytime);
            if (tTime >= Util.GetSecondsFromHour(1) && tTime < Util.GetSecondsFromHour(2))
            { 
                //AP 16
                if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(15);
            }
            else if (tTime >= Util.GetSecondsFromHour(2) && tTime < Util.GetSecondsFromHour(5))
            {
                //AP 17
                if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(16);
            }
            else if (tTime >= Util.GetSecondsFromHour(5) && tTime < Util.GetSecondsFromHour(10))
            {
                //AP 18
                if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(17);
            }
            else if (tTime >= Util.GetSecondsFromHour(10) && tTime < Util.GetSecondsFromHour(40))
            {
                //AP 19
                if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(18);
            }
            else if (tTime >= Util.GetSecondsFromHour(40))
            {
                //AP 20
                if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(19);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(GlobalStats.TotalPlaytime, Time.deltaTime);

        }
  
        
    }
}
