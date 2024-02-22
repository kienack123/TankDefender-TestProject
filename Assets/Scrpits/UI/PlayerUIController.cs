using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Slider healthSlider;

    [SerializeField] private HealthController healthController;

    private int scrore = 0;

    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        healthSlider.maxValue = healthController.currentHealth;
        healthSlider.value = healthController.currentHealth;
    }

    private void OnEnable()
    {
        healthController.takeDamageEvt += UpdateHealth;

        GameAction.PlayerDeadEvt += GameOver;
        GameAction.EnemyDeadEvt += UpdateScore;

    }

    private void OnDisable()
    {
        healthController.takeDamageEvt -= UpdateHealth;
        GameAction.PlayerDeadEvt -= GameOver;
        GameAction.EnemyDeadEvt -= UpdateScore;
    }


    public void UpdateScore()
    {
        scrore += 1;
        scoreText.text = "Score : "+ scrore;
        Debug.Log(scrore);

    }

    private void UpdateHealth()
    {
        healthSlider.value = healthController.currentHealth;
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
