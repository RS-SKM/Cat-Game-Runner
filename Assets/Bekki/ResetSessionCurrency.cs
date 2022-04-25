using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSessionCurrency : MonoBehaviour
{
    private Currency currency;


    // Start is called before the first frame update
    void Start()
    {
        currency = FindObjectOfType<Currency>();
    }

    public void ResetCurrency()
    {
        currency.sessionCoin = 0;
    }
}
