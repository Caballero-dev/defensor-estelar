using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GemFactory : MonoBehaviour
{
    
    public Vector2 spawnRangeX;
    public Vector2 spawnRangeY;
    public float spawnY;

    public int initialDelay = 5;
    public int spawnDelay = 10;
    public GameObject[] gemPrefabs;
    
    public AudioSource audioSource;
    public AudioClip destroySound;
    
    private int index;
    private GameObject newGem;
    
    // Start is called before the first frame update
    void Start()
    { 
        Invoke("CreateGem", initialDelay);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && newGem != null)
        {
            audioSource.clip = destroySound;
            audioSource.Play();
            Destroy(newGem);
            Invoke("CreateGem", spawnDelay);
        }
    }

    void ChangePosition()
    {
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);
        transform.position = new Vector3(randomX, spawnY, randomY);
    }
    
    void CreateGem()
    {
        bool gemActives = GameObject.FindGameObjectWithTag("Gem");
        if (gemActives) return;
        
        ChangePosition();
        index = Random.Range(0, gemPrefabs.Length);
        newGem = Instantiate(gemPrefabs[index], transform.position, gemPrefabs[index].transform.rotation);
    }
    
}
