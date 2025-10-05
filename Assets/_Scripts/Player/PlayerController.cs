using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public GameObject posProjectileLeft;
    public GameObject posProjectileRight;
    public GameObject projectilePrefab;
    
    // Audio
    public AudioSource audioSource;
    public AudioClip shootSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();
        Shoot();
    }
    
   public void Mouvement() 
   {
        float horizontalMovement = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(-horizontalMovement, 0, 0);

        transform.Translate(movement.normalized * movementSpeed * Time.deltaTime, Space.World);
   }
   
   public void Shoot()
   {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.clip = shootSound;
            audioSource.Play();
            Instantiate(projectilePrefab, posProjectileLeft.transform.position, posProjectileLeft.transform.rotation);
            Instantiate(projectilePrefab, posProjectileRight.transform.position, posProjectileRight.transform.rotation);
        }
   }
   
    
}
