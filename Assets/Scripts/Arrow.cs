using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage = 30f; // Set damage value
    public float lifetime = 5f; // Arrow lifespan

    void Start()
    {
        Destroy(gameObject, lifetime); // Destroy arrow after lifetime
    }

    void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Call enemy damage function
            Destroy(gameObject); // Destroy arrow on hit
        }
    }
}
