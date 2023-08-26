using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeEventsManager : MonoBehaviour
{
    public static event Action OnHealthUpgrade;
    public static event Action onArmourUpgrade;
    public static event Action OnShieldUpgrade;
    public static event Action OnShotSpeedUpgrade;
    public static event Action OnTurretUpgrade;
    public static event Action OnAirstrikeUpgrade;

    public static void UpgradeHealth()
    {
        OnHealthUpgrade?.Invoke();
    }


    public static void UpgradeArmour()
    {
        onArmourUpgrade?.Invoke();
    }

    public static void UpgradeShield()
    {
        OnShieldUpgrade?.Invoke();
    }

    public static void UpgradeShotSpeed()
    {
        OnShotSpeedUpgrade?.Invoke();
    }

    public static void UpgradeTurret()
    {
        OnTurretUpgrade?.Invoke();
    }

    public static void UpgradeAirstrike()
    {
        OnAirstrikeUpgrade?.Invoke();
    }
}
