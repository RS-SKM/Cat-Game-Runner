using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script needs to be attached to the individual coins to be picked up. The coin must always have a meshcollider with trigger selected

public class PickupCoin : MonoBehaviour
{
    //Currency script; // storing a reference to the Currency script

    public int coinValue; // this public integer is the amount of currency that each coin instance will award the player. This can be set from the inspector
    Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); //finding the game object called "Player", then checking for script componenet "Player"   
    }

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player") //player colliding with the coin, adding the coin value tot he currency counter, and destroying the coin
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Coin/CoinP", GetComponent<Transform>().position);//plays the soundeffect of picking up the coin
            //GameObject.FindObjectOfType<PSCurrency>().PSIncreaseCurrency(coinValue); //find the PScurrency script and then call the function, giving it the coinvalue value
            GameObject.FindObjectOfType<Currency>().IncreaseCurrency(coinValue); //find the currency script and then call the function, giving it the coinvalue value
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position; //getting the position of the coin

        pos.x -= player.velocity.x * Time.fixedDeltaTime; //setting the x position of the coin opposite to the player x velocity over time
        if (pos.x < -100)
        {
            Destroy(gameObject); //if the coin passes this distance, destroy it
        }

        transform.position = pos; //moving the coin depending on its x position
    }

}
