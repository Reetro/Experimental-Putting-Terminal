using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BlackHole : ObstalcleBase
{
    public Rigidbody2D myRigidbody2D;

    private GameObject overlappedBall = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsObjectBall(collision.gameObject))
        {
            overlappedBall = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsObjectBall(collision.gameObject))
        {
            overlappedBall = null;
        }
    }

    private void FixedUpdate()
    {
        if (overlappedBall)
        {
            PullBall(overlappedBall);
        }
    }

    void PullBall(GameObject objectToPull)
    {
        var ballRigidbody2D = GetBallRigidBody(objectToPull);

        Vector2 direction = myRigidbody2D.position - ballRigidbody2D.position;
        float distance = direction.magnitude;

        float forceMagnatuide = (myRigidbody2D.mass * ballRigidbody2D.mass) / Mathf.Pow(distance, 2);
        Vector2 force = direction.normalized * forceMagnatuide;

        ballRigidbody2D.AddForce(force);
    }
}
