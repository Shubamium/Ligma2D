using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UITweenScaleOnHover : MonoBehaviour
{
    private Vector3 baseScale;

    [SerializeField] private float scaleAmount = 1.5f;
    Tween scaleUpTween;
    private void Awake()
    {
         baseScale = transform.localScale;    
    }
    private void OnDisable()
    {
        ScaleDown();
    }
    public void ScaleUp()
    {
        scaleUpTween.Kill();
        scaleUpTween = transform.DOScale(baseScale * scaleAmount, 0.4f).SetEase(Ease.OutExpo).SetDelay(0.02f); 
    }
    public void ScaleDown()
    {
        scaleUpTween.Kill();
        transform.localScale = baseScale;
    }
    
}
