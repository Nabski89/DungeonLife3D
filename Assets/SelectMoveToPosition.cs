using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMoveToPosition : MonoBehaviour
{
    public Camera cam;
    public UnityEngine.AI.NavMeshAgent MoveAgent;
    public GameObject MoveObjectSelected;
    public InfoBox UIElement;
    public GameObject MoveHighlighter;
    public Vector3 TargetLocation;
    public bool Click = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Click = true;
        if (Input.GetMouseButtonDown(1))
            ClearSelection();
    }
    void FixedUpdate()
    {


        //     Debug.Log("The Object We are tracking is "+ MoveObjectSelected );
        if (MoveObjectSelected != null)
        {
            // highlighter
            MoveHighlighter.transform.position = new Vector3(MoveObjectSelected.transform.position.x, 0.6f, MoveObjectSelected.transform.position.z);


            if (Click == true)
            {
                Click = false;
                int layerMask = 1 << 3;
                //this needs to be layer masked but currently isn't
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitPoint;

                if (Physics.Raycast(ray, out hitPoint, 100, layerMask))
                {
                    if (hitPoint.collider != null)
                    {
                        TargetLocation = hitPoint.point;
                        MoveObjectSelected.GetComponentInParent<UnityEngine.AI.NavMeshAgent>().SetDestination(TargetLocation);
                        MoveObjectSelected = null;
                    }
                }
            }
        }
        else
        {
            //send the highlighter to the shadowzone. We could just disable and enable it instead.
            MoveHighlighter.transform.position = 300 * (Vector3.one);
            if (Click == true)
            {
                Click = false;
                int layerMask = 1 << 6;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitPoint;

                if (Physics.Raycast(ray, out hitPoint, 100, layerMask))
                {
                    if (hitPoint.collider != null)
                    {
                        MoveObjectSelected = hitPoint.collider.gameObject;
                        //send it to the UI
                        UIElement.Select(MoveObjectSelected);
                        Debug.Log("The Object We are tracking is " + MoveObjectSelected);
                    }
                }
            }
        }
    }
    private void ClearSelection()
    {
        MoveObjectSelected = null;
        UIElement.Clear();
    }

}