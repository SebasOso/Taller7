using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform spawn;
    [SerializeField] private GameObject enemyPrefab;
    public void Spawn()
    {
        Instantiate(enemyPrefab, spawn.position, spawn.rotation); 
    }
}
