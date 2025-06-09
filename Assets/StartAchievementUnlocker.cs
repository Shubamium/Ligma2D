using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAchievementUnlocker : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("called");
        //AP 1
        AchievementManager am = AchievementManager.Instance;
        if (am != null) {
            AchievementManager.Instance.UnlockAchievement(0);
            //for (int i = 0; i < am.Achievements.achievements.Count - 1; i++)
            //{
            //    am.UnlockAchievement(i);
            //}

        }

    }
}
