using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField]
    private PlayerStatsController playerStats;

    [SerializeField]
    private TMP_Text currencyText;

    [SerializeField]
    private Slider healthbar;

    public void updateCurrency(int currency)
    {
        // update text value with the current currency value in player stats
        currencyText.text = $"Currency: {currency.ToString()}";
    }

    public void setMaxHealth(int maxHealth)
    {
        healthbar.maxValue = maxHealth;
        healthbar.value = maxHealth;
    }

    public void updateHealthBar(int health)
    {
        healthbar.value = health;
    }
}
