using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField]
    private Difficulty difficulty;
    private const float _beginner = 6f;
    private const float _normal = 2.2f;
    private const float _hard = 1.1f;
    private const float _precision = 0.4f;

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
