using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;

    [SerializeField] public Attribute hp;
    [SerializeField] public Player player;

    public float maxHealth = 100;
    public float currentHealth;

    void Start()
    {
        UpdateHealthBar();

        var hpStat = player.Get<Notifier>(hp);
        hpStat.onChange += UpdateHealthBar;
    }

    void UpdateHealthBar()
    {
        var hpStat = player.Get<Notifier>(hp);
        currentHealth = hpStat.Amount;

        if (healthSlider.value != currentHealth)
        {
            healthSlider.value = currentHealth;
        }
    }


}