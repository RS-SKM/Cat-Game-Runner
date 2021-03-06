using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform playerTransform;
    public int minCoins = 3, maxCoins = 8;
    public float spawnDistance = 20f;
    public float spacing = 1f;
    public float minSpawnTime = 1, maxSpawnTime = 2;
    public float minSpawnHeight = 1, maxSpawnHeight = 2;
    private float timer;

    void Start()
    {
        
    }


    // need a public variable that takes the player's position and adds horizontal distance to spawn the coin << this is in coin pickup script
    void Update()
    {
        timer -= Time.deltaTime; //setting time
        if (timer < 0)
        {
            SpawnCoins(Random.Range(minCoins, maxCoins)); //spawning a random amount of coins
            timer = Random.Range(minSpawnTime, maxSpawnTime); //spacing the chain of coins apart
        }
    }

    void SpawnCoins(int spawnAmount)
    {
        float height = Random.Range(minSpawnHeight, maxSpawnHeight); //how high to spawn the coins
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnPosition = new Vector3(playerTransform.position.x + spawnDistance + (i * spacing), height, 0); // takes the player location and adds spawn distance variable (1 will get higher the more that are spawned) plus spacing (on the X), with being = height, and Z remaining 0
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
