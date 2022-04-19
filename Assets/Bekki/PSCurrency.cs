using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // this is is telling it that we need to use the UI system

// this script attaches to the textmeshpro component of the UI

public class PSCurrency : MonoBehaviour
{
    [Tooltip("Stores the amount of currency the player has picked up")]
    public int coinPS; //this stores the amount of currency the player has picked up, accessible for other scripts

    TMPro.TextMeshProUGUI currencyPSUI; //This is the UI element that displays the number of currency the player has. If not using TextMeshPro, change <TMPro.TextMeshProUGUI> to <Text>
    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        currencyPSUI = GetComponent<TMPro.TextMeshProUGUI>(); //If not using TextMeshPro, change <TMPro.TextMeshProUGUI> to <Text>
    }

    public void PSIncreaseCurrency(int increase) //defining a function callable from somewhere else, storing the integer given to it when called
    {
        coinPS += increase; //increases by the value given to by PickUpCoin
        currencyPSUI.text = coinPS.ToString(); //This is getting the text component of the currencyUI variable (the UI text element) and setting it to be the number stored in the coin integer, converting the integer to a string. 
        if (coinPS < 0) //This is just making sure that it won't display a negative number of coins in the UI
        {
            coinPS = 0;
        }
    }
}
