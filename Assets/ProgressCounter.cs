using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressCounter : MonoBehaviour
{
    private float progress;
    public Transform start;
    public Transform end;

    public Transform target;
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
        SaveSystemNew.Instance.ActiveSaveData.Progress = progress;
    }

    private void SaveSystemNew_OnLoad(SaveData data)
    {
        progress = data.Progress;
    }

    private void Update()
    {
        progress = GetProgress();
        if(progress >= 25)
        {
            //AP 2
            if(AchievementManager.Instance != null)AchievementManager.Instance.UnlockAchievement(1);
        } 
        if(progress >= 50)
        {
            //AP 3
            if(AchievementManager.Instance != null)AchievementManager.Instance.UnlockAchievement(2);
        }
        if (progress >= 75)
        {
            //AP 4
            if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(3);
        }
    }

    private float GetProgress()
    {
        float starpoint = start.position.y;
        float endpoint = end.position.y;
        float totalEndPoint = endpoint - starpoint; 
        float currentPoint = target.position.y - starpoint; 
        float toReturn = (currentPoint/totalEndPoint) *100;
        toReturn = Mathf.Round(toReturn * 100f) / 100f;
        if (toReturn > 100) toReturn = 100; 
        return toReturn;
    }
}
