using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class Combat : MonoBehaviour
{
    [SerializeField] Animator animator;
    //[SerializeField] Weapon weapon;
    [SerializeField] ThirdPersonController controller;
    [SerializeField] bool aiming;
    [SerializeField] bool attacking;

    private void OnValidate()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<ThirdPersonController>();
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

    //This function is called when the player presses LMB
    public void OnAttack()
    {
        if (attacking)
            return;

        //weapon = GetComponentInChildren<Weapon>();
        animator.SetTrigger("Attack");
    }

    public void OnAim(InputValue value)
    {
        aiming = value.isPressed;
        animator.SetBool("Aim", aiming);
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