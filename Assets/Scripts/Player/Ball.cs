using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D myRigidBody2d = null;
    private Vector2 currentVelocity;
    
    void Awake()
    {
        myRigidBody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        currentVelocity = myRigidBody2d.velocity;
    }

    public void ThrowBall(float speed)
    {
        myRigidBody2d.velocity = transform.up * speed;
    }

    public void StopMovement()
    {
        myRigidBody2d.velocity = Vector2.zero;
    }

    public void SlowBall(float slowAmount)
    {
        myRigidBody2d.velocity *= slowAmount;
    }

    public Vector2 GetCurrentVelocity()
    {
        return currentVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.gameObject.CompareTag("Fan"))
        {
            ContactPoint2D contactPoint2D = collision.contacts[0];

            Vector2 newVelocity = Vector2.Reflect(GetCurrentVelocity(), contactPoint2D.normal);

            myRigidBody2d.velocity = newVelocity;
        }
    }
}
