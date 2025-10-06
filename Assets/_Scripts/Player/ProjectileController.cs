using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;
    
    private GameObject playerObject;
    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("PlayerShip");
        player = playerObject.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyProjectile();
        MovementProjectile();
    }

    void MovementProjectile()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        if (Vector3.Distance(player.position, transform.position) >= 10)
        {
            Destroy(gameObject);
        }
    }
    
}
