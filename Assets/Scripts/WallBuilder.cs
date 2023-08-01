using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    public Camera mainCamera;
    SpriteRenderer m_SpriteRenderer;
    public Sprite[] spriteList;
    public GameObject[] WallList;
    int BuildNumber = 0;

    public Vector3 MouseLocation;
    float MouseRotation;
    // Start is called before the first frame update
    void Start()
    {
        MouseLocation = Vector3.forward * 10;
        MouseLocation.x = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            MouseLocation = raycastHit.point;
            MouseLocation.x = Mathf.Round(MouseLocation.x / 6) * 6;
            MouseLocation.y = 0.1f;
            MouseLocation.z = Mathf.Round(MouseLocation.z / 6) * 6;
            transform.position = MouseLocation;
        }


        MouseRotation += Input.mouseScrollDelta.y * 30;
        Quaternion target = Quaternion.Euler(90, Mathf.Round(MouseRotation / 90) * 90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5);

        if (Input.GetMouseButtonDown(2))
        {
            transform.localScale = new Vector3(-1 * transform.localScale.x, 1, 1);
        }
        //change the type you are building
        if (Input.GetMouseButtonDown(1))
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            BuildNumber += 1;
            if (spriteList.Length == BuildNumber)
                BuildNumber = 0;
            m_SpriteRenderer.sprite = spriteList[BuildNumber];
        }
        //spawn the object
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(WallList[BuildNumber], transform.position + (Vector3.up * 0.5f), Quaternion.Euler(0, Mathf.Round(MouseRotation / 90) * 90, 0));
            //            Destroy(gameObject);
        }
    }
}
