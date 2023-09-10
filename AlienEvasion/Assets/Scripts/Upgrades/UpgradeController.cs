﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeController : MonoBehaviour
{
    [SerializeField]
    private GameObject upgradeMenuCanvas;

    [SerializeField] private GameObject[] healthUpgradeBlocks;
    [SerializeField] private GameObject[] armourUpgradeBlocks;
    [SerializeField] private GameObject[] shieldUpgradeBlocks;
    [SerializeField] private GameObject[] shotSpeedUpgradeBlocks;
    [SerializeField] private GameObject[] turretUpgradeBlocks;
    [SerializeField] private GameObject[] airstrikeUpgradeBlocks;

    [SerializeField] private TMP_Text healthUpgradeText;
    [SerializeField] private TMP_Text shieldUpgradeText;
    [SerializeField] private TMP_Text armourUpgradeText;

    [SerializeField] private ShootTheShell shootTheShell; // Reference to the ShootTheShell script


    private bool isOpen;

    private int healthUpgradeLevel;
    private int armourUpgradeLevel;
    private int shieldUpgradeLevel;
    private int shotSpeedUpgradeLevel;
    private int turretUpgradeLevel;
    private int airstrikeUpgradeLevel;

    private int healthUpgradeCost;
    private int armourUpgradeCost;
    private int shieldUpgradeCost;
    private int shotSpeedUpgradeCost;
    private int turretUpgradeCost;
    private int airstrikeUpgradeCost;


    // Start is called before the first frame update
    private void Start()
    {
        // all upgrade levels start at 0
        healthUpgradeLevel = 0;
        armourUpgradeLevel = 0;
        shieldUpgradeLevel = 0;
        shotSpeedUpgradeLevel = 0;
        turretUpgradeLevel = 0;
        airstrikeUpgradeLevel = 0;

        // initial upgrade costs
        healthUpgradeCost = 50;
        armourUpgradeCost = 50;
        shieldUpgradeCost = 50;
        shotSpeedUpgradeCost = 50;
        turretUpgradeCost = 50;
        airstrikeUpgradeCost = 50;
    }

    private void Update()
    {
        // use escape for the pause menu
        if (Input.GetKeyDown(KeyCode.U))
        {
            isOpen = !isOpen;

            if (isOpen)
            {
                openUpgradeMenu();
            }
            else
            {
                closeUpgradeMenu();
            }
        }
    }

    public void healthUpgradePressed()
    {
        // make sure that upgrade isn't fully upgraded
        if (healthUpgradeLevel < 3)
        {
            // check player can afford upgrade
            if (checkCanAffordUpgrade(healthUpgradeCost))
            {
                // increase upgrade level
                healthUpgradeLevel++;

                changeBlockColour(healthUpgradeLevel - 1, healthUpgradeBlocks);

                // upgrade health
                UpgradeEventsManager.UpgradeHealth();

                // remove cost of upgrade
                PlayerEventsManager.PlayerGainsCurrency(-healthUpgradeCost);

                // increase cost for next upgrade
                healthUpgradeCost += 50;

                // reflect new cost in upgrade box
                updateCostText(healthUpgradeCost, healthUpgradeText);
            }
        }
    }

    public void armourUpgradePressed()
    {
        // make sure that upgrade isn't fully upgraded
        if (armourUpgradeLevel < 3)
        {
            // check player can afford upgrade
            if (checkCanAffordUpgrade(armourUpgradeCost))
            {
                // increase upgrade level
                armourUpgradeLevel++;

                changeBlockColour(armourUpgradeLevel - 1, armourUpgradeBlocks);

                // upgrade health
                UpgradeEventsManager.UpgradeArmour();

                // remove cost of upgrade
                PlayerEventsManager.PlayerGainsCurrency(-armourUpgradeCost);

                // increase cost for next upgrade
                armourUpgradeCost += 50;

                // reflect new cost in upgrade box
                updateCostText(armourUpgradeCost, armourUpgradeText);
            }
        }
    }

    public void shieldUpgradePressed()
    {
        // make sure that upgrade isn't fully upgraded
        if (shieldUpgradeLevel < 3)
        {
            // check player can afford upgrade
            if (checkCanAffordUpgrade(shieldUpgradeCost))
            {
                // increase upgrade level
                shieldUpgradeLevel++;

                changeBlockColour(shieldUpgradeLevel - 1, shieldUpgradeBlocks);

                // upgrade shield
                UpgradeEventsManager.UpgradeShield();

                // remove cost of upgrade
                PlayerEventsManager.PlayerGainsCurrency(-shieldUpgradeCost);

                // increase cost for next upgrade
                shieldUpgradeCost += 50;

                // reflect new cost in upgrade box
                updateCostText(shieldUpgradeCost, shieldUpgradeText);
            }
        }
    }

    public void shotSpeedUpgradePressed()
    {
        // make sure that upgrade isn't fully upgraded
        // check player can afford upgrade
        if (checkCanAffordUpgrade(shotSpeedUpgradeCost))
        {
            // Increase the upgrade level
            shotSpeedUpgradeLevel++;

            // Modify the fire delay based on the upgrade level (you can adjust this calculation)
            float newFireDelay = 0.5f - (shotSpeedUpgradeLevel * 0.1f);

            // Call the UpdateFireDelay method in the ShootTheShell script
            shootTheShell.UpdateFireDelay(newFireDelay);

            changeBlockColour(shotSpeedUpgradeLevel - 1, shotSpeedUpgradeBlocks);
        }
    }

    public void turretUpgradePressed()
    {
        // make sure that upgrade isn't fully upgraded
        if (turretUpgradeLevel < 3)
        {
            // increase upgrade level
            turretUpgradeLevel++;

            changeBlockColour(turretUpgradeLevel - 1, turretUpgradeBlocks);
        }
    }

    public void airstrikeUpgradePressed()
    {
        // make sure that upgrade isn't fully upgraded
        if (airstrikeUpgradeLevel < 3)
        {
            // increase upgrade level
            airstrikeUpgradeLevel++;

            changeBlockColour(airstrikeUpgradeLevel - 1, airstrikeUpgradeBlocks);
        }
    }

    private bool checkCanAffordUpgrade(int upgradeCost)
    {
        return upgradeCost < PlayerStatsController.currentCurrency;
    }

    private void changeBlockColour(int blockPosition, GameObject[] blocks)
    {
        blocks[blockPosition]
            .GetComponent<Image>()
            .color = new Color32(47, 120, 39, 255);
    }

    private void updateCostText(int newCost, TMP_Text textBlock)
    {
        textBlock.text = newCost.ToString();
    }

    private void openUpgradeMenu()
    {
        if (upgradeMenuCanvas != null)
        {
            // pause the game
            Time.timeScale = 0;

            // open the upgrade menu
            upgradeMenuCanvas.SetActive(true);
        }
    }

    private void closeUpgradeMenu()
    {
        if (upgradeMenuCanvas != null)
        {
            // close the upgrade menu
            upgradeMenuCanvas.SetActive(false);

            // restart game
            Time.timeScale = 1;
        }
    }

}
