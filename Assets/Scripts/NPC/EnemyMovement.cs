using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : NpcMovement
{

    private IEnumerator ChasePlayer(Transform player)
    {

        while (true)
        {
            Vector3 direction = player.position - transform.position;
            rb.AddForce(direction.normalized * walkSpeed, ForceMode.Force);
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            StopAllCoroutines();
            StartCoroutine(ChasePlayer(player.transform));
        }
    }

}
