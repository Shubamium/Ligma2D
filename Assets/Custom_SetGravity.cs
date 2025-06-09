using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_SetGravity : MonoBehaviour
{
    public Rigidbody2D rb;
    private void Start()
    {
        rb.gravityScale *= PlayerPrefs.GetFloat("C_Gravity", 1f);
    }
}
