using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
[RequireComponent(typeof(Button),typeof(EventTrigger))]
public class EventTriggerButtonInteractable : MonoBehaviour
{

    private Button target;
    private EventTrigger trigger;


    private void Awake()
    {
        target = GetComponent<Button>();
        trigger = GetComponent<EventTrigger>();

    }
    private void FixedUpdate()
    {
        //trigger.triggers[1].callback.;
        // trigger.enabled = target.interactable;
        if (target.interactable)
        {
            trigger.enabled = true;
        }
        else
        {

            trigger.enabled = false;
        }
    }
}
