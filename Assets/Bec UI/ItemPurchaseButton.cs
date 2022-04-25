using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPurchaseButton : MonoBehaviour
{
    public GameObject confirmPurchase; //storing a reference to the confirmpurchase object
    public GameObject insufficientFunds; //storing a reference to the insufficientfunds object
    private Currency currency; //storing a reference to the currency script
    [Header("Asset item's info")]
    public int cost; //the cost of the item, settable in the inspector
    public PlayerAppearance.ItemType itemType; //the enum value of the item (skin, hat, gun)
    public int itemIndex; //the enum index number (which version of the type is it, eg red skin, blue skin, green skin)

    void Start()
    {
        currency = FindObjectOfType<Currency>();
    }

    public void RunCheck() //this function checks to make sure the player has enough currency to purchase the item, if they do, the confirm purchase screen is activated, and the setupbutton function is run, otherwise the insufficient funds screen is activated
    {
        //  Debug.Log("Checking currency");
        if (currency.coin >= cost)
        {
            confirmPurchase.SetActive(true);
            confirmPurchase.GetComponentInChildren<ConfirmPurchaseButton>().SetupButton(itemType, itemIndex, cost); //this parses these variables to the setup button function
        }
        else
        {
            insufficientFunds.SetActive(true);
        }


    }
}
