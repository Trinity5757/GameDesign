using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform firePoint;
    public float shootForce = 50f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootArrow();
        }
    }

    void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * shootForce; // Apply velocity
    }
}
