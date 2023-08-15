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

        maxShield = 100;
        currentShield = 0;

        // set max health in hud
        hudController.setMaxHealth(maxHealth);

        // set max fuel in hud
        hudController.setMaxFuel(maxFuel);
    }

    private void OnEnable()
    {
        PlayerEventsManager.OnPlayerGotHit += healthChange;
    }

    private void healthChange(int amount)
    {
        Debug.Log(amount);
        currentHealth += amount;
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
    }

    public void changFuel(int fuelToChange)
    {
        currentFuel += fuelToChange;

        // display changes in fuel on the hud
        hudController.updateFuel(currentFuel);
    }
}
