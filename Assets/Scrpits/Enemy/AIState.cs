using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AIState 
{
    protected AIbrain aiBrain;
    
    protected NavMeshAgent agent;

    protected Transform playerPos;
    
    protected Rigidbody rigid;
    
    protected AIState(AIbrain controller)
    {
        aiBrain = controller;
        playerPos = controller.playerPos;
        agent = controller.GetComponent<NavMeshAgent>();
        rigid = controller.GetComponent<Rigidbody>();
    }
    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void ExitState();
    
}
