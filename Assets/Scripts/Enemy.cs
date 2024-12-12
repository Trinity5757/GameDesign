using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;

    public GameObject drop;

    //Adding an Audio Component
    private AudioManager audioManager;
    public void TakeDamage(float damage)
    {
        audioManager = FindObjectOfType<AudioManager>();
        health -= damage;
        if (health <= 0)
        {
            DropLoot();
            Despawn();
        }
        audioManager.PlayCollisionSound();
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