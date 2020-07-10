using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Camera mainCam;
	[HideInInspector]
	public Rigidbody2D rb;
	public float movementSpeed;
	public float maxFallingVelocity;

	float input = 0;

	void Awake()
	{
		mainCam = Camera.main;
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		input = Input.GetAxisRaw("Horizontal");
		if (rb.velocity.y < -maxFallingVelocity)
		{
			rb.velocity = new Vector2(rb.velocity.x, -maxFallingVelocity);
		}
	}

	void FixedUpdate()
	{
		rb.AddForce((Vector2.right * movementSpeed * input * Time.fixedDeltaTime),ForceMode2D.Impulse);
	}
}
