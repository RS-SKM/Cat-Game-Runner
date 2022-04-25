using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyIndicatorsUI : MonoBehaviour
{
    TMPro.TextMeshProUGUI currencyUI; //This is the UI element that displays the number of currency the player has. If not using TextMeshPro, change <TMPro.TextMeshProUGUI> to <Text> 
    Currency currency;
    public enum CoinType 
    {
        TotalCoins,
        SessionCoins
    }

    public CoinType coinType; //this tells the text component which variable to use to update its text



    void Start()
    {
        currencyUI = GetComponent<TMPro.TextMeshProUGUI>(); //If not using TextMeshPro, change <TMPro.TextMeshProUGUI> to <Text>. This is getting the TextMeshPro component the script is attached to
        currency = FindObjectOfType<Currency>();
    }
    private void Update() // should be an event, but since it woon't slow down our game enough to be a problem, its "fine" (totally a hack)
    {

        if (coinType == CoinType.TotalCoins)
        {
            currencyUI.text = currency.coin.ToString(); //This is getting the text component of the currencyUI variable (the UI text element) and setting it to be the number stored in the coin integer, converting the integer to a string.
        }
        else if (coinType == CoinType.SessionCoins)
        {
            currencyUI.text = currency.sessionCoin.ToString();
        }
    }
}
