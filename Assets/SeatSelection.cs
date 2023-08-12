using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatSelection : MonoBehaviour
{
    public bool[] OpenSeats;
    public Transform[] SeatLocation;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Delver Reached: " + gameObject.name);
        DelverNavigateController Delver = other.GetComponent<DelverNavigateController>();
        if (Delver != null)
        {
            for (int i = 0; i < OpenSeats.Length; i++)
            {
                Debug.Log("We are considering seat: " + i);
                if (OpenSeats[i] == false)
                {
                    Delver.TravelPointMAIN = SeatLocation[i];
                    Delver.DelverSetDestination();
                    OpenSeats[i] = true;
                    Delver.SeatTracking = i;
                    i += 10000;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Delver Left: " + gameObject.name);
        DelverNavigateController Delver = other.GetComponent<DelverNavigateController>();
        if (Delver != null)
        {
            OpenSeats[Delver.SeatTracking] = false;
            Delver.SeatTracking = -1;
        }
    }
}
