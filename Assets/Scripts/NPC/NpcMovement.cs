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
        yield return StartCoroutine(Walk(2f));
        yield return StartCoroutine(Pause(1f));
        yield return StartCoroutine(Walk(2f));
    }

    private IEnumerator Walk(float walkTime)
    {
        // Walk only while not directly in front of anything. Check this only every 0.2f seconds through the walkTime.
        float timeElapsed = 0f;
        while (timeElapsed < walkTime)
        {
            timeElapsed += Time.deltaTime;
            rb.AddForce(Vector3.forward, ForceMode.Force);
            yield return new WaitForFixedUpdate();
        }
        
    }

    private IEnumerator Pause(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
    }
}
