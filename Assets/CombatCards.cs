using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCards : MonoBehaviour, ICard
{
    public int CardUpgrade;
    public int[] atk;
    public int[] def;
    // public sprite[] Picture;
    // Start is called before the first frame update
    public void Play()
    {
        Debug.Log("An attack card was played that deals " + atk[CardUpgrade] + " Damage and has a defense value of " + def[CardUpgrade]);
        transform.position = transform.TransformPoint(2.3f * Vector3.up);
        Invoke("ReturnCard", 2);
    }

    public void ReturnCard()
    {
        transform.position = transform.TransformPoint(-2.3f * Vector3.up);
    }
}
