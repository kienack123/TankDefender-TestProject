using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = System.Random;

public class AIbrain : MonoBehaviour ,IController
{
    
    [Header("Enemy Stats")]
    public float speed;
    public float stopDistance;
    public float damage;
    public float fireRate = 0.7f;
    public float lastShot = 0f;
    
    public float Damage {get; set;}
    public float Force {get; set;}
    
    [Space]
    private AIState currentState;
    
    // Enemy State
    private EnemyMoveState moveState;
    private EnemyIdleState idleState;
    private EnemyAttackState attackState;
    
    readonly float _slerpParam = 5;

    [SerializeField] private GameObject turret;
    private Transform turretOriginalRot;
    [SerializeField] private MeshRenderer tankColor;
    [SerializeField] private TankController tankController; 
        
    public Transform playerPos;
    public NavMeshAgent agent;

    private void Awake()
    {
        playerPos = GameController.Instance.player;
        turretOriginalRot = turret.transform;
    }

    private void Start()
    {
        damage = UnityEngine.Random.Range(1f, 5f);
        Force = 30f;
        Damage = damage;
        moveState = new EnemyMoveState(this);
        idleState = new EnemyIdleState(this);
        attackState = new EnemyAttackState(this);
        
        SetState(moveState);
    }
    
    private void Update()
    {
        currentState.UpdateState();
    }
    
    private void SetState(AIState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(); 
        }

        currentState = newState; 

        currentState.EnterState(); 
    }
    
    public void Move(Vector3 _target)
    {
        Vector3 direction = _target - transform.position;
        
        direction.y = 0f;
        
        float distanceToPlayer = direction.magnitude;
        
        if (distanceToPlayer > stopDistance)
        {
            agent.SetDestination(_target); 
        }
        else
        {
            SetState(idleState);
        }

    }

    public void SetTarget(Transform pos)
    {
        playerPos = pos;
    }
    
    
    public Vector3 GetRandomPoint()
    {
        float randomX = UnityEngine.Random.Range(-5f, 5f);
        float randomZ = UnityEngine.Random.Range(-5f, 5f);
        Vector3 point = new Vector3( 
            playerPos.transform.position.x + randomX
            ,playerPos.transform.position.y
            ,  playerPos.transform.position.z + randomZ);
        return point;
    }

    
    public void SetTankColor(Color color)
    {
        tankColor.material.color = color;
    }
    
    
    public void IldeFinshed()
    {
        SetState(attackState);
    }

    public void Fire()
    {
        if (Time.time > fireRate + lastShot)
        {
            tankController.TankFire(this);
            lastShot = Time.time;
        }
        
    }

    public void AttackFinshed()
    {
        SetState(moveState);
    }

    public void RotationTurret()
    {
        Vector3 directionToPlayer = playerPos.position - turret.transform.position;
        directionToPlayer.y = 0f; 

        Quaternion desiredRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);
        turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, desiredRotation, _slerpParam * Time.deltaTime);
    }
    
    public void RotationOriginalTurret()
    {
        turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, turretOriginalRot.rotation, (_slerpParam + 5) * Time.deltaTime);
    }
}
