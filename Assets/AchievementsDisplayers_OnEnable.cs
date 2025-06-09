using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(AchievementsDisplayers))]
public class AchievementsDisplayers_OnEnable : MonoBehaviour
{
    private AchievementsDisplayers displayer;
    [SerializeField]
    private TextMeshProUGUI achievementTotal;
    AchievementManager am = AchievementManager.Instance;

    private void Awake()
    {
    }
    private void Update()
    {
        if (am != null)
        {
            if (am.UnlockedCount() == am.Achievements.achievements.Count - 1)
            {
                //AP26
                am.UnlockAchievement(am.Achievements.achievements.Count - 1);
            }
        }
    }
    private void OnEnable()
    {
        displayer = GetComponent<AchievementsDisplayers>();
        displayer.Display(AchievementManager.Instance.Achievements.achievements.ToArray());
        achievementTotal.text = AchievementManager.Instance.GetFormattedAchievementsCount();
    }
}
