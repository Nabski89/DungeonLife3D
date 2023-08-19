using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerConstructable : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color originalColor;
    bool BuildPossible = false;

    private void Start()
    {
        //       spriteRenderer = GetComponent<SpriteRenderer>();
        //        originalColor = spriteRenderer.color;
        spriteRenderer.color = originalColor;
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<RoomBlockPermanent>() != null)
        {
            Debug.Log("Upgrade touched a room blocker");
            spriteRenderer.color = Color.cyan; // Change color to red
            BuildPossible = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<RoomBlockPermanent>() != null)
        {
            spriteRenderer.color = Color.red; // Reset color
            BuildPossible = true;
        }
    }

}
