using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;

    public GameObject drop;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DropLoot();
            Despawn();
        }
    }

    void DropLoot()
    {
        if (drop != null)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
        }
    }

    void Despawn()
    {
        Destroy(gameObject); // Remove the enemy
        // Add other effects like particles, sound, etc.
    }
}