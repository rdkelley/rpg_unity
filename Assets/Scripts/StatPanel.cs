using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI manaText;
    [SerializeField] TextMeshProUGUI xpText;
    [SerializeField] TextMeshProUGUI defText;

    [SerializeField] public Player player;

    [SerializeField] Attribute hp;
    [SerializeField] Attribute mana;
    [SerializeField] Attribute xp;
    [SerializeField] Attribute defense;

    // Start is called before the first frame update
    void Start()
    {
        var hpStat = player.Get<Notifier>(hp);
        var manaStat = player.Get<Notifier>(mana);
        var xpStat = player.Get<Notifier>(xp);

        var defStat = player.Get<Stats>(defense);

        hpStat.onChange += UpdateHealthText;
        manaStat.onChange += UpdateManaText;
        xpStat.onChange += UpdateXpText;
        defStat.onChange += UpdateDefText;

        if (defStat != null) UpdateDefText(defStat.Amount);
    }

    void UpdateHealthText()
    {
        var stat = player.Get<Notifier>(hp);
        var current = stat.Amount;

        hpText.text = current.ToString();
    }

    void UpdateManaText()
    {

        var manastat = player.Get<Notifier>(mana);
        var current = manastat.Amount;

        manaText.text = Math.Round(current).ToString();
    }

    void UpdateXpText()
    {
        var stat = player.Get<Notifier>(xp);
        var current = stat.Amount;

        xpText.text = current.ToString();
    }

    void UpdateDefText(float def)
    {
        var stat = player.Get<Stats>(defense);
        var current = stat.Amount;

        defText.text = current.ToString();
    }
}
