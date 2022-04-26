using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 40;
    public bool IsShot;
    Animator animator;
    public float deathDelay;

    void Awake()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Character/RobotHit", GetComponent<Transform>().position);
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsShot", true);
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, deathDelay);
    }
}