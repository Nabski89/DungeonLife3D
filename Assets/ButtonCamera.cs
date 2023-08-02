using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCamera : MonoBehaviour
{
    public GameObject GameObjectSet;
    public Vector3 HardLocationSet;
    public Camera mainCamera;

    public void SetCamera()
    {
        if (GameObjectSet == null)
            mainCamera.transform.position = HardLocationSet + Vector3.up * mainCamera.transform.position.y;
        else
            mainCamera.transform.position = GameObjectSet.transform.position - Vector3.up * GameObjectSet.transform.position.y + Vector3.up * mainCamera.transform.position.y;

    }
}
