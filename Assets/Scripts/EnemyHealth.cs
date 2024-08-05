using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthSlider;

    [SerializeField] public Attribute hp;
    [SerializeField] public Enemy enemy;

    public float maxHealth = 100;
    public float currentHealth;

    void Start()
    {
        UpdateHealthBar();

        var hpStat = enemy.Get<Notifier>(hp);
        hpStat.onChange += UpdateHealthBar;
    }

    void UpdateHealthBar()
    {
        var hpStat = enemy.Get<Notifier>(hp);
        currentHealth = hpStat.Amount;

        if (healthSlider.value != currentHealth)
        {
            healthSlider.value = currentHealth;
        }
    }

}
