using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour
{
    public Material[] materialColors;
    public Renderer objectRenderer;
    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (materialColors.Length > 0)
        {
            objectRenderer.material = materialColors[0];
        }
    }


    public bool clearToBuild = false;

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Doorway>() != null)
            clearToBuild = true;
    }

    void OnTriggerExit(Collider other)
    {
        clearToBuild = false;
    }

    private void Update()
    {
        if (clearToBuild == true)

            objectRenderer.material = materialColors[0];
        else
            objectRenderer.material = materialColors[1];
    }
}