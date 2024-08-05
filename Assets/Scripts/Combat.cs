using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using StarterAssets;

public class Combat : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Weapon weapon;
    [SerializeField] ThirdPersonController controller;
    [SerializeField] bool aiming;
    [SerializeField] bool attacking;
    [SerializeField] private CinemachineVirtualCamera aimCamera;

    [SerializeField] int manaUsedDart;

    [SerializeField] Player player;

    PlayerInput playerInput;

    Vector3 aimDirection;
    Vector3 aimHitPoint;

    RaycastHit hit;

    public Camera camera;

    private void OnValidate()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<ThirdPersonController>();
        playerInput = GetComponent<PlayerInput>();

        aimDirection = Vector3.zero;
        aimHitPoint = Vector3.zero;
    }

    bool Attacking
    {
        set
        {
            attacking = value;

            //Disable the controller so the character does not move while attacking
            controller.enabled = !value;
        }
    }

    private void Update()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        if (aiming)
        {
            aimCamera.gameObject.SetActive(true);

            Ray ray = Camera.main.ScreenPointToRay(screenCenter);

            if (Physics.Raycast(ray, out hit, 1000))
            {
                aimHitPoint = hit.point;
            }

            aimDirection = (aimHitPoint - aimCamera.gameObject.transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 30);
        }
        else
        {
            aimCamera.gameObject.SetActive(false);
        }
    }

    //This function is called when the player presses LMB
    public void OnAttack()
    {
        if (attacking)
            return;

        Enemy enemy;

        controller.enabled = false;


        if (aiming)
        {
            Debug.Log("Sleep dart fired at: " + hit.collider);

            player.UseMana(manaUsedDart);

            if (hit.collider)
            {
                enemy = hit.collider.GetComponent<Enemy>();

                if (enemy)
                {
                    enemy.Sleep();
                }
            }

        }
        else
        {
            weapon = GetComponentInChildren<Weapon>();

            animator.SetTrigger("Attack");
        }
    }

    public void AttackAnimationFinish()
    {
        if (!controller.enabled)
        {
            controller.enabled = true;
        }

        if (weapon)
        {
            weapon.Activate();
        }
        
    }

    public void OnAim(InputValue value)
    {
        aiming = value.isPressed;
        animator.SetBool("Aim", aiming);

        if (value.isPressed)
        {

            playerInput.actions.FindAction("Move").Disable();
        }
        else
        {
            playerInput.actions.FindAction("Move").Enable();
        }
    }

    //An animation event raised when the sword can damage others
    public void Draw()
    {
        Attacking = true;
        //weapon.Activate();
    }

    //An animation event raised when attack animation is done
    public void Sheathe()
    {
        //weapon.Deactivate();
        Attacking = false;
        animator.ResetTrigger("Attack");
    }
}