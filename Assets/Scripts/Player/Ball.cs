using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D myRigidBody2d = null;
    private Vector2 currentVelocity;
    
    void Awake()
    {
        myRigidBody2d = GetComponent<Rigidbody2D>();

        print(myRigidBody2d);
    }

    private void FixedUpdate()
    {
        currentVelocity = myRigidBody2d.velocity;
    }

    public void ThrowBall(float speed)
    {
        myRigidBody2d.velocity = transform.up * speed;
    }

    public Vector2 GetCurrentVelocity()
    {
        return currentVelocity;
    }
}
