using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FXManager : MonoBehaviour
{

    public static FXManager instance;

    [SerializeField]
    private AudioClip[] clips;

    private AudioSource audioS;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        audioS = GetComponent<AudioSource>();
    }
    public void PlayFX(int id)
    {
        if (id > clips.Length) return;
        audioS.PlayOneShot(clips[id]);
    }
    public void PlayFXLoop(int id)
    {
        if (id > clips.Length) return;
        if (!audioS.isPlaying)
        {
            audioS.clip = clips[id];
            audioS.Play();
        }
    }
    public void StopLoop()
    {
        audioS.Stop();
    }
}
