using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPresser : MonoBehaviour
{
    public UnityEvent OtherFunctions;

    bool inTrigger = false;

    GameObject enteredObj = null;

    private void Update()
    {
        if (inTrigger)
        {
            if(enteredObj != null && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.Touch))
            {
                OtherFunctions.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ControllerLeft") || other.CompareTag("ControllerRight"))
        {
            inTrigger = true;
            enteredObj = other.gameObject;
        } 
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("ControllerLeft") || other.CompareTag("ControllerRight"))
        {
            inTrigger = false;
            enteredObj = null;
        }
    }
}
