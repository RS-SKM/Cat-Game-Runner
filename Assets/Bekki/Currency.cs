using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // this is is telling it that we need to use the UI system

// this script attaches to the textmeshpro component of the UI

public class Currency : MonoBehaviour
{
    [Tooltip("Stores the amount of currency the player has picked up")]
    public int coin; //this stores the amount of currency the player has picked up, accessible for other scripts
    [HideInInspector] public int sessionCoin; //won't show up in inspector


    private void Start()
    {
        DontDestroyOnLoad(gameObject); //this will make this object stick around whenever we change scenes (Will be put in it's own scene called "Dontdestroyonload" but the FindObjefct will still be able to find it)
    }

    public void IncreaseCurrency(int increase) //defining a function callable from somewhere else to increase the coins owned
    {
        coin += increase; //increases by the value given to by PickUpCoin
        if (coin < 0) //This is just making sure that it won't display a negative number of coins
        {
            coin = 0;
        }
        sessionCoin += increase;
    }

    public void DecreaseCurrency(int decrease)
    {
        coin -= decrease; //decreases by the value given to by ConfirmPurchase script
        if (coin < 0) //This is just making sure that it won't display a negative number of coins
        {
            coin = 0;
        }
    }

}
