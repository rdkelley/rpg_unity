using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] public bool menuOpen;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
    }

    public void ToggleMenu()
    {
        if (menuOpen)
        {
            Resume();
            menuOpen = false;
        }
        else
        {
            Pause();
            menuOpen = true;
        }
    }

    void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
    }

    void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }
}
