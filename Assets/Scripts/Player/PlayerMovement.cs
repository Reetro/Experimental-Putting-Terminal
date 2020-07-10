using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Camera mainCam;
	public float moveSpeed = 1;

	public GameObject cue;
	public float cuePushAmount = 1;
	bool isPushingCue = false;
	[HideInInspector]
	public bool canHitBall = false;
	public float extendedCooldown;
	public float retractedCooldown;


	Vector2 userInput = Vector2.zero;
	Vector2 mousePosition = Vector2.zero;

	void Awake()
	{
		mainCam = Camera.main;
	}

	void Update()
	{
		mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
		userInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
		transform.GetChild(0).up = direction;

		if (Input.GetMouseButtonDown(0)&&!isPushingCue)
		{
			StartCoroutine(ShootCue());
		}
	}

	void FixedUpdate()
	{
		transform.Translate(userInput * moveSpeed);

		

	}

	IEnumerator ShootCue()
	{
		isPushingCue = true;
		canHitBall = true;
		for (int i = 0; i < cuePushAmount; i++)
		{
			yield return null;
			cue.transform.Translate(Vector2.up * .01f);
		}
		canHitBall = false;
		yield return new WaitForSeconds(extendedCooldown); //hold it out for a bit
		for (int i = 0; i < cuePushAmount; i++)
		{
			yield return null;
			yield return null;
			cue.transform.Translate(Vector2.up * -.01f);
		}

		yield return new WaitForSeconds(retractedCooldown); //cooldown
		isPushingCue = false;
	}
}
