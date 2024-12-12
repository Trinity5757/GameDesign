using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform firePoint;
    public float shootForce = 50f;

    private AudioManager audioManager;

    void Update()
    {
        //in case we are paused
        if (Time.timeScale == 0f)
            return;
        
        if (Input.GetButtonDown("Fire1"))
        {
            ShootArrow();
        }
    }

    void ShootArrow()
    {
        audioManager = FindObjectOfType<AudioManager>();
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * shootForce; // Apply velocity
        audioManager.PlayBowRelease();
    }
}
