using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFallCounter : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerPrefs.GetInt("C_Active", 0) == 1) return;
            // Debug.Log("Player Enabled");
        if (collision.gameObject.tag == "Launcher")
        {
            if (PlayerPrefs.HasKey(GlobalStats.FallCount))
            {
                PlayerPrefs.SetInt(GlobalStats.FallCount, PlayerPrefs.GetInt(GlobalStats.FallCount) + 1);
                //AP 10
                int fallCount = PlayerPrefs.GetInt(GlobalStats.FallCount);
                if (fallCount == 1)
                {
                    if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(9);
                }
                //AP 11
                if (fallCount == 10)
                {
                    if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(10);
                }
            }
            else
            {
                PlayerPrefs.SetInt(GlobalStats.FallCount, 1);
            }
        }
    }
}

   
