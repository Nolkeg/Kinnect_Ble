using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class SongChoice : MonoBehaviour
{
	[SerializeField] int songindex;
	[SerializeField] float timeDelay;
	float fillAmount = 0;
	float timeCount;
	float timeDif;
	bool isTouchByHand = false;
	BackgroundChanger bgChanger;
	Hand2 currentHand;

	private void Start()
	{
		bgChanger = FindObjectOfType<BackgroundChanger>();
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
			SceneManager.LoadScene(songindex);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (currentHand != null)
			return;

		if (collision.CompareTag("Hand"))
		{
			currentHand = collision.GetComponent<Hand2>();

			if(currentHand.loadImage != null)
			{
				isTouchByHand = true;
				transform.DOScale(1f, 0.25f);
				bgChanger.OnSongChangeHandler(songindex - 1);
			}
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
			transform.DOScale(0.88f, 0.25f);
			currentHand = null;
		}
	}

}
