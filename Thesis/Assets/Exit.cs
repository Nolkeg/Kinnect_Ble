using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{
	[SerializeField] float timeDelay = 2f;
	float timeCount;
	bool IsTouchByHand;
	private void Start()
	{
		timeCount = timeDelay;
	}

	private void Update()
	{
		if(IsTouchByHand)
		{
			timeCount -= Time.deltaTime;
		}
		else
		{
			timeCount = timeDelay;
		}
		if(timeCount <= 0)
		{
			SceneManager.LoadScene(0);
		}
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Hand"))
		{
			IsTouchByHand = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag("Hand"))
		{
			IsTouchByHand = false;
		}
	}

	
}
