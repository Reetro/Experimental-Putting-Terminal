using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Fan : ObstalcleBase
{
    public float fanForce = 2;
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsObjectBall(collision.gameObject))
        {
            var ball = GetBallComponent(collision.gameObject);

            if (ball)
            {
                Vector2 dir = collision.contacts[0].point - (Vector2)transform.position;
                
                var ballRigidBody = GetBallRigidBody(collision.gameObject);

                ballRigidBody.AddForce(dir * fanForce, ForceMode2D.Impulse);
            }
        }
    }
}
