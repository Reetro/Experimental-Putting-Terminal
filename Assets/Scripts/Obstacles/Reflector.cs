using UnityEngine;

public class Reflector : ObstalcleBase
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsObjectBall(collision.gameObject))
        {
            var ballRigidbody2D = GetBallRigidBody(collision.gameObject);

            if (ballRigidbody2D)
            {
                var ball = GetBallComponent(collision.gameObject);

                ContactPoint2D contactPoint2D = collision.contacts[0];

                Vector2 newVelocity = Vector2.Reflect(ball.GetCurrentVelocity(), contactPoint2D.normal);

                ballRigidbody2D.velocity = newVelocity;
            }
        }
    }
}
