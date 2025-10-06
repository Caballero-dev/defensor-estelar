using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int necesaryPoints = 3;
    
    public static int points = 0;
    public TMP_Text pointsText;
    
    public static int lives = 3;
    public TMP_Text livesText;
    
    public static int enemylives = 3;
    public TMP_Text enemylivesText;
    
    public static bool isWin = false;
    public static bool isLose = false;
    
    public Camera mainCamera;
    public Camera secondCamera;
    
    // Start is called before the first frame update
    void Start()
    {
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
