using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIController : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    [SerializeField] private HealthController healthController;

    private void OnEnable()
    {
        healthSlider.maxValue = healthController.currentHealth;
        healthSlider.value = healthController.currentHealth;
        healthController.takeDamageEvt += UpdateUI;
    }

    private void OnDisable()
    {
        healthController.takeDamageEvt -= UpdateUI;
    }
    
    public void UpdateUI()
    {
        healthSlider.value = healthController.currentHealth;
    }
}
