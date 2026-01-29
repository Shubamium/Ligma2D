using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class SettingsMenu : MonoBehaviour
{

    [SerializeField]
    private AudioMixer masterMixer;
    [SerializeField]
    private Slider musicSlider, effectsSlider;

    [SerializeField]
    private Toggle postProcessingToggle,particlesToggle,cameraTransitionToggle;
    private void OnEnable()
    {
        SetSettings();
    }
    private void SetSettings()
    {
        //Audio
        float Mvol;
        float Evol;
        masterMixer.GetFloat("MusicVol", out Mvol);
        masterMixer.GetFloat("EffectVol", out Evol);

        musicSlider.value = Mathf.Pow(10,Mvol / 20);
        effectsSlider.value = Mathf.Pow(10,Evol / 20);

        //Graphics
        postProcessingToggle.isOn = PlayerPrefs.GetInt("PostProcessing", 1) == 1 ? true : false;
        particlesToggle.isOn = PlayerPrefs.GetInt("Particles", 1) == 1 ? true : false;
        cameraTransitionToggle.isOn = PlayerPrefs.GetFloat("CAMERA_SPEED", 0.4f) == 0.4f ? true : false;
    }
    public void SetMusicVolume(float volume)
    {
        masterMixer.SetFloat("MusicVol", Mathf.Log10(volume)*20);
    }
    public void SetEffectVolume(float volume)
    {
        masterMixer.SetFloat("EffectVol", Mathf.Log10(volume)*20);
    }
    public void SetCameraTransition(bool active)
    {
       PlayerPrefs.SetFloat("CAMERA_SPEED", active ? 0.4f : 0);
    }


    public void SetPostProcessing(bool var)
    {
        PlayerPrefs.SetInt("PostProcessing", var ? 1 : 0);
    }
    public void SetParticles(bool var)
    {
        PlayerPrefs.SetInt("Particles", var ? 1 : 0);
    }
}
