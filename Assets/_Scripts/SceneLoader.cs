using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
    
    public void LoadInfoScene()
    {
        SceneManager.LoadScene("InfoScene");
    }
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameLevel");
    }
    
    public void LoadGameWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    
}
