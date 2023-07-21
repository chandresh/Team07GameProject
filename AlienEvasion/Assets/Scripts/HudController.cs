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

    [SerializeField]
    private Slider fuelbar;

    public void updateCurrency(int currency)
    {
        // update text value with the current currency value in player stats
        currencyText.text = $"{currency.ToString()}";
    }

    // called from player stat controller on creation
    public void setMaxHealth(int maxHealth)
    {
        healthbar.maxValue = maxHealth;
        healthbar.value = maxHealth;
    }

    public void updateHealthBar(int health)
    {
        healthbar.value = health;
    }

    // called from player stat controller on creation
    public void setMaxFuel(int maxFuel)
    {
        fuelbar.maxValue = maxFuel;
        fuelbar.value = maxFuel;
    }

    public void updateFuel(int fuel)
    {
        fuelbar.value = fuel;
    }
}
