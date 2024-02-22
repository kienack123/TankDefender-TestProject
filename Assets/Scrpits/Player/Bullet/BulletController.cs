using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour , IPooler
{
    
    private float liveTime = 3f;
    
    public IController controller;

    [SerializeField] private Rigidbody rb; 
    private void OnEnable()
    {
        Invoke(nameof(ReturnPool),liveTime);
    }

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(GameController.EnemyName) || other.gameObject.CompareTag(GameController.PlayerName))
        {
            if (other.gameObject.TryGetComponent(out IHealthObject _healthObject))
            {
                _healthObject.TakeDamage(controller.Damage);
                ReturnPool();
            }
        }
    }

    public void ReturnPool()
    {
        PoolingStore.Instance.ReturnPoolingStore(gameObject);
        rb.velocity = Vector3.zero;
    }
}