using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(SegmentedCameraFollow))]
public class SegmentedCameraFollowInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SegmentedCameraFollow cam = (SegmentedCameraFollow)target;
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Move Camera Up"))
        {
            cam.MoveCameraUp();
        }
        if (GUILayout.Button("Move Camera Down"))
        {
            cam.MoveCameraDown();
        }
        GUILayout.EndHorizontal();
    }
}
