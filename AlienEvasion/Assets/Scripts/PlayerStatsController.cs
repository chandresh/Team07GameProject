using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    public int currentCurrency;

    public int maxHealth;
    public int currentHealth;

    public int maxFuel;
    public int currentFuel;

    public int maxShield;
    public int currentShield;

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
    }

    private void healthChange(int amount)
    {
        currentHealth += amount;
    }

    public void increaseCurrency(int amountToChange)
    {
        currentCurrency += amountToChange;
    }

    public void changeFuel(int fuelToChange)
    {
        currentFuel += fuelToChange;
    }
}
