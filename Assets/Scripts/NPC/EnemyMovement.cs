using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : NpcMovement
{

    public override void StartIdleBehavior()
    {
        base.StartIdleBehavior();
    }

    private IEnumerator ChasePlayer(Transform player)
    {

        while (true)
        {
            //rb.AddForce()
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // enter chase mode
    }

    private void OnTriggerExit(Collider other)
    {
        // Exit chase mode
    }
}
