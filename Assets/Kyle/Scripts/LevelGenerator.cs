using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update


    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200F;

    [SerializeField] private Transform levelPart_1;
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private GameObject player;

    private Vector3 lastEndPosition;

    private void Update()
    {
        //if (Vector3.Distance(player.transform.position, lastEndPosition);
    }



    void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        SpawnLevelPart();

        
       

    }

    private void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }



    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart_1, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }


}
