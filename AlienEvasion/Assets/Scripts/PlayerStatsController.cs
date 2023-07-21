using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    public int currentCurrency;

    public int maxHealth;
    public int currentHealth;

    [SerializeField]
    private HudController hudController;

    // Start is called before the first frame update
    void Start()
    {
        currentCurrency = 0;

        maxHealth = 100;
        currentHealth = maxHealth;

        // set max health hud
        hudController.setMaxHealth(maxHealth);
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
}
