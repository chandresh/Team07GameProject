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

    private int currentCurrency;
    private int currentHealth;
    private int currentShields;
    private int currentFuel;

    private void Start()
    {
        setMaxStats(100, 100, 100);
    }

    private void OnEnable()
    {
        //subscribe to delegates
        PlayerEventsManager.OnPlayerGotHit += updateHealthBar;
        PlayerEventsManager.OnPlayerGainsCurrency += updateCurrency;
        PlayerEventsManager.OnPlayerFuelChange += updateCurrency;
    }

    public void setMaxStats(int maxHealth, int maxShield, int maxFuel)
    {
        // set starting health values
        healthbar.maxValue = maxHealth;
        healthbar.value = maxHealth;
        currentHealth = maxHealth;

        // set starting fuel values
        fuelbar.maxValue = maxFuel;
        fuelbar.value = maxFuel;
        currentFuel = maxFuel;

        currentCurrency = 0;
    }

    public void updateCurrency(int currencyChange)
    {
        // update currency and reflect in UI
        currentCurrency += currencyChange;
        currencyText.text = $"{currentCurrency.ToString()}";
    }

    public void updateHealthBar(int healthChange)
    {
        currentHealth += healthChange;
        healthbar.value = currentHealth;
    }

    public void updateFuel(int fuelChange)
    {
        currentFuel += fuelChange;
        fuelbar.value = currentFuel;
    }
}
