using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsDisplayers : MonoBehaviour
{
    [SerializeField]
    private GameObject achievementDisplayerPrefab;
    [SerializeField]
    private Transform displayUnder;

    private AchievementsDisplayer[] displayers;
    public void Display(Achievement[] toDisplay)
    {
        RemoveAllPreviousDisplay();
        InstantiateAllDisplayers(toDisplay);
        DisplayAll(toDisplay);
    }
   
    private void DisplayAll(Achievement[] toDisplay)
    {
        for(int i = 0; i < toDisplay.Length; i++)
        {
            displayers[i].Display(toDisplay[i]);
        }
    }

    private void InstantiateAllDisplayers(Achievement[] toDisplay)
    {
        displayers = new AchievementsDisplayer[toDisplay.Length];
        for (int i = 0; i < toDisplay.Length; i++)
        {
            displayers[i] = Instantiate(achievementDisplayerPrefab, displayUnder).GetComponent<AchievementsDisplayer>();
        }
    }

    private void RemoveAllPreviousDisplay()
    {
        Util.RemoveAllChildOfGameObject(displayUnder.gameObject);
    }
}
