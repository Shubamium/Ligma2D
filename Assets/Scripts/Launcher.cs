using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 tempVelo;

    [SerializeField] 
    private bool isActive;
    [SerializeField] private float maxLaunchForce;
    private int launchCount;

    public int LaunchCount { get => launchCount; set => launchCount = value; }
    
    public bool IsActive { get => isActive; set => isActive = value; }


    #region SaveSystem

    private void OnEnable()
    {
        SaveSystemNew.OnLoad += SaveSystemNew_OnLoad;
        SaveSystemNew.OnSave += SaveSystemNew_OnSave;
    }

    private void SaveSystemNew_OnSave()
    {
        SaveSystemNew.Instance.ActiveSaveData.JumpCount = launchCount;
        SaveSystemNew.Instance.ActiveSaveData.PlayerPos = transform.position;
        SaveSystemNew.Instance.ActiveSaveData.PlayerVel = rb.velocity;
    }

    private void SaveSystemNew_OnLoad(SaveData data)
    {
        Debug.Log("Loaded");
        launchCount = data.JumpCount;
        transform.position = data.PlayerPos;
        rb.velocity = data.PlayerVel;
        DifficultyManager.SetDifficulty(data.Difficulty);
    }

    private void OnDisable()
    {
        SaveSystemNew.OnLoad -= SaveSystemNew_OnLoad;
        SaveSystemNew.OnSave -= SaveSystemNew_OnSave;
    }

    #endregion


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        IsActive = true;

        
    }
    public void Launch(Transform startPos, Transform launchPos)
    {
        FXManager.instance.PlayFX(1);

        //if (!IsActive) return;
        Vector2 launchDir = startPos.position - launchPos.position;
        launchDir.Normalize();

        float force = Vector2.Distance(startPos.position, launchPos.position);
        if (force > maxLaunchForce) force = maxLaunchForce;

        Vector3 finalForce = launchDir * ((force * 5f) * PlayerPrefs.GetFloat("C_LaunchS",1));
        //rb.AddForce(launchDir * (force * 5f), ForceMode2D.Impulse);
        rb.velocity = finalForce;
        //Debug.Log(finalForce);
        

        launchCount++;
        if (PlayerPrefs.HasKey(GlobalStats.LaunchCount))
        {
            PlayerPrefs.SetInt(GlobalStats.LaunchCount, PlayerPrefs.GetInt(GlobalStats.LaunchCount)+1);
        }
        else
        {
            PlayerPrefs.SetInt(GlobalStats.LaunchCount, 1);
        }

    }

    public void StopBall()
    {
        tempVelo = rb.velocity;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }

    public void ContinueBall()
    {
        //rb.velocity = tempVelo;
        rb.isKinematic = false;
        
    }
    public void SwitchState(bool state)
    {
        IsActive = state;
    }
    public void LaunchTest()
    {
        rb.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude < 16 && collision.relativeVelocity.magnitude > 1)
        {
            FXManager.instance.PlayFX(2);
        }
        else if (collision.relativeVelocity.magnitude >= 16)
        {
            FXManager.instance.PlayFX(3);
        }
    }
}
