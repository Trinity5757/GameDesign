using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{

    private Rigidbody rb;

    private IEnumerator Start()
    {
        // TODO: Call the StateManager
        // TODO: Start either in a walking or paused state. Choose this randomly
        // TODO: Implement walking in a line
        // TODO: Implement pause
        rb = GetComponent<Rigidbody>();
        float walkTime = Random.Range(2f, 4f);
        yield return StartCoroutine(Walk(walkTime));
        float pauseTime = Random.Range(1.5f, 3f);
        yield return StartCoroutine(Pause(pauseTime));
        walkTime = Random.Range(2f, 4f);
        yield return StartCoroutine(Walk(walkTime));
    }

    private IEnumerator Walk(float walkTime)
    {
        // Walk only while not directly in front of anything. Check this only every 0.2f seconds through the walkTime.
        float timeElapsed = 0f;
        Debug.Log("Started walking");
        while (timeElapsed < walkTime)
        {
            timeElapsed += Time.deltaTime;
            rb.AddForce(transform.forward * 8, ForceMode.Force);
            yield return new WaitForFixedUpdate();
        }
        
    }

    private IEnumerator Pause(float waitTime)
    {
        Debug.Log("Started Pausing");
        yield return new WaitForSecondsRealtime(waitTime);
    }
}
