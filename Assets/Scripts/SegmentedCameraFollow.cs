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
    private void Start()
    {
        SetupAmount();
    }

    private void SetupAmount()
    {
        downAmount = camera.position.y - offsetAmount;
        upAmount = camera.position.y + offsetAmount;
    }

    private void Update()
    {
        if (target == null) return;

        if (target.position.y <= downAmount)
        {
            //Move The Camera Down
            MoveCamera(-offsetAmount*2);
        }
        if (target.position.y >= upAmount)
        {
            //Move the Camera Up
            MoveCamera(offsetAmount*2);
        }
    }
    private void MoveCamera(float amount)
    {
       // Debug.Log("Camera Moved");
        camera.transform.position += new Vector3(0, amount, 0);
        SetupAmount();
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
        MoveCamera(-offsetAmount * 2);
    }
    public void MoveCameraUp()
    {
        MoveCamera(offsetAmount * 2);
    }
}
