using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider manaSlider;

    public float maxMana = 100;
    public float currentMana;
    [SerializeField] int manaRegenRate;

    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;
        UpdateManaBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMana < maxMana)
        {
            currentMana += manaRegenRate * Time.deltaTime;
            currentMana = Mathf.Clamp(currentMana, 0f, maxMana);

            UpdateManaBar();
        }
    }

    void UpdateManaBar()
    {
        if (manaSlider.value != currentMana)
        {
            manaSlider.value = currentMana;
        }
    }

    public void UseMana(float amount)
    {
        currentMana -= amount;
        UpdateManaBar();

    }
}
