using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip01Controller : MonoBehaviour
{
    [Header("Configuración de Nave Enemiga")]
    public float movementSpeed = 0.5f;
    // public static int lives = 3;
    // public int lives = 3;
    private int initialLives;
    
    
    [Header("Configuración de Disparo")]
    [Tooltip("Marca esta casilla para activar el disparo múltiple.")]
    public bool isMultipleProjectile = false;
    public GameObject projectilePrefab;
    
    [Header("Configuración de Proyectil Unico")]
    public GameObject posProjectile;
    
    [Header("Configuración de Proyectil Derecha e Izquierda")]
    public GameObject posProjectileLeft;
    public GameObject posProjectileRight;
    
    // Audio
    [Header("Audio Source")]
    private AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip impactProjectileSound;
    public AudioClip destroyShipSound;
    
    [Header("Configuración de Disparo")]
    public int initialDelay = 2;
    public int shootInterval = 2;
    
    [Header("Efectos Visuales")]
    public GameObject effectImpactProjectilePrefab;
    public GameObject effectDestroyPrefab;
    public GameObject effectStopShipPrefab;
    public GameObject effectStartShipPrefab;
    
    private Transform player;
    private GameObject playerObject;
    private bool isDestroyed = false;
    
    // private GameObject oldGameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        // audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();
        playerObject = GameObject.Find("PlayerShip");
        player = playerObject.GetComponent<Transform>();
        initialLives = GameController.enemylives;
        
        InvokeRepeating("Shoot", initialDelay, shootInterval);
    }

    // Update is called once per frame
    void Update()
    {
        Moviement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ProjectilePlayer")
        {
            if (GameController.enemylives <= 1)
            {
                isDestroyed = true;
                // oldGameObject = gameObject;
                CreateSound(destroyShipSound);
                Destroy(other.gameObject);
                CreateEffectDestroy();
                // GameObject effect = CrateEffectStopShip();
                // effect.transform.parent = this.transform;
                // Destroy(effect, 5f);

                GameController.lives++;
                GameController.enemylives = 0;
                CrateEffectStopShip();
                // Destroy(gameObject, 1f);
                // Invoke("ChangePosition", 3f);

            }
            else
            {
                CreateEffectCollision();
                Destroy(other.gameObject);
                GameController.enemylives--;
            }
        }
    }
    
    // void ChangePosition()
    // {
    //     lives = 3;
    //     isDestroyed = false;
    //     transform.position = new Vector3(player.position.x - 0.5f, transform.position.y, player.position.z - 0.5f);
    //     gameObject.SetActive(true);
    // }
    
    void ReviveShip()
    {
        if (movementSpeed <= 3f)
        {
            movementSpeed += 0.2f;
        }

        if (initialLives <= 8)
        {
            GameController.enemylives = initialLives + 1;
        }
        else
        {
            GameController.enemylives = initialLives;
        }
        initialLives = GameController.enemylives;
        
        isDestroyed = false;
    }
    
    void CrateEffectStopShip()
    {
        GameObject effect = Instantiate(effectStopShipPrefab, transform.position, effectStopShipPrefab.transform.rotation);
        effect.transform.parent = this.transform;
        Destroy(effect, 6.5f);
        Invoke("CreateStartEffect", 7f);
    }
    
    void CreateStartEffect()
    {
        GameObject effectStart = Instantiate(effectStartShipPrefab, transform.position, effectStartShipPrefab.transform.rotation);
        effectStart.transform.parent = this.transform;
        Destroy(effectStart, 6.5f);
        Invoke("ReviveShip", 7f);
        
    }

    
    void CreateEffectCollision()
    {
        CreateSound(impactProjectileSound);
        Instantiate(effectImpactProjectilePrefab, transform.position, effectImpactProjectilePrefab.transform.rotation);
    }
    
    void CreateEffectDestroy()
    {
        Instantiate(effectDestroyPrefab, transform.position, effectDestroyPrefab.transform.rotation);
    }

    void Moviement()
    {
        // Verifica que el jugador aún exista
        if (player == null || playerObject == null || isDestroyed || GameController.isWin || GameController.isLose) return;
        
        // Almacena las posiciones x y z del jugador
        Vector3 posJugador = new Vector3(player.position.x, transform.position.y, player.position.z);
        // LookAt hace que el apunte a un posicion ( Posicion del jugador)
        transform.LookAt(posJugador);
        // Translada el objeto hacia adelante (forward)
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        if (player == null || playerObject == null || isDestroyed || GameController.isWin || GameController.isLose) return;
        
        CreateSound(shootSound);
        if (!isMultipleProjectile)
        {
            ShootSingleProjectile();
        }
        else
        {
            ShootMultipleProjectiles();
        }
    }
    
    void ShootSingleProjectile()
    {
        Instantiate(projectilePrefab, posProjectile.transform.position, posProjectile.transform.rotation);
    }
    
    void ShootMultipleProjectiles()
    {
        Instantiate(projectilePrefab, posProjectileLeft.transform.position, posProjectileLeft.transform.rotation);
        Instantiate(projectilePrefab, posProjectileRight.transform.position, posProjectileRight.transform.rotation);
    }
    
    void CreateSound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    
}
