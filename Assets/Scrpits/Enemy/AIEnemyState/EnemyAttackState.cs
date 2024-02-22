using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : AIState
{
    private float countdownTime = 3f; 
    
    private float currentTime;
    public EnemyAttackState(AIbrain controller) : base(controller)
    {
        
    }
    public override void EnterState()
    {
        currentTime = countdownTime;
    }
    public override void UpdateState()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            aiBrain.Fire();
        }
        else
        {
            aiBrain.AttackFinshed();
        }
    }
    public override void ExitState()
    {

    }
}
