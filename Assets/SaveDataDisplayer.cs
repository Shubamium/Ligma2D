using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SaveDataDisplayer : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (SaveSystemNew.SaveFileExists())
        {
            text.text = FormatSaveData(SaveSystemNew.GetSaveData());
        }
    }
    private string FormatSaveData(SaveData toFormat)
    {
        string br = "\n";
        string toReturn = "Time Elapsed: " + Util.FormatFloatToStringTme(toFormat.TimeElapsed) + br;
        toReturn += "Launch Count: " + toFormat.JumpCount + br;
        toReturn += "Progress: " + toFormat.Progress + "%" + br;
        toReturn += "Difficult: " + toFormat.Difficulty + br;
        return toReturn;
    }
 
}
