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

    private int currentHealth;

    private void Start()
    {
        setMaxHealth(100);
    }

    private void OnEnable()
    {
        PlayerEventsManager.OnPlayerGotHit += updateHealthBar;
    }

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
        currentHealth = maxHealth;
    }

    public void updateHealthBar(int healthChange)
    {
        currentHealth += healthChange;
        healthbar.value = currentHealth;
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
