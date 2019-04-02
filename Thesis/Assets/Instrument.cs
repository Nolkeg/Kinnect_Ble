using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Instrument : MonoBehaviour
{
	bool IsTouchingHand;
	AudioSource source;
	[SerializeField] int infoIndex;
	[SerializeField] InfoChecker infoCheck;
	[SerializeField] Transform particle;

	private void Awake()
	{
		IsTouchingHand = false;
		source = GetComponent<AudioSource>();
		source.volume = 0;
	}

	private void Start()
	{
		source = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (IsTouchingHand)
			return;

		if (collision.CompareTag("Hand"))
		{
			IsTouchingHand = true;
			transform.DOScale(new Vector3(1.25f, 1.25f, 1.25f), 0.25f);
			transform.DOShakeScale(300f, 0.05f, 2, 20, true);
			infoCheck.PopUpInfo(infoIndex);
			particle.DOScale(0.3f, 0.25f);
			source.DOFade(1f, 0.25f);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag("Hand"))
		{
			IsTouchingHand = false;
			transform.DOScale(new Vector3(1f, 1f, 1f), 0.25f);
			transform.DOShakeScale(300f, 0f, 0, 0, true);
			infoCheck.PushDownInfo(infoIndex);
			particle.DOScale(0, 0.25f);
			source.DOFade(0f, 0.25f);
		}
	}
}
