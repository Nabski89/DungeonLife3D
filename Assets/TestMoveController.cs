using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveController : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    private int destPoint = 0;
    public Transform[] TravelPoints;
//    public Vector3[] TravelPoints;
    //https://docs.unity3d.com/Packages/com.unity.ai.navigation@1.1/manual/NavAgentPatrol.html
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        GotoNextPoint();
    }
    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (TravelPoints.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
       // agent.destination = TravelPoints[destPoint];
 agent.destination = TravelPoints[destPoint].position;


        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % TravelPoints.Length;
    }


    // Update is called once per frame
    void Update()
    {

        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}