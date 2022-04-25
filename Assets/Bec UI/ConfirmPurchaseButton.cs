using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmPurchaseButton : MonoBehaviour
{
    public PlayerAppearance playerAppearance;
    public GameObject confirmPurchase;
    public PlayerAppearance.ItemType assignedType; // everytime a button is clicked this will setup the type
    public int assignedIndex; // this is deciding what the index of the item (from PlayerAppearance enums) is


    private void Start()
    {
        playerAppearance = FindObjectOfType<PlayerAppearance>();
    }

    public void SetupButton(PlayerAppearance.ItemType itemType, int itemIndex) // this function is called by the item buy button
    {
        assignedType = itemType;
        assignedIndex = itemIndex;
    }

    public void BuyItem()
    {
        playerAppearance.SetAppearance(assignedType, assignedIndex); //running the function in the playerAppearance script
        confirmPurchase.SetActive(false);
    }


}