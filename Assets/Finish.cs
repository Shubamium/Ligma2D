using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Finish : MonoBehaviour
{
    [Header("Displayer")]
    public GameObject WinUI;
    public GameObject stopper;
    public float winuiDelay;
    public TextMeshPro time;
    public TextMeshPro stats;
    public StarAnimation staranim;
    public GameObject[] otheruis;

    private bool hasWon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasWon) return;
        if(collision.gameObject.tag == "Launcher")
        {
            Debug.Log("Player Won");
            PlayerWon();
        }
    }
    private void PlayerWon()
    {
        hasWon = true;
        SaveSystemNew.Instance.UpdateActiveSaveData();
        stopper.SetActive(true);
        StartCoroutine(DelayWinMenu());
        //Win Code here
        DisableOtherUI();
        SetStats();
    }

    private void SetStats()
    {
        SaveData data = SaveSystemNew.Instance.ActiveSaveData;
        string statsText = "";
        statsText += "Launch Count:" + data.JumpCount;
        time.text = Util.FormatFloatToStringTme(data.TimeElapsed);
        #region SetStar
        int starAmount = 0;
        if(data.TimeElapsed >= 3600)
        {
            starAmount = 0;
        }else if(data.TimeElapsed >= 1800) 
        {
            starAmount = 1;
        }else if (data.TimeElapsed >= 900)
        {
            starAmount = 2;
        }else if(data.TimeElapsed >= 300) {
            starAmount = 3;
        }else if (data.TimeElapsed < 300 && data.JumpCount < 200)
        {
            starAmount = 5;
        }
        else
        {
            starAmount = 4;
        }
        #endregion

        staranim.ShowStar(starAmount);
        stats.text = statsText;

        if (PlayerPrefs.GetInt("C_Active", 0) == 0)
        {
            #region Achievements
            if (PlayerPrefs.HasKey(GlobalStats.WinCount))
            {
                PlayerPrefs.SetInt(GlobalStats.WinCount, PlayerPrefs.GetInt(GlobalStats.WinCount) + 1);
                //AP 5
                int winCount = PlayerPrefs.GetInt(GlobalStats.WinCount);

                if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(4);

                //AP 6
                if (winCount == 5)
                {
                    if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(5);
                }
                //AP 7
                if (winCount == 10)
                {
                    if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(6);
                }
                //AP 8
                if (winCount == 25)
                {
                    if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(7);
                }
                //AP 9
                if (winCount == 50)
                {
                    if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(8);
                }
            }
            else
            {
                PlayerPrefs.SetInt(GlobalStats.WinCount, 1);
            }
            //AP 12
            if (starAmount == 3)
            {
                if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(11);
            }
            //AP 13
            else if (starAmount == 4)
            {
                if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(12);
            }
            //AP 14
            else if (starAmount == 5)
            {
                if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(13);
            }
            //AP 15
            if (starAmount == 5 && (Difficulty)PlayerPrefs.GetInt("diff") == Difficulty.Precision)
            {
                if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(14);
            }
            //AP 16
            if ((Difficulty)PlayerPrefs.GetInt("diff") == Difficulty.Precision)
            {
                if (AchievementManager.Instance != null) AchievementManager.Instance.UnlockAchievement(25);
            }
            #endregion
        }
    }

    private IEnumerator DelayWinMenu()
    {
        yield return new WaitForSeconds(winuiDelay);
        WinUI.SetActive(true);

    }
    private void DisableOtherUI()
    {
      for(int i =0 ; i < otheruis.Length; i++)
        {
            otheruis[i].SetActive(false);
        }
    }
}
