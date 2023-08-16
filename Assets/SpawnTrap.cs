using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrap : MonoBehaviour
{
    public GameObject toSpawn;

    void Start()
    {
        Reset();
    }
    public void Reset()
    {
        // Destroy current children
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate and set as child
        Instantiate(toSpawn, transform);
    }
}
