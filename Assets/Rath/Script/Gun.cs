using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public int shot;
    public bool coolDown = false;
    public float timeRemaining = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0) 
        {
            timeRemaining -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(!coolDown) 
            {
                if(timeRemaining <= 0) //if the player have not shoot in the last 1.5 second, reset shot to 0
                {
                    shot = 0;
                    timeRemaining = 1.5f;
                }

                Shoot();
                shot++;
                if(shot >= 4) //if the player have shot 4 bullets, cool down for 1.5 second
                {
                    Invoke("resetShot", 1.5f);
                    coolDown = true;
                }
            }
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Character/pistolzap", GetComponent<Transform>().position);
    }

    void resetShot()
    {
        shot = 0;
        coolDown = false;
    }
}
