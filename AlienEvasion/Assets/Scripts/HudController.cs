using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudController : MonoBehaviour
{
    [SerializeField]
    private PlayerStatsController playerStats;

    [SerializeField]
    private TMP_Text currencyText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateCurrency();        
    }

    void updateCurrency()
    {
        // update text value with the current currency value in player stats
        currencyText.text = $"Currency: {playerStats.currentCurrency.ToString()}";
    }
}
