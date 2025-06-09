using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRenderer_TwoTransform : MonoBehaviour
{
    [SerializeField]
    private Transform start,end;

    private LineRenderer lr;


    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        
    }
    private void Update()
    {
        lr.SetPosition(0, start.position);
        lr.SetPosition(1, end.position);
        
    }
}
