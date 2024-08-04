using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class XpBar : MonoBehaviour
{
    public Slider xpSlider;

    [SerializeField] public Attribute xp;
    [SerializeField] public Player player;

    public float maxXp = 100;
    public float currentXp;

    // Start is called before the first frame update
    void Start()
    {
        UpdateXpBar();

        var xpStat = player.Get<Notifier>(xp);
        xpStat.onChange += UpdateXpBar;
    }

    void UpdateXpBar()
    {
        var xpStat = player.Get<Notifier>(xp);

        if (xpSlider.value != xpStat.Amount)
        {
            xpSlider.value = xpStat.Amount;
        }
    }
}
