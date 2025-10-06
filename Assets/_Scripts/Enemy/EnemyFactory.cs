using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    
    // public Vector2 spawnRangeX;
    
    public int initialDelay = 5;
    public int spawnInterval = 15;
    public GameObject[] enemyPrefabs;
    
    private int index;
    private GameObject newEnemy;
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", initialDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void CreateEnemy()
    {
        bool enemyActives = GameObject.FindGameObjectWithTag("EnemyShip");
        if (enemyActives) return;
        
        index = Random.Range(0, enemyPrefabs.Length);
        newEnemy = Instantiate(enemyPrefabs[index], transform.position, enemyPrefabs[index].transform.rotation);
    }
    
}
