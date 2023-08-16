using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    private int healthUpgradeLevel;
    private int armourUpgradeLevel;
    private int shieldUpgradeLevel;
    private int shotSpeedUpgradeLevel;
    private int turrentUpgradeLevel;
    private int airstrikeUpgradeLevel;

    // Start is called before the first frame update
    void Start()
    {
        // all upgrade levels start at 0
        healthUpgradeLevel = 0;
        armourUpgradeLevel = 0;
        shieldUpgradeLevel = 0;
        shotSpeedUpgradeLevel = 0;
        turrentUpgradeLevel = 0;
        airstrikeUpgradeLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
