using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Despawn();
        }
    }

    void Despawn()
    {
        Destroy(gameObject); // Remove the enemy
        // Add other effects like particles, sound, etc.
    }
}