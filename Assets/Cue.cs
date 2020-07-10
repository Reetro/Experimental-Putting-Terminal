using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue : MonoBehaviour
{
	public PlayerMovement PM;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (PM.canHitBall)
		{
			Rigidbody2D rb = other.attachedRigidbody;
			Vector3 forceDir = transform.up;
			rb.AddForce(forceDir * 2f,ForceMode2D.Impulse);
		}
	}
}
