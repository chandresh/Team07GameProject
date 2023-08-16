using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    private int currentCurrency;

    private int maxHealth;
    private int currentHealth;

    private int maxFuel;
    private int currentFuel;

    private int maxShield;
    private int currentShield;

    public static event Action<int> SetPlayerFuel;
    public static event Action<int, int> SetPlayerHealth;
    public static event Action<int> SetPlayerCurrency;

    // Start is called before the first frame update
    void Start()
    {
        currentCurrency = 0;

        maxHealth = 100;
        currentHealth = maxHealth;

        maxFuel = 100;
        currentFuel = maxFuel;

        maxShield = 100;
        currentShield = 0;
    }

    private void OnEnable()
    {
        PlayerEventsManager.OnPlayerGotHit += healthChange;
        PlayerEventsManager.OnPlayerFuelChange += changeFuel;
        PlayerEventsManager.OnPlayerGainsCurrency += increaseCurrency;

        AlienEventsManager.OnAlienGotHit += increaseCurrencyFromAlienHit;
    }

    private void increaseCurrencyFromAlienHit()
    {
        increaseCurrency(10);
        Debug.Log("hit alien");
    }

    private void healthChange(int healthChange)
    {
        if (currentShield > 0)
        {
            // the player has some shields to take form first
            if (currentShield > healthChange)
            {
                // shield can take all the damage taken
                currentShield += healthChange;
            }
            else
            {
                // shields can only take some of the damage
                healthChange += currentShield;
                currentShield = 0;
                currentHealth += healthChange;
            }
        }
        else
        {
            // player has no shields
            currentHealth += healthChange;
        }

        SetPlayerHealth?.Invoke(currentHealth, currentShield);
    }

    private void increaseCurrency(int amountToChange)
    {
        currentCurrency += amountToChange;

        SetPlayerCurrency?.Invoke(currentCurrency);
    }


    public void changeFuel(int fuelToChange)
    {
        currentFuel += fuelToChange;

        SetPlayerFuel?.Invoke(currentFuel);
    }
}
