using System;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    public int damage = 1;
    
    private Rigidbody2D _rb;

    public void Initialize(Vector2 direction)
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocity = direction * speed;
        Destroy(gameObject, lifeTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
