using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script needs to be attached to the individual coins to be picked up. The coin must always have a meshcollider with trigger selected

public class PickupCoin : MonoBehaviour
{
    Currency script; // storing a reference to the Currency script

    public int addAmount; // this public integer is the amount of currency that each coin instance will award the player. This can be set from the inspector

    void Start()
    {
        script = GameObject.FindWithTag("GameController").GetComponent<Currency>(); // This is looking for the object with the "GameController" tag.  
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {

            script.coin += addAmount;
            Destroy(gameObject);
        }
    }
}
