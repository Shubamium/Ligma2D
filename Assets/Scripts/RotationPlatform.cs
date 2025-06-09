using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlatform : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, speed*50*Time.deltaTime);
    }
}
