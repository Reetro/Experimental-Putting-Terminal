using System;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Rigidbody2D myRigidBody2d = null;
    private Vector2 currentVelocity;
    private float lifeTime = 3f;
    private Player player;
    private float maxSpeed = 10f;

    public Slider lifeTimeSlider = null;

    void Awake()
    {
        myRigidBody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        currentVelocity = myRigidBody2d.velocity;
    }

    public void ThrowBall(float speed, Player player, float ballLifeTime, float maxSpeed)
    {
        this.player = player;
        lifeTime = ballLifeTime;
        this.maxSpeed = maxSpeed;

        myRigidBody2d.velocity = transform.up * speed;
    }

    public void StopMovement()
    {
        myRigidBody2d.velocity = Vector2.zero;
    }

    public void IncreaseSpeed(float multipler)
    {
        Vector2 predictedVelocity = currentVelocity *= multipler;

        if (predictedVelocity.magnitude >= maxSpeed)
        {
            var newVelocity = Vector2.ClampMagnitude(predictedVelocity, maxSpeed);

            myRigidBody2d.velocity = newVelocity;
        }
        else
        {
            myRigidBody2d.velocity = predictedVelocity;
        }
    }

    public void DecreaseSpeed(float divder)
    {
        myRigidBody2d.velocity /= divder;
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        lifeTimeSlider.value = lifeTime;

        if (lifeTime <= 0)
        {
            player.addToPlayerBallCount();

            Destroy(gameObject);
        }
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
