using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int HP;
    // Start is called before the first frame update
     private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Delver Reached: " + gameObject.name);
        DelverController Delver = other.GetComponent<DelverController>();
        if (Delver != null)
        {
            Debug.Log("Delver Entered Combat With: " + gameObject.name);
            Delver.GetComponent<CombatCardManager>().Draw();
            Delver.hp -= 1;
            HP -= 1;
            Destroy(gameObject);
        }
    }
}
