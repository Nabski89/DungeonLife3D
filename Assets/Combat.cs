using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public CombatCardManager CardManager;
    public UnityEngine.AI.NavMeshAgent agent;
    public float DefaultSpeed;
    // Start is called before the first frame update
    void Start()
    {
        CardManager = GetComponent<CombatCardManager>();
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
    }
    void Update()
    {

    }
    public void StartCombat()
    {
        DefaultSpeed = agent.speed;
        agent.speed = 0;
    }
    void EndCombat()
    {
        agent.speed = DefaultSpeed;
    }
}
