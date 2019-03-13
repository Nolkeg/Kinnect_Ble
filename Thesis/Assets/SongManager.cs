using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongManager : MonoBehaviour
{
	public int SongIndex;
	[SerializeField] float timeDelay;
	float timeCount;
	bool isToucByHand = false;


	private void Start()
	{
		timeCount = timeDelay;
	}

	private void Update()
	{
		if(isToucByHand)
		{
			timeCount -= Time.deltaTime;
		}
		else
		{
			timeCount = timeDelay;
		}

		if(timeCount <= 0)
		{
			SceneManager.LoadScene(SongIndex);
		}
	}

	public void ChangeSongIndex(int index)
	{
		SongIndex = index;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Hand"))
		{
			isToucByHand = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag("Hand"))
		{
			isToucByHand = false;
		}
	}



}
