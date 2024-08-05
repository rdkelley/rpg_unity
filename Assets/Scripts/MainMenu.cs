using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
        ShowCursor();
    }

    void OnEnable()
    {
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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