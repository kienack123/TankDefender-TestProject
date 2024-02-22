using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : AIState
{
    private float countdownTime; 
    
    private float currentTime;
    
    public EnemyIdleState(AIbrain controller) : base(controller)
    {
        
    }
    public override void EnterState()
    {
        float randomIdleTime = UnityEngine.Random.Range(1f, 3f);

        countdownTime = randomIdleTime;
        
        currentTime = countdownTime;
        

    }
    public override void UpdateState()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            aiBrain.RotationTurret();
        }
        else
        {
            aiBrain.IldeFinshed();
        }
    }
    
    public override void ExitState()
    {
        
    }
}
