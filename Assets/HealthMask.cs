using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMask : MonoBehaviour
{
    DelverController Delver;
    // Start is called before the first frame update
    void Start()
    {
            Delver = GetComponentInParent<DelverController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one*Delver.hp;
    }
}
