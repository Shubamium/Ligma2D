using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementUnlockAnimationManager : MonoBehaviour
{

    [SerializeField]
    private GameObject achievementDisplayerPrefab;
    private Queue<int> toAnimate = new Queue<int>();

    [SerializeField]
    private float displayDelay;
    private float _internalTimer;
    private void OnEnable()
    {
        AchievementManager.OnAchievementUnlocked += AchievementManager_OnAchievementUnlocked;
    }
    private void OnDisable()
    {
        AchievementManager.OnAchievementUnlocked -= AchievementManager_OnAchievementUnlocked;
    }

    private void Start()
    {
        _internalTimer = displayDelay;
    }
    private void Update()
    {
        if (_internalTimer >= 0) _internalTimer -= Time.deltaTime;
        //if there's something inside the queue
        if(toAnimate.Count > 0 && _internalTimer < 0)
        {
            Animate(toAnimate.Dequeue());
            _internalTimer = displayDelay;
        }
    }
    private void AchievementManager_OnAchievementUnlocked(int achievementId)
    {
        Debug.Log("display");
        toAnimate.Enqueue(achievementId);

    }

    private void Animate(int achievementId)
    {
        GameObject instan = Instantiate(achievementDisplayerPrefab, transform);
        AchievementsDisplayer displayer = instan.GetComponent<AchievementsDisplayer>();
        displayer.Display(AchievementManager.Instance.Achievements.achievements[achievementId]);
    }
}
