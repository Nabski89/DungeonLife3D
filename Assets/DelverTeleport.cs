using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelverTeleport : MonoBehaviour
{
    public Transform TeleportLocation;
    private void OnTriggerEnter(Collider other)
    {
        DelverNavigateController Delver = other.GetComponent<DelverNavigateController>();
        if (Delver != null)
        {
            Delver.transform.position = TeleportLocation.position;
        }
    }
}
