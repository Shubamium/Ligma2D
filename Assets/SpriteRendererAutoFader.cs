using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRendererAutoFader : MonoBehaviour
{
    [SerializeField]
    private Color visibleColor;
    [SerializeField]
    private float fadeSpeed;
    private float originAlpha;

    private SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originAlpha = visibleColor.a;
    }
    private void FixedUpdate()
    {
        if(visibleColor.a != 0)
        {
            visibleColor.a -= fadeSpeed/100*Time.deltaTime;
            sr.color = visibleColor;
        }
    }
    public void SetVisible()
    {
        visibleColor.a = originAlpha;
        sr.color = visibleColor;
    }
}
