using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRandomize : MonoBehaviour
{
    public int MaxX;
    public int MinX;
    public int MaxY;
    public int MinY;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.position + Vector3.right * 2 * Random.Range(MinX, MaxX+1)+ Vector3.forward * 2 * Random.Range(MinY, MaxY+1);
        Destroy(this);
    }
}
