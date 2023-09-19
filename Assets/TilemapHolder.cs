using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapHolder : MonoBehaviour
{
    public Tilemap tilemapSetable;
    public static TilemapHolder Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
}
