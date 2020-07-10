using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Camera mainCam;
	public float moveSpeed = 1;

	public bool FollowMouse = true;

	Vector2 userInput = Vector2.zero;
	Vector2 mousePosition = Vector2.zero;

	void Awake()
	{
		mainCam = Camera.main;
	}

	void Update()
	{
		userInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
	}

	void FixedUpdate()
	{
		if (Vector2.Distance(transform.position, mousePosition) > .1f)
			transform.Translate(-userInput * moveSpeed * Time.fixedDeltaTime);

		Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

		if (FollowMouse)
		{
			transform.up = -direction;
			transform.GetChild(0).up = transform.up;
		}
		else
		{
			transform.GetChild(0).up = direction;
			transform.up = Vector2.up;
		}

	}
}
