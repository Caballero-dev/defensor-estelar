using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    
    public float speed;
    public float distanceZ;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();
        DestroyProjectile();
    }

    void Mouvement() 
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        if (transform.position.z > distanceZ)
        { 
            Destroy(gameObject);
        }
    }
    
}
