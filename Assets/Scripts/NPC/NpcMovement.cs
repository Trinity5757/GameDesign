using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    public float walkSpeed = 7f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartIdleBehavior();
    }

    public void StartIdleBehavior()
    {
        StartCoroutine(IdleBehavior());
    }

    public void PauseIdleBehavior()
    {
        StopAllCoroutines();
    }

    private IEnumerator IdleBehavior()
    {
        while (true)
        {
            bool delayTurn = Random.Range(0, 2) == 0;
            if (delayTurn) {
                yield return StartCoroutine(Turn());
            }
            else
            {
                StartCoroutine(Turn());
            }

            float walkTime = Random.Range(2f, 4f);
            yield return StartCoroutine(Walk(walkTime));

            float pauseTime = Random.Range(1.5f, 3f);
            yield return StartCoroutine(Pause(pauseTime));
            
        }
        
    }

    private IEnumerator Walk(float walkTime)
    {
        // Walk only while not directly in front of anything. Check this only every 0.2f seconds through the walkTime.
        float timeElapsed = 0f;
        Debug.Log("Started walking");
        while (timeElapsed < walkTime)
        {
            timeElapsed += Time.deltaTime;
            rb.AddForce(transform.forward * walkSpeed, ForceMode.Force);
            yield return new WaitForFixedUpdate();
        }  
    }

    private IEnumerator Turn()
    {
        float maxTurnAngle = 90f;

        float randomTurnAngle = Random.Range(-maxTurnAngle, maxTurnAngle);

        float turnDuration = 1f; 
        float timeElapsed = 0f;

        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, transform.eulerAngles.y + randomTurnAngle, 0);

        while (timeElapsed < turnDuration)
        {
            timeElapsed += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / turnDuration);
            yield return null;
        }

        transform.rotation = targetRotation;
    }

    private IEnumerator Pause(float waitTime)
    {
        Debug.Log("Started Pausing");
        yield return new WaitForSecondsRealtime(waitTime);
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null) {
            StopAllCoroutines();
            StartIdleBehavior();
        }
    }
}
