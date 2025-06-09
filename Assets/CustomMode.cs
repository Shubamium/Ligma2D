using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class CustomMode : MonoBehaviour
{

    public TMP_InputField launchStrength;
    public TMP_InputField gravity;
    public Toggle launchArea;
    public Toggle CustomsToggle;

    public float defaultLaunchStrength;
    public float MaxLaunchStrength;
    public float defaultGravity;
    public float MaxGravity;
    public bool defaultLaunchArea;
    private void Awake()
    {
        CustomsToggle.isOn = IntToBool(PlayerPrefs.GetInt("C_Active"));
    }
    public void SwitchCustoms(bool value)
    {
        PlayerPrefs.SetInt("C_Active", BoolToInt(value));
        if (value)
        {
            launchStrength.text = PlayerPrefs.GetFloat("C_LaunchS", 1f).ToString();
            gravity.text = PlayerPrefs.GetFloat("C_Gravity", 1f).ToString();
            launchArea.isOn = IntToBool(PlayerPrefs.GetInt("C_Area", 1));
        }
        else
        {
            ResetAll();
        }
    }
    public void SetLaunchForce(string toSet)
    {
        float launchS = defaultLaunchStrength;
        float.TryParse(toSet, out launchS);
        if(launchS > MaxLaunchStrength)
        {
            launchS = MaxLaunchStrength;
            launchStrength.text = MaxLaunchStrength.ToString();
        }
        PlayerPrefs.SetFloat("C_LaunchS", launchS);
    }    
    public void ResetLaunchForce()
    {
        launchStrength.text = defaultLaunchStrength.ToString();
    }
    public void SetGravity(string toSet)
    {
        float launchS = defaultGravity;
        float.TryParse(toSet, out launchS);
        if(launchS < -5 || launchS > MaxGravity)
        {
            launchS = MaxGravity;
            gravity.text = MaxGravity.ToString();
        }
        PlayerPrefs.SetFloat("C_Gravity", launchS);
    }
    public void ResetGravity()
    {
        gravity.text = defaultGravity.ToString();
    }


    public void SetArea(bool area)
    {
        PlayerPrefs.SetInt("C_Area",BoolToInt(area));
    }
    public void ResetArea()
    {
        launchArea.isOn = defaultLaunchArea;
    }
    
    public void ResetAll()
    {
        ResetLaunchForce();
        ResetGravity();
        ResetArea();
        PlayerPrefs.SetFloat("C_LaunchS",defaultLaunchStrength);
        PlayerPrefs.GetFloat("C_Gravity", defaultGravity);
        PlayerPrefs.GetInt("C_Area", BoolToInt(defaultLaunchArea));
    }
    private bool IntToBool(int toBool) => toBool == 1 ? true : false;
    private int BoolToInt(bool toInt) => toInt == true ? 1 : 0;
}
