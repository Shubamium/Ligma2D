using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static void RemoveAllChildOfGameObject(GameObject parent)
    {
        GameObject[] obj = new GameObject[parent.transform.childCount];

        for (int i = 0; i < obj.Length; i++)
        {
            obj[i] = parent.transform.GetChild(i).gameObject;
        }
        parent.transform.DetachChildren();
        for (int i = 0; i < obj.Length; i++)
        {
            GameObject.Destroy(obj[i]);
        }
    }
    public static string FormatFloatToStringTme(float time, bool includeHours = true)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float hours = Mathf.FloorToInt(minutes / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        //minutes = includeHours ? Mathf.FloorToInt(time / 60) % 60 : Mathf.FloorToInt(time / 60);

        string format =  
            string.Concat(hours != 0 
            ? hours + "h " 
            : "") 

            + string.Concat(minutes != 0 
            ? (includeHours ? minutes % 60 : minutes ) + "m " 
            : "", seconds + "s");

        return format;
    }
    public static float GetSecondsFromHour(float hours)
    {
        return hours * 3600;
    }
}
