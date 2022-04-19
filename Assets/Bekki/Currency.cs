using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // this is is telling it that we need to use the UI system

// this script attaches to the textmeshpro component of the UI

public class Currency : MonoBehaviour
{
    [Tooltip("Stores the amount of currency the player has picked up")]
    public int coin; //this stores the amount of currency the player has picked up, accessible for other scripts

    TMPro.TextMeshProUGUI currencyUI; //This is the UI element that displays the number of currency the player has. If not using TextMeshPro, change <TMPro.TextMeshProUGUI> to <Text>
    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        currencyUI = GetComponent<TMPro.TextMeshProUGUI>(); //If not using TextMeshPro, change <TMPro.TextMeshProUGUI> to <Text>
    }

    public void IncreaseCurrency(int increase) //defining a function callable from somewhere else to increase the coins owned
    {
        coin += increase; //increases by the value given to by PickUpCoin
        currencyUI.text = coin.ToString(); //This is getting the text component of the currencyUI variable (the UI text element) and setting it to be the number stored in the coin integer, converting the integer to a string. 
        if (coin < 0) //This is just making sure that it won't display a negative number of coins in the UI
        {
            coin = 0;
        }
    }
}
