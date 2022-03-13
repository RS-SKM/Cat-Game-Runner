using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D (Collision2D hitInfo)
    {
        Enemy enemy = hitInfo.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

        }
        Debug.Log(hitInfo.gameObject.name);
        Destroy(gameObject);
    }
}
