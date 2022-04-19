using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float depth = 1;
    public GameObject backgroundPrefab;
    public Transform backgroundSpawn;
    bool backgroundCreated = false;

    Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Update()
    {
        if (!backgroundCreated)
        {
            Vector2 pos = transform.position;
            if (pos.x <= -42)
            {
                CreateBackground();
                backgroundCreated = true;            
            }

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float realVelocity = player.velocity.x / depth;
        Vector2 pos = transform.position;
        pos.x -= realVelocity * Time.fixedDeltaTime;
        transform.position = pos;
    }

    void CreateBackground()
    {
        Instantiate(backgroundPrefab, backgroundSpawn.position, backgroundSpawn.rotation);
    }
}
