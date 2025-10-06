using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public AudioClip explosionSound;
    public AudioClip loseSound;
    
    public GameObject effectCollisionPrefab;
    public GameObject effectDestroyPrefab;
    
    public SceneLoader sceneLoader;
    
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
            if (GameController.lives <= 1)
            {
                CreateEffectDestroy();
                Destroy(other.gameObject);
                Invoke("GameOver", 1f);
                // isDestroyed = true;
                GameController.isLose = true;
                Destroy(gameObject, 1.1f);

            } else
            {
                CreateEffectCollision();
                Destroy(other.gameObject);
                GameController.lives--;
            }
        }
        
        if (other.gameObject.tag == "ProjectileEnemy")
        {
            if (GameController.lives <= 1)
            {   

                CreateEffectDestroy();
                Destroy(other.gameObject);
                Invoke("GameOver", 1f);
                // isDestroyed = true;
                GameController.isLose = true;
                Destroy(gameObject, 1.1f);
            } else
            {
                CreateEffectCollision();
                Destroy(other.gameObject);
                GameController.lives--;
            }
        }
        
    }
    
    void GameOver()
    {
        sceneLoader.LoadGameOverScene();
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

        if (GameController.isLose || GameController.isWin) return;
        
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
            // audioSourceWinLose.clip = clip;
            // audioSourceWinLose.Play();
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
        else
        {
            audioSource.clip = clip;
            audioSource.Play();
        } 
    }
    
}
