using System;
using UnityEngine;

public class HealthController : MonoBehaviour ,IHealthObject
{
    public float Health { get; set; }
    
    public float currentHealth;

    [SerializeField] private float health;
    
    public Action breakDownEvt;

    public Action takeDamageEvt;

    public TankEffect tankEffect;
    
    
    private void Start()
    {
        Health = health;
        currentHealth = Health;
    }


    private void Update()
    {
        if (this.gameObject.tag == "Player")
        {
            if( Input.GetKeyDown(KeyCode.Mouse1))
            {
                TakeDamage(10);
            }
        }
    }

    public void TakeDamage(float damageReceive)
    {
        currentHealth -= damageReceive;
        
        takeDamageEvt.Invoke();

        if (currentHealth <= 5f)
        {
            breakDownEvt.Invoke();
        }
        if (currentHealth <= 0f)
        {
            Dead();
        }
    }
    public void Dead()
    {
        if (gameObject.CompareTag(GameController.PlayerName))
        {
            GameAction.PlayerDeadEvt.Invoke();
        }
        else if (gameObject.CompareTag(GameController.EnemyName))
        {
            GameAction.EnemyDeadEvt.Invoke();

            DestroyMe();
        }
    }


    void DestroyMe()
    {
        Destroy(gameObject);
    }
    
}
