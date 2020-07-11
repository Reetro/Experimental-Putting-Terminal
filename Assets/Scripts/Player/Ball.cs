using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Rigidbody2D myRigidBody2d = null;
    private Vector2 currentVelocity;
    private float lifeTime = 3f;
    private StaticPlayer player;

    public Slider lifeTimeSlider = null;

    void Awake()
    {
        myRigidBody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        currentVelocity = myRigidBody2d.velocity;
    }

    public void ThrowBall(float speed, StaticPlayer player)
    {
        this.player = player;

        myRigidBody2d.velocity = transform.up * speed;
    }

    public void StopMovement()
    {
        myRigidBody2d.velocity = Vector2.zero;
    }

    public void SlowBall(float slowAmount, float ballLifeTime)
    {
        myRigidBody2d.velocity *= slowAmount;
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        lifeTimeSlider.value = lifeTime;

        if (lifeTime <= 0)
        {
            player.playerBallCount++;

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
