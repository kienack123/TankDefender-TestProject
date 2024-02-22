using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController :  MonoBehaviour, IController
{
    [Header("Player Stats")]
    private float damage;
    [SerializeField] private float force;
    public float fireRate = 0.16f;
    private float lastShot = 0f;
    public float Damage { get; set; }
    public float Force { get; set; }

    [SerializeField] private TankController tankController;

    private void Start()
    {
        damage = UnityEngine.Random.Range(1f, 5f);
        Damage = damage;
        Force = force;
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
        
    }

    public void Fire()
    {
        if (!tankController) return;
        
        if (Time.time > fireRate + lastShot)
        {
            tankController.TankFire(this);
            lastShot = Time.time;
        }
    }
    
    
    
}
