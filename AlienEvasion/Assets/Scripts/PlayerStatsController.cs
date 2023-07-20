using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    public int currentCurrency;

    // Start is called before the first frame update
    void Start()
    {
        currentCurrency = 0;
    }

    public void increaseCurrency(int amount)
    {
        currentCurrency += amount;
    }
}
