using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 0; 
    }

    public void StartGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1; 
    }

    public void TogglePause()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1; 
        }
        else
        {
            gameObject.SetActive(true);
            Time.timeScale = 0; 
        }
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
