using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider manaSlider;

    [SerializeField] public Attribute mana;
    [SerializeField] public Player player;

    public float maxMana = 100;
    public float currentMana;


    // Start is called before the first frame update
    void Start()
    {
        var manaStat = player.Get<Notifier>(mana);
        manaStat.onChange += UpdateManaBar;

        UpdateManaBar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateManaBar()
    {
  
        var manaStat = player.Get<Notifier>(mana);
        currentMana = manaStat.Amount;

        if (manaSlider.value != currentMana)
        {
            manaSlider.value = currentMana;
        }
    }
}
