using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    TMPro.TextMeshProUGUI currencyUI; //This is the UI element that displays the number of currency the player has. If not using TextMeshPro, change <TMPro.TextMeshProUGUI> to <Text>
    Currency currency;
    void Start()
    {
        currencyUI = GetComponent<TMPro.TextMeshProUGUI>(); //If not using TextMeshPro, change <TMPro.TextMeshProUGUI> to <Text>
        currency = FindObjectOfType<Currency>();
    }
    private void Update() // should be an event, but since it woon't slow down our game enough to be a problem, its "fine" (totally a hack)
    {
        currencyUI.text = currency.ToString(); //This is getting the text component of the currencyUI variable (the UI text element) and setting it to be the number stored in the coin integer, converting the integer to a string.
    }
}
