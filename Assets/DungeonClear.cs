using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonClear : MonoBehaviour
{

    //calls the reset() function for all Trap, Treasure, or Defender scripts that are children of the parent asset
    private void Start()
    {
        ResetChildScriptsInChildren();
    }

    private void ResetChildScriptsInChildren()
    {

        Component[] Traps = transform.parent.GetComponentsInChildren<SpawnTrap>();
        foreach (SpawnTrap trap in Traps)
            trap.Reset();

        Component[] Defenders = transform.parent.GetComponentsInChildren<SpawnDefender>();
        foreach (SpawnDefender defender in Defenders)
        {
            Debug.Log("Reset A Defender");
            defender.Reset();
        }

        Component[] Treasures = transform.parent.GetComponentsInChildren<SpawnTreasure>();
        foreach (SpawnTreasure treasure in Treasures)
            treasure.Reset();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Delver Cleared the dungeon: " + gameObject.name);
        DelverController Delver = other.GetComponent<DelverController>();
        if (Delver != null)
        {
            ResetChildScriptsInChildren();
        }
    }
}
