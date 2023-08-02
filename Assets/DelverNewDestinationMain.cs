using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelverNewDestinationMain : MonoBehaviour
{
    public Transform TravelPointMAIN;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Delver Reached: " + gameObject.name);
        DelverNavigateController Delver = other.GetComponent<DelverNavigateController>();
        if (Delver != null)
        {
            Debug.Log("Delver Reached: " + gameObject.name);
            Delver.TravelPointMAIN = TravelPointMAIN;
        }
    }
}