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

    [SerializeField]
    private HudController hudController;

    // Start is called before the first frame update
    void Start()
    {
        currentCurrency = 0;

        maxHealth = 100;
        currentHealth = maxHealth;

        maxFuel = 100;
        currentFuel = maxFuel;

        // set max health in hud
        hudController.setMaxHealth(maxHealth);

        // set max fuel in hud
        hudController.setMaxFuel(maxFuel);
    }

    public void increaseCurrency(int amountToChange)
    {
        // update currency
        currentCurrency += amountToChange;

        // change currency in hud
        hudController.updateCurrency(currentCurrency);
    }

    public void changeHealth(int amountToChange)
    {
        // set current health
        currentHealth += amountToChange;

        // display changes in current health on health bar
        hudController.updateHealthBar(currentHealth);
    }

    public void changFuel(int fuelToChange)
    {
        currentFuel += fuelToChange;

        // display changes in fuel on the hud
        hudController.updateFuel(currentFuel);
    }
}
