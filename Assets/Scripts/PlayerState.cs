using System;
using UnityEngine;
using StarterAssets;

public abstract class PlayerState : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected Camera camera;
    [SerializeField] protected ThirdPersonController controller;

    public event Action<PlayerState> onEnter;


    public void OnValidate()
    {
        animator = GetComponent<Animator>();
    }

    public abstract void Setup();

    protected void Transition(PlayerState state)
    {
        if (enabled)
        {
            onEnter?.Invoke(state);

        }
    }
}
