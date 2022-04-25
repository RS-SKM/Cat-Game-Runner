using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmPurchaseButton : MonoBehaviour
{
    public PlayerAppearance playerAppearance;
    public GameObject confirmPurchase;
    [HideInInspector]public PlayerAppearance.ItemType assignedType; // this is the avriable that will store the item's assigned type
    [HideInInspector]public int assignedIndex; // this is the variable to store the item's assigned index
    [HideInInspector]public int itemCost; // the variable to store the cost of the item
    [HideInInspector]public Currency currency;


    private void Start()
    {
        playerAppearance = FindObjectOfType<PlayerAppearance>();
        currency = FindObjectOfType<Currency>();
    }

    public void SetupButton(PlayerAppearance.ItemType itemType, int itemIndex, int cost) // this function is called by the item purchase button
    {
        assignedType = itemType;
        assignedIndex = itemIndex;
        itemCost = cost;

    }

    public void BuyItem()
    {
        playerAppearance.SetAppearance(assignedType, assignedIndex); //running the function in the playerAppearance script
        currency.DecreaseCurrency(itemCost); //this runs the decrease currency function, removing the cost of the item from the currency value
        confirmPurchase.SetActive(false); //this turns off the confirm purchase screen
    }


}