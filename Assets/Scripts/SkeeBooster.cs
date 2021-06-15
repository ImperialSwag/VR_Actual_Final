using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeeBooster : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Basketball"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * -10, ForceMode.Acceleration);
        }
    }

}
