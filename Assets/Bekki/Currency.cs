using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // this is is telling it that we need to use the UI system

// This script needs to be attached to the EventSystem

public class Currency : MonoBehaviour
{
    [Tooltip("Stores the amount of currency the player has picked up")]
    public int coin; //this stores the amount of currency the player has picked up, accessible for other scripts

    GameObject currencyUI; //This is the UI element that displays the number of currency the player has
    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        currencyUI = GameObject.Find("Currency"); //The word in the quotation marks must be the name of the UI text element that is displaying the currency count on the UI.
    }
    void Update ()
    {
        currencyUI.GetComponent<TMPro.TextMeshProUGUI>().text = coin.ToString(); //This is getting the text component of the currencyUI variable (the UI text element) and setting it to be the number stored in the coin integer, converting the integer to a string. If not using TextMeshPro, change <TMPro.TextMeshProUGUI> to <Text>
        if (coin < 0) //This is just making sure that it won't display a negative number of coins in the UI
        {
            coin = 0;
        }
    }

}
