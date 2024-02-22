using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static readonly string EnemyName = "Enemy";
    public static readonly string PlayerName = "Player";
    
    private static GameController instance;

    public static GameController Instance => instance;


    public Transform player;


    private void OnEnable()
    {
        // HealthController.deadEvt += GameOver;
    }

    private void OnDisable()
    {
        // HealthController.deadEvt -= GameOver;
    }
    
    private void Start()
    {
        if(instance != null ) return;
        instance = this;
    }
    
    public void GameOver()
    {
        Debug.Log("Game Over");
    }
    

    public Transform GetPlayerPosition()
    {
        return player;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    
}
