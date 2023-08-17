using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField]
    private GameObject upgradeMenuCanvas;

    private bool isOpen;

    private int healthUpgradeLevel;
    private int armourUpgradeLevel;
    private int shieldUpgradeLevel;
    private int shotSpeedUpgradeLevel;
    private int turrentUpgradeLevel;
    private int airstrikeUpgradeLevel;

    // Start is called before the first frame update
    private void Start()
    {
        // all upgrade levels start at 0
        healthUpgradeLevel = 0;
        armourUpgradeLevel = 0;
        shieldUpgradeLevel = 0;
        shotSpeedUpgradeLevel = 0;
        turrentUpgradeLevel = 0;
        airstrikeUpgradeLevel = 0;
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

    //public void healthUpgradePressed()
    //{
    //    // make sure that upgrade isn't fully upgraded
    //    if(healthUpgradeLevel < 3)
    //    {
    //        Debug.Log("healthUpgradePressed");
    //    }
    //}

    private void openUpgradeMenu()
    {
        // pause the game
        Time.timeScale = 0;

        // open the upgrade menu
        upgradeMenuCanvas.SetActive(true);
    }

    private void closeUpgradeMenu()
    {
        // close the upgrade menu
        upgradeMenuCanvas.SetActive(false);

        // restart game
        Time.timeScale = 1;
    }

}
