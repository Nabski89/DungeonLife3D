using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBlockOnBuild : MonoBehaviour
{

    public Material[] materialColors;
    public bool clearToBuild = true;

    public Renderer objectRenderer;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (materialColors.Length > 0)
        {
            objectRenderer.material = materialColors[1];
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<RoomBlockPermanent>() != null)
            clearToBuild = false;
    }

    void OnTriggerExit(Collider other)
    {
        clearToBuild = true;
    }
    private void Update()
    {
        if (clearToBuild == true)

            objectRenderer.material = materialColors[0];
        else
            objectRenderer.material = materialColors[1];
    }
}
