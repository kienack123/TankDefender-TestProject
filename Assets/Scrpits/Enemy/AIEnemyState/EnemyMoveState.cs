using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : AIState
{
    private Vector3 randomPoint;
    public EnemyMoveState(AIbrain controller) : base(controller)
    {
        
    }
    public override void EnterState()
    {
        randomPoint = aiBrain.GetRandomPoint();
    }
    
    public override void UpdateState()
    {
        aiBrain.Move(randomPoint);
        aiBrain.RotationOriginalTurret();
    }
    
    
    public override void ExitState()
    {

    }

}
