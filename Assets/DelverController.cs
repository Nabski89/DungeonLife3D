using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelverController : MonoBehaviour
{
    public int Level = 0;
    public int ClassXP = 0;
    public int JobXP = 0;
    public float hp = 10;

    public float MoveIdle = 0;
    //use these stat to affect character speed

    public float treasure = 0;

    //Used by the body to pick your pants
    public int ClassType;
    public int RaceType;


    // Start is called before the first frame update
    void Awake()
    {
        RaceType = Random.Range(0, 4);
    }

    void Update()
    {
        if (hp <= 0)
        {
            die();
        }
    }
    void die()
    {
        Destroy(gameObject);
    }
}