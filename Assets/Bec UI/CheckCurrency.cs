using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCurrency : MonoBehaviour
{
    public GameObject confirmPurchase;
    public GameObject insufficientFunds;
    public Currency currency;
    public int cost;


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
