using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPurchaseButton : MonoBehaviour
{
    public GameObject confirmPurchase;
    public GameObject insufficientFunds;
    private Currency currency;
    public int cost;
    [Header("Appearance info")]
    public PlayerAppearance.ItemType itemType;
    public int itemIndex;

    void Start()
    {
        currency = FindObjectOfType<Currency>();
    }

    public void RunCheck()
    {
        //  Debug.Log("Checking currency");
        if (currency.coin >= cost)
        {
            confirmPurchase.SetActive(true);
            confirmPurchase.GetComponentInChildren<ConfirmPurchaseButton>().SetupButton(itemType, itemIndex);
        }
        else
        {
            insufficientFunds.SetActive(true);
        }


    }








    void Update()
    {
        
    }
}
