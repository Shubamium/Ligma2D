using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Launcher_JumpCounterDisplayer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI counter;
    [SerializeField]
    public Launcher launcher;
    private void Update()
    {
        counter.text = launcher.LaunchCount.ToString();
        #region Achievement
        int tLaunchCount = PlayerPrefs.GetInt(GlobalStats.LaunchCount);
        //AP 21
        if (tLaunchCount == 1000)
        { 
            if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(20);
        }
        //AP 22
        else if (tLaunchCount == 2000)
        {
            if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(21);
        }//AP 23
        else if (tLaunchCount == 5000)
        {
            if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(22);
        }
        //AP 24
        else if (tLaunchCount == 10000)
        {
            if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(23);
        } //AP 25
        else if (tLaunchCount == 10000)
        {
            if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(24);
        }
        #endregion
    }
}
