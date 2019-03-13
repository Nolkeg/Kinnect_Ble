using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour
{
	bool IsTouchingHand;
	AudioSource source;

	private void Awake()
	{
		IsTouchingHand = false;
	}

	private void Start()
	{
		source = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (IsTouchingHand)
			return;

		if(collision.CompareTag("Hand"))
		{
			IsTouchingHand = true;
			source.mute = false;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag("Hand"))
		{
			IsTouchingHand = false;
			source.mute = true;
		}
	}
}
