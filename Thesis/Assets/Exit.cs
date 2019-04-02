using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class Exit : MonoBehaviour
{
	[SerializeField] float timeDelay = 2f;
	float fillAmount = 0;
	float timeCount;
	float timeDif;
	bool isTouchByHand;
	Hand2 currentHand;


	private void Start()
	{
		timeCount = timeDelay;
		timeDif = 0;
	}

	private void Update()
	{
		if (isTouchByHand)
		{
			timeCount -= Time.deltaTime;
			timeDif = timeDelay - timeCount;
			currentHand.loadImage.fillAmount = timeDif / 3;
		}

		if (timeCount <= 0)
		{
			SceneManager.LoadScene(0);
		}

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (currentHand != null)
			return;

		if (collision.CompareTag("Hand"))
		{
			currentHand = collision.GetComponent<Hand2>();
			isTouchByHand = true;
			transform.DOScale(new Vector3(1.65f, 1.65f, 1.65f), 0.25f);
		}
		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.GetComponent<Hand2>() != currentHand)
			return;

		if (collision.CompareTag("Hand"))
		{
			currentHand.loadImage.fillAmount = 0;
			isTouchByHand = false;
			timeCount = timeDelay;
			timeDif = 0;
			transform.DOScale(new Vector3(1.35f, 1.35f, 1.35f), 0.25f);
			currentHand = null;
		}
	}

	
}
