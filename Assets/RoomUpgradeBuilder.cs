using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is mostly a rehash of the wall builder
public class RoomUpgradeBuilder : MonoBehaviour
{
    public Camera mainCamera;
    public Transform Holder;
    public Transform Pool;
    public int BuildNumber = 0;

    public Vector3 MouseLocation;
    float MouseRotation;
    // Start is called before the first frame update
    void Start()
    {
        GetUpgradeFromPool();

        MouseLocation = Vector3.forward * 10;
        MouseLocation.x = 0.5f;
    }

    void Update()
    {
        //keep ourselves locked to a center frame
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            MouseLocation = raycastHit.point;
            MouseLocation.x = Mathf.Round(MouseLocation.x / 2) * 2;
            MouseLocation.y = 0.1f;
            MouseLocation.z = Mathf.Round(MouseLocation.z / 2) * 2;
            transform.position = MouseLocation;
        }

        //rotate smoothly
        MouseRotation += Input.mouseScrollDelta.y * 30;
        Quaternion target = Quaternion.Euler(0, Mathf.Round(MouseRotation / 90) * 90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5);

        //change the type you are building
        if (Input.GetMouseButtonDown(2))
        {
            Transform firstChild = Holder.GetChild(0);
            if (firstChild != null)
            {
                firstChild.SetParent(Pool);
                firstChild.localPosition = Vector3.one * -100f;
            }
            GetUpgradeFromPool();
            // This needs to be a flip somehow          transform.localScale = new Vector3(-1 * transform.localScale.x, 1, 1);
        }
        //change the build pivot
        if (Input.GetMouseButtonDown(1))
        {
            ChangeOffset();
        }

        //spawn the object
        if (Input.GetMouseButtonDown(0))
        {
            SpawnerConstructable roomConstructable = GetComponentInChildren<SpawnerConstructable>();
            if (roomConstructable != null)
            {
           //     roomConstructable.TryToBuild();
            }
        }
    }
    public void GetUpgradeFromPool()
    {
        Transform firstChild = Pool.GetChild(0);
        if (firstChild != null & GetComponentInChildren<SpawnerConstructable>() == null)
        {
            firstChild.SetParent(Holder);
            firstChild.localPosition = Vector3.zero;
            firstChild.rotation = firstChild.parent.transform.rotation;
        }
        BuildNumber = 0;
        ChangeOffset();
    }
    //this helps us move the room around to different open doorways
    private void ChangeOffset()
    {
        RoomConstructable roomConstructable = GetComponentInChildren<RoomConstructable>();

        if (roomConstructable != null)
        {
            if (roomConstructable.Offsets.Length - 1 != BuildNumber)
            {
                BuildNumber += 1;
            }
            else
            {
                BuildNumber = 0;
            }
            // Update the position based on the next offset
            Holder.localPosition = roomConstructable.Offsets[BuildNumber];
        }
    }

}
