using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    static public int currentCurrency;

    private int maxHealth;
    private int currentHealth;

    private int maxFuel;
    private int currentFuel;

    private int maxShield;
    private int currentShield;

    private int currentArmour;

    public static event Action<int> SetPlayerFuel;
    public static event Action<int, int> SetPlayerHealth;
    public static event Action<int> SetPlayerCurrency;

    // upgrade events
    public static event Action<int> ChangePlayerMaxHealth;

    private AudioManager am;
    [SerializeField] SpriteRenderer tankSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        am = FindObjectOfType<AudioManager>();
        currentCurrency = 0;

        maxHealth = 100;
        currentHealth = maxHealth;

        maxFuel = 100;
        currentFuel = maxFuel;

        maxShield = 0;
        currentShield = 0;

        currentArmour = 0;
    }

    private void OnEnable()
    {
        PlayerEventsManager.OnPlayerGotHit += healthChange;
        PlayerEventsManager.OnPlayerFuelChange += changeFuel;
        PlayerEventsManager.OnPlayerGainsCurrency += increaseCurrency;

        AlienEventsManager.OnAlienGotHit += increaseCurrencyFromAlienHit;

        // upgrade events
        UpgradeEventsManager.OnHealthUpgrade += healthUpgraded;
        UpgradeEventsManager.OnShieldUpgrade += shieldUpgraded;
        UpgradeEventsManager.onArmourUpgrade += armourUpgraded;
    }

    private void OnDisable()
    {
        PlayerEventsManager.OnPlayerGotHit -= healthChange;
        PlayerEventsManager.OnPlayerFuelChange -= changeFuel;
        PlayerEventsManager.OnPlayerGainsCurrency -= increaseCurrency;

        AlienEventsManager.OnAlienGotHit -= increaseCurrencyFromAlienHit;

        // upgrade events
        UpgradeEventsManager.OnHealthUpgrade -= healthUpgraded;
        UpgradeEventsManager.OnShieldUpgrade -= shieldUpgraded;
        UpgradeEventsManager.onArmourUpgrade -= armourUpgraded;
    }

    private void armourUpgraded()
    {
        currentArmour++;
    }

    private void healthUpgraded()
    {
        // increase players maximum health
        maxHealth += 20;

        ChangePlayerMaxHealth?.Invoke(maxHealth);
    }

    private void shieldUpgraded()
    {
        // Debug.Log("called");
        // increase max shield
        maxShield += 20;
        currentShield = maxShield;

        SetPlayerHealth?.Invoke(currentHealth, currentShield);
    }

    private void increaseCurrencyFromAlienHit()
    {
        increaseCurrency(10);
        // Debug.Log("hit alien");
    }

    private void healthChange(int healthChange)
    {
        // remove current armour value from incoming damage
        int incDamage = healthChange -= currentArmour;
        StartCoroutine(IndicateDamage());
        if (currentShield > 0)
        {
            // the player has some shields to take form first
            if (currentShield > incDamage)
            {
                // shield can take all the damage taken
                currentShield += incDamage;
            }
            else
            {
                // shields can only take some of the damage
                incDamage += currentShield;
                currentShield = 0;
                currentHealth += incDamage;
            }
        }
        else
        {
            // player has no shields
            currentHealth += incDamage;
        }

        // if currentHealth is less than or equal to 0 then broadcast player death
        if (currentHealth <= 0)
        {
            GameManager.PlayerDied();
        }

        SetPlayerHealth?.Invoke(currentHealth, currentShield);
    }
    IEnumerator IndicateDamage()
    {
        // Color the tank body red for a short duration to indicate damage
        tankSpriteRenderer.color = Color.red;
        // Wait for 0.2 seconds
        yield return new WaitForSeconds(0.2f);
        // Change the color back to white
        tankSpriteRenderer.color = Color.white;
    }

    private void increaseCurrency(int amountToChange)
    {
        currentCurrency += amountToChange;

        SetPlayerCurrency?.Invoke(currentCurrency);
        if (am.isPlaying("score")) am.Play("score");
    }


    public void changeFuel(int fuelToChange)
    {
        currentFuel += fuelToChange;

        SetPlayerFuel?.Invoke(currentFuel);
    }

    public void ResetPlayerState()
    {
        // Reset the player's health, fuel, shields, and any other relevant state here
        currentHealth = maxHealth;
        currentFuel = maxFuel;
        currentShield = maxShield;
        currentArmour = 0;

        // Reset any other player-related state as needed

    }

}
