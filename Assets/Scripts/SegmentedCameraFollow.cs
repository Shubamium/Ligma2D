using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentedCameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform camera;
    //The amount of heights the player would have to travel before moving the camera
    [SerializeField]
    private float offsetAmount;
    
    // To check if the camera should go down or up
    [SerializeField]
    private float downAmount;
    [SerializeField]
    private float upAmount;

    [SerializeField,Space]
    private int debugAmount;

    [SerializeField]
    private float currCameraHeight;
    [SerializeField]
    private float lerpTarget;

    [SerializeField]
    private float duration;
    private void Start()
    {
        SetupAmount();
        duration = PlayerPrefs.GetFloat("CAMERA_SPEED", 0.4f);
    }

    enum Direction
    {
        DOWN,
        UP
    }
    private void SetupAmount()
    {
        // Reset Target After camera has correctly positioned
       downAmount = camera.position.y - offsetAmount ;
       upAmount = camera.position.y + offsetAmount ;
        currCameraHeight = camera.position.y;

    }

    private void Update()
    {
        if (target == null) return;



        // When to move the camera
        if (target.position.y <= downAmount)
        {
            //Move The Camera Down
            MoveCamera(Direction.DOWN);
        }
        if (target.position.y >= upAmount)
        {
            //Move the Camera Up
            MoveCamera(Direction.UP);
        }
      
       
    }
    private void MoveCamera(Direction dir)
    {
        // Debug.Log("Camera Moved");
        // camera.transform.position += new Vector3(0, amount, 0);
       Time.timeScale = 0;
        // If the camera needs to move
        switch (dir)
        {
            case Direction.DOWN:
                lerpTarget = currCameraHeight - (offsetAmount * 2);
                break;
            case Direction.UP:
                lerpTarget = currCameraHeight + (offsetAmount * 2);
                    break;
        }
   
       float dt = Time.unscaledDeltaTime;
       float lerp = Mathf.MoveTowards(camera.position.y, lerpTarget,  dt / (duration / 5));
       camera.position = new Vector3(0, lerp, camera.position.z);
      
        // If difference of the position of the target and the current position is less than 0.15f just close the distance instantly
        if(Mathf.Abs(camera.position.y - lerpTarget) < 0.01f)
        {
            Debug.Log("Camera Transition Done");
            camera.position = new Vector3(0, lerpTarget, camera.position.z);
            Time.timeScale = 1;
            SetupAmount();
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        for(int i = 0; i < debugAmount; i++)
        {
            Gizmos.DrawWireCube(transform.position + (new Vector3(0f, (offsetAmount*2) * (i + 1), 0f)), new Vector3(offsetAmount * 3, offsetAmount * 2, 1));
        }
    }
    public void MoveCameraDown()
    {
        MoveCamera(Direction.DOWN);
    }
    public void MoveCameraUp()
    {
        MoveCamera(Direction.UP);
    }
}
