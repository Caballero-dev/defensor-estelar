using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int necesaryPoints = 3;
    
    public static int points;
    public TMP_Text pointsText;
    
    public static int lives;
    public TMP_Text livesText;
    
    public static int enemylives;
    public TMP_Text enemylivesText;
    
    public static bool isWin;
    public static bool isLose;
    
    public Camera mainCamera;
    public Camera secondCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        lives = 3;
        enemylives = 3;
        isWin = false;
        isLose = false;
        
        
        mainCamera.enabled = true;
        secondCamera.enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        SwitchCamera();
        UpdateUI();
    }
    
    void SwitchCamera()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            mainCamera.enabled = !mainCamera.enabled;
            secondCamera.enabled = !secondCamera.enabled;
        }
    }
    
    void UpdateUI() 
    {
        pointsText.text = points + " / " + necesaryPoints;
        livesText.text = "Vida: " + lives;
        
        enemylivesText.text = "Vida: " + enemylives;
    }
    
}
