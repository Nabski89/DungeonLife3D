using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyController : MonoBehaviour
{
    public GameObject[] partySlots; // Array of preset PartySlot game objects
    public GameObject[] partyMembers; // Array of characters in the party

    private void PartyAssign()
    {
        for (int i = 0; i < partyMembers.Length; i++)
        {
            GameObject character = partyMembers[i];

            // Disable NavMeshAgent
            UnityEngine.AI.NavMeshAgent navAgent = character.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (navAgent != null)
                navAgent.enabled = false;

            // Change position and parent to a preset PartySlot
            if (i < partySlots.Length)
            {
                character.transform.position = partySlots[i].transform.position;
                character.transform.parent = partySlots[i].transform;
            }
            else
            {
                Debug.LogError("Not enough party slots for all party members!");
            }
        }
    }

    private void PartyBreakUp()
    {
        foreach (GameObject character in partyMembers)
        {
            // Reset parent and position
            character.transform.parent = null;
            character.transform.position = Vector3.zero;

            // Re-enable NavMeshAgent
            UnityEngine.AI.NavMeshAgent navAgent = character.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (navAgent != null)
                navAgent.enabled = true;
        }
    }
}