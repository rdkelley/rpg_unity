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
        menu.SetActive(menuOpen);
    }

    public void ToggleMenu()
    {
        Debug.Log("ToggleMenu" + menuOpen);

        if (menuOpen)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

    void OpenMenu()
    {
        menu.SetActive(true);
        menuOpen = true;
        Time.timeScale = 0f;
    }

    void CloseMenu()
    {
        menu.SetActive(false);
        menuOpen = false;
        Time.timeScale = 1f;
    }
}
