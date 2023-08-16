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
        Doorway[] doorways = GetComponentsInChildren<Doorway>();

        foreach (Doorway doorway in doorways)
        {
            Collider[] colliders = Physics.OverlapBox(
                doorway.transform.position,
                doorway.transform.localScale / 2f,
                doorway.transform.rotation
            );

            foreach (Collider collider in colliders)
            {
                if (collider != doorway.GetComponent<Collider>() && collider.GetComponent<Doorway>() != null)
                {
                    Transform otherParent = collider.transform.parent;
                    if (otherParent != null)
                    {
                        //reset the Wall Builder Script int that keeps track of our rotation.
                        transform.parent.gameObject.GetComponent<WallBuilder>().BuildNumber = 0;


                        Destroy(gameObject);
                        Destroy(GetComponent<RoomConstructable>());
                        otherParent.gameObject.SetActive(false);
                        Destroy(otherParent.GetComponent<RoomConstructable>());
                        return;
                    }

                }
            }
        }
    }
    //this was a bad chatgpt thing that tried to hard

    void DoBuild()
    {

        Destroy(this);
    }
}