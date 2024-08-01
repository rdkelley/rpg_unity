using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class MainMenu : MonoBehaviour
{


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