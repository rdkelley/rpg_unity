using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class CharMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] public bool menuOpen;

    [SerializeField] ThirdPersonController controller;
    [SerializeField] StarterAssetsInputs playerInput;
    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(menuOpen);
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

    public void ToggleMenu()
    {
        if (menuOpen)
        {
            HideCursor();

            controller.enabled = true;

            CloseMenu();
        }
        else
        {
            ShowCursor();

            controller.enabled = false;

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
