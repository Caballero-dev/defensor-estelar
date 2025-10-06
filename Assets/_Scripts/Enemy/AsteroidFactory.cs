using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFactory : MonoBehaviour
{
    public Vector2 spawnRangeX;
    
    public int spawnInterval;
    public GameObject[] asteroidPrefabs;
    public int maxAsteroidsActive;
    
    private int index;
    private List<GameObject> newAsteroids;
    
    // Audio
    // public AudioSource audioSource;
    // public AudioClip spawnSound;
    
    // Start is called before the first frame update
    void Start()
    {
        newAsteroids = new List<GameObject>();
        
        InvokeRepeating("CreateAsteroid", 2, spawnInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void ChangePosition()
    {
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        transform.position = new Vector3(randomX, transform.position.y, transform.position.z);
    }
    
    void CreateAsteroid()
    {
        int asteroidActives = GameObject.FindGameObjectsWithTag("Asteroid").Length;
        if (asteroidActives >= maxAsteroidsActive) return;
        ChangePosition();
        // audioSource.clip = spawnSound;
        // audioSource.Play();
        index = Random.Range(0, asteroidPrefabs.Length);
        GameObject newAsteroid = Instantiate(asteroidPrefabs[index], transform.position, asteroidPrefabs[index].transform.rotation);
        newAsteroids.Add(newAsteroid);
    }
    
}
