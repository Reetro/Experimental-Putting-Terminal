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
    [SerializeField] AudioClip[] ballSounds = null;
    private Slider playerSlider;
    private AudioSource myAudioSorce;

    void Awake()
    {
        myRigidBody2d = GetComponent<Rigidbody2D>();

        myAudioSorce = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        currentVelocity = myRigidBody2d.velocity;
    }

    public void ThrowBall(float speed, Player player, float ballLifeTime, float maxSpeed, Slider playerSlider)
    {
        this.player = player;
        lifeTime = ballLifeTime;
        this.maxSpeed = maxSpeed;
        this.playerSlider = playerSlider;

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

        UpdateSlider(false);

        if (lifeTime <= 0)
        {
            player.addToPlayerBallCount();

            Destroy(gameObject);
        }
    }

    public void UpdateSlider(bool reset)
    {
        if (reset)
        {
            playerSlider.value = 1;
        }
        else
        {
            playerSlider.value = lifeTime;
        }
    }

    public Vector2 GetCurrentVelocity()
    {
        return currentVelocity;
    }

    private void PlaySound()
    {
        AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];

        myAudioSorce.PlayOneShot(clip);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.gameObject.CompareTag("Fan") && !collision.transform.gameObject.CompareTag("Hole") && !collision.transform.gameObject.CompareTag("Wall"))
        {
            PlaySound();

            ContactPoint2D contactPoint2D = collision.contacts[0];

            Vector2 newVelocity = Vector2.Reflect(GetCurrentVelocity(), contactPoint2D.normal);

            myRigidBody2d.velocity = newVelocity;
        }
    }
}
