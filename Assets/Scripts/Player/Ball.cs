using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D myRigidBody2d = null;
    private Vector2 currentVelocity;
    
    void Start()
    {
        myRigidBody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        currentVelocity = myRigidBody2d.velocity;
    }

    public Vector2 GetCurrentVelocity()
    {
        return currentVelocity;
    }
}
