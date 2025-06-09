using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager_SetDifficulty : MonoBehaviour
{
    public Difficulty diff;
    public void SetDifficulty()
    {
        DifficultyManager.SetDifficulty(diff);
    }
}
