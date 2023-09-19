using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomConstructable : MonoBehaviour
{
    public Room RoomInformation;
    public Vector3[] Offsets;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void TryToBuild()
    {

        bool buildReady = true;
        bool DoorCheck = false;
        //check that no rooms are blocked
        foreach (Transform child in transform)
        {
            RoomBlockOnBuild roomBlock = child.GetComponent<RoomBlockOnBuild>();
            if (roomBlock != null)
            {
                if (roomBlock.clearToBuild == false)
                    buildReady = false;
            }

            //check to make sure that we have a door touching a door
            Component[] Doors;
            Doors = GetComponentsInChildren<Doorway>();
            foreach (Doorway doortocheck in Doors)
            {
                if (doortocheck.clearToBuild == true)
                    DoorCheck = true;
            }
        }

        if (buildReady == false)
            Debug.Log("Could not build, location blocked");
        if (DoorCheck == false)
            Debug.Log("Could not build, No Doorway Connection");

        //unparent our current room and disable the builder
        if (buildReady == true && DoorCheck == true)
        {
            GameObject RoomBuilderTool = transform.parent.parent.gameObject;
            //set our parent to the nearest dungeon in our room builders dungeon tool
            Transform nearestObject = null;
            float shortestDistance = Mathf.Infinity;
            Debug.Log("We have a dungeon");
            foreach (GameObject dungeonObject in RoomBuilderTool.GetComponent<WallBuilder>().Dungeons)
            {
                float distance = Vector3.Distance(transform.position, dungeonObject.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestObject = dungeonObject.transform;
                }
            }
            transform.parent = nearestObject;

            //need to make sure the room is rotated correctly BUG ALERT
            RoomBuilderTool.SetActive(false);
            Doorway[] doorways = GetComponentsInChildren<Doorway>();


            //replace the floor tiles
            TileChange[] tileChangeComponents = transform.parent.GetComponentsInChildren<TileChange>();
            foreach (TileChange tileChange in tileChangeComponents)
            {
                tileChange.enabled = true;
            }
            //change our blockers
            Component[] BlockerTiles;
            BlockerTiles = GetComponentsInChildren<RoomBlockOnBuild>();
            foreach (RoomBlockOnBuild Blocks in BlockerTiles)
            {
                Blocks.GetComponent<MeshRenderer>().enabled = false;
                Destroy(Blocks);
            }
        }
    }



    void DoBuild()
    {

        Destroy(this);
    }
}