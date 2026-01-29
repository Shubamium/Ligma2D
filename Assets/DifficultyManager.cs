using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField]
    private Difficulty difficulty;
    private const float _beginner = 10f; // 6
    private const float _normal = 6f; // 2.2
    private const float _hard = 2f; // 1.1
    private const float _precision = 1f; // 0.4

    private void OnEnable()
    {
        SaveSystemNew.OnLoad += SaveSystemNew_OnLoad;
        LoadDiff();
        SetPlayerHitboxSize();
    }
    private void OnDisable()
    {
        SaveSystemNew.OnLoad -= SaveSystemNew_OnLoad;
        
    }
    private void SaveSystemNew_OnLoad(SaveData data)
    {
        SetDifficulty(data.Difficulty);
        LoadDiff();
    }

    private void SetPlayerHitboxSize()
    {
        float scale = 0; ;
        switch (difficulty)
        {
            case Difficulty.Beginner:
                scale = _beginner;
                break;
            case Difficulty.Normal:
                scale = _normal;
                break;
            case Difficulty.Hard:
                scale = _hard;
                break;
            case Difficulty.Precision:
                scale = _precision;
                break;
        }
        gameObject.transform.localScale = new Vector2(scale, scale);
    }

    private void LoadDiff()
    {
        if (PlayerPrefs.HasKey("diff"))
        {
            difficulty = (Difficulty)PlayerPrefs.GetInt("diff");
        }
        else
        {
            difficulty = Difficulty.Normal;
        }
    }

    public static void SetDifficulty(Difficulty diff)
    {
        PlayerPrefs.SetInt("diff", ((int)diff));
    }
}

public enum Difficulty
{
    Beginner,
    Normal,
    Hard,
    Precision
}
