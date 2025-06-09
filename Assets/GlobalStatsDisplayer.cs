using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GlobalStatsDisplayer : MonoBehaviour
{
    [SerializeField]
    private bool displayOnEnable;
    [Header("Reference"),SerializeField]
    private TextMeshProUGUI textRef;

    private const string lineBreak = "\n";
    private void OnEnable()
    {
        if (displayOnEnable)
        {
            Display();
        }
    }
    public void Display()
    {
        string toDisplay = "";

        //---------------------------------------------------------------------------------
        toDisplay += "Total Playtime: " + (PlayerPrefs.HasKey(GlobalStats.TotalPlaytime)
            ? Util.FormatFloatToStringTme(PlayerPrefs.GetFloat(GlobalStats.TotalPlaytime))
            : "0") 
            + lineBreak;
        //---------------------------------------------------------------------------------
        toDisplay += "Launch Count: " + (PlayerPrefs.HasKey(GlobalStats.LaunchCount)
            ? PlayerPrefs.GetInt(GlobalStats.LaunchCount).ToString()
            : "0")
            + lineBreak;
        //---------------------------------------------------------------------------------
        toDisplay += "Win Count: " + (PlayerPrefs.HasKey(GlobalStats.WinCount)
            ? PlayerPrefs.GetInt(GlobalStats.WinCount).ToString()
            : "0")
            + lineBreak;
        //---------------------------------------------------------------------------------
        toDisplay += "Fall Count: " + (PlayerPrefs.HasKey(GlobalStats.FallCount)
            ? PlayerPrefs.GetInt(GlobalStats.FallCount).ToString()
            : "0")
            + lineBreak;
        //---------------------------------------------------------------------------------
        textRef.text = toDisplay;
     }
}
