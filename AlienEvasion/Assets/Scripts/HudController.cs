using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text currencyText;

    [SerializeField]
    private Slider healthbar;

    [SerializeField]
    private Slider fuelbar;

    [SerializeField]
    private Slider shieldBar;

    private void Start()
    {
        setMaxStats(100, 100, 100);
    }

    private void OnEnable()
    {
        //subscribe to delegates
        PlayerStatsController.SetPlayerHealth += updateHealthBar;
        PlayerStatsController.SetPlayerFuel += updateFuelBar;
        PlayerStatsController.SetPlayerCurrency += updateCurrencyText;

        // events triggered from upgrades
        PlayerStatsController.ChangePlayerMaxHealth += updateMaxHealth;
    }

    private void setMaxStats(int maxHealth, int maxShield, int maxFuel)
    {
        // set starting health values
        healthbar.maxValue = maxHealth;
        healthbar.value = maxHealth;

        // set starting fuel values
        fuelbar.maxValue = maxFuel;
        fuelbar.value = maxFuel;

        shieldBar.maxValue = maxShield;
        shieldBar.value = 0;

        currencyText.text = "0";
    }

    private void updateCurrencyText(int currentCurrency)
    {
        currencyText.text = $"{currentCurrency.ToString()}";
    }

    private void updateHealthBar(int currentHealth, int currentShield)
    {
        healthbar.value = currentHealth;
        shieldBar.value = currentShield;
    }

    private void updateFuelBar(int currentFuel)
    {
        fuelbar.value = currentFuel;
    }

    private void updateShieldBar(int currentShield)
    {
        shieldBar.value = currentShield;
    }

    private void updateMaxHealth(int newMaxHealth)
    {
        healthbar.maxValue = newMaxHealth;
    }
}
