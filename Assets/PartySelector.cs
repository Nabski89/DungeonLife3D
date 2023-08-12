using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartySelector : MonoBehaviour
{
    public bool[] OpenSeats;
    public Transform[] SeatLocation;
    public GameObject[] PossiblePartyMembers;
   // public GameObject PartyStarter;
    public GameObject EmptyParty;
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
                    PossiblePartyMembers[i] = other.transform.gameObject;
                    Delver.DelverSetDestination();
                    OpenSeats[i] = true;
                    Delver.SeatTracking = i;
                    i += 10000;

                    if (i == OpenSeats.Length)
                    {
              //          Instantiate EmptyParty
                    }
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
            PossiblePartyMembers[Delver.SeatTracking] = null;
            Delver.SeatTracking = -1;
        }
    }
}
