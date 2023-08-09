using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelverNavigateController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform TravelPointMAIN;
    //    public Transform TravelPointSUB;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        //     TravelPointSUB = TravelPointMAIN;
        agent.destination = TravelPointMAIN.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            TravelPointMAIN = null;
        }
        /*
        if (TravelPointSUB == null)
        {
            TravelPointSUB = TravelPointMAIN;
            agent.destination = TravelPointSUB.position;
        }
*/

    }
}
