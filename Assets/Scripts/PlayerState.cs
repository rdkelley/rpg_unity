using System;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    [SerializeField] protected Animator animator;

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
