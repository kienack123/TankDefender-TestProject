using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<Transform> points;

    [SerializeField] private GameObject TankObject;

    [SerializeField] private Transform playerPos;


    [SerializeField] private float minSpawnTime = 1f;

    [SerializeField] private float spawnTime = 5f;
    
    private void Start()
    {
        points = new List<Transform>();
        foreach (Transform child in transform)
        {
            points.Add(child.transform);
        }

        InvokeRepeating(nameof(RandomSpawnEnemy), spawnTime, spawnTime);

    }



    private void RandomSpawnEnemy()
    {
        if(spawnTime <= minSpawnTime) return;
        
        int randomIndex = UnityEngine.Random.Range(0, points.Count);

        GameObject _tank = Instantiate(TankObject, points[randomIndex].position, Quaternion.identity);

        if (_tank.TryGetComponent(out AIbrain _aiBrain))
        {
            _aiBrain.SetTarget(playerPos);
            _aiBrain.SetTankColor(GetRandomTankColor());

        }


        Color GetRandomTankColor() 
        {
            Color _color = new Color(UnityEngine.Random.Range(0, 1f)
                , UnityEngine.Random.Range(0, 1f)
                , UnityEngine.Random.Range(0, 1f));
            return _color;
        }

        spawnTime -= 0.1f;
    }
}