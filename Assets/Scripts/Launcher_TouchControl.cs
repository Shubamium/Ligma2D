using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher_TouchControl : MonoBehaviour
{
    public Launcher launcher;
    [Space]
    public Transform dragOne;
    public Transform dragTwo;

    [SerializeField]
    private GameObject hitFx;
    bool isDragging = false;

    bool goLaunch = false;
    [SerializeField]
    private SpriteRendererAutoFader sraf;

    private void OnEnable()
    {
       Cursor.lockState = CursorLockMode.Confined; 
       Input.multiTouchEnabled = false;
    }
    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (!launcher.IsActive) return;
        if (Input.touchCount >= 1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Debug.Log("Touch Pressed");

                RaycastHit2D hit = Physics2D.Raycast(GetClickPos(), Vector3.forward, 100f, LayerMask.GetMask("IgnoreHits"));
                if (hit.collider != null)
                {
                   // Debug.Log("hit");
                    isDragging = true;
                    StartControl();

                }

            }

            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                Debug.Log("Touch Lifted/Released"); 
                if (isDragging == true)
                {
                    goLaunch = true;
                }
                isDragging = false;

            }
        }

    }
    private void FixedUpdate()
    {
        if (isDragging)
        {
            MoveControl();
        }
        if(goLaunch == true)
        {
            StopControl();
            goLaunch = false;
        }
    }

    /* Event Mouse Input
private void OnMouseDown()
{
   // Debug.Log("input");
   if (!launcher.IsActive) return;
   //  Debug.Log(clickPos);

   StartControl();

}
private void OnMouseDrag()
{
   Debug.Log("drag");
   if (!launcher.IsActive) return;
   //  Debug.Log("drag");

   MoveControl();

}
private void OnMouseUp()
{
   StopControl();

   //dragOne.position = Vector3.zero;
   //dragTwo.position = Vector3.zero;
}
*/
    private void StartControl()
    {
        FXManager.instance.PlayFX(0);
        sraf.SetVisible();
        Vector3 clickPos = GetClickPos();
        dragOne.position = new Vector3(clickPos.x, clickPos.y, dragOne.position.z);
        dragTwo.position = new Vector3(clickPos.x, clickPos.y, dragOne.position.z);
        launcher.StopBall();

        dragOne.gameObject.SetActive(true);
        dragTwo.gameObject.SetActive(true);


        Instantiate(hitFx, dragOne.position, transform.rotation, transform);
    }
    private void MoveControl()
    {
        FXManager.instance.PlayFXLoop(4);
        Vector3 clickPos = GetClickPos();
        dragTwo.position = new Vector3(clickPos.x, clickPos.y, dragOne.position.z);
    }
    private void StopControl()
    {
        FXManager.instance.StopLoop();

        dragOne.gameObject.SetActive(false);
        dragTwo.gameObject.SetActive(false);
        Debug.Log("stop control");
        launcher.ContinueBall();
        if (!launcher.IsActive) return;
        launcher.Launch(dragOne, dragTwo);
    }



    private static Vector3 GetClickPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
    }



}
