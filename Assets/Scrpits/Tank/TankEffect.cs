using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEffect : MonoBehaviour
{
    public GameObject breakDownEffect;
    
    public GameObject takeDamageEffect;
    
    
    public GameObject explosiveEffect;
    
    private HealthController healthController;

    public Transform effecPosition;
    
    private void OnEnable()
    {
        healthController = GetComponentInParent<HealthController>();
        if (healthController)
        {
            healthController.breakDownEvt += BreakDown;
        }
    }
    
    
    
    
    private void OnDisable()
    {
        if (healthController)
        {
            healthController.breakDownEvt -= BreakDown;
        }
    }
    
    public void BreakDown()
    {
        breakDownEffect.gameObject.SetActive(true);
    }
    
    
    public void TakeDamage()
    {
        breakDownEffect.gameObject.SetActive(true);
    }


    public void Explosive()
    {
        explosiveEffect.gameObject.SetActive(true);
    }
    
}
    