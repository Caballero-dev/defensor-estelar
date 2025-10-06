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
    public AudioSource audioSourceWinLose;
    public AudioClip shootSound;
    public AudioClip asteroidCollisionSound;
    public AudioClip loseSound;
    
    public GameObject effectCollisionPrefab;
    public GameObject effectDestroyPrefab;
    
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
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            if (GameController.lives <= 0)
            {
                CreateEffectDestroy();
                Destroy(other.gameObject);
                Destroy(gameObject);
                

            } else
            {
                CreateEffectCollision();
                Destroy(other.gameObject);
                GameController.lives--;
            }
        }
        
        if (other.gameObject.tag == "ProjectileEnemy")
        {
            if (GameController.lives <= 0)
            {

                CreateEffectDestroy();
                Destroy(other.gameObject);
                Destroy(gameObject);

            } else
            {
                 
                
                CreateEffectCollision();
                Destroy(other.gameObject);
                GameController.lives--;
            }
        }
        
    }
    
    void CreateEffectCollision()
    {
        CreateSound(asteroidCollisionSound);
        Instantiate(effectCollisionPrefab, transform.position, effectCollisionPrefab.transform.rotation);
    }
    
    void CreateEffectDestroy()
    {
        CreateSound(loseSound, true);
        Instantiate(effectDestroyPrefab, transform.position, effectDestroyPrefab.transform.rotation);
    }
    
    void Mouvement() 
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(-horizontalMovement, 0, -verticalMovement);
        if (movement != Vector3.zero)
        {
            // Hace que el objeto mire en la dirección del movement
            transform.rotation = Quaternion.LookRotation(movement); 
            // Traslada el objeto en función de la velocidad y la dirección
            transform.Translate(movement.normalized * movementSpeed * Time.deltaTime, Space.World);
        }
    }
    
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateSound(shootSound);
            Instantiate(projectilePrefab, posProjectileLeft.transform.position, posProjectileLeft.transform.rotation);
            Instantiate(projectilePrefab, posProjectileRight.transform.position, posProjectileRight.transform.rotation);
        }
    }
    
    void CreateSound(AudioClip clip, bool isWinOrLose = false)
    {
        if (isWinOrLose)
        {
            audioSourceWinLose.clip = clip;
            audioSourceWinLose.Play();
        }
        else
        {
            audioSource.clip = clip; 
            audioSource.Play();
        } 
    }
    
}
