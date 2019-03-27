using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SongChoice : MonoBehaviour
{
	[SerializeField] int songindex;
	[SerializeField] float timeDelay;
	[SerializeField] Image load;
	float fillAmount = 0;
	float timeCount;
	bool isTouchByHand = false;
	BackgroundChanger bgChanger;
	Animator anim;

	private void Start()
	{
		bgChanger = FindObjectOfType<BackgroundChanger>();
		anim = GetComponent<Animator>();
		timeCount = timeDelay;
	}

	private void Update()
	{
		if (isTouchByHand)
		{
			timeCount -= Time.deltaTime;
			load.fillAmount = timeCount / 3;
		}
		else
		{
			timeCount = timeDelay;
			load.fillAmount = 0;
		}

		if (timeCount <= 0)
		{
			SceneManager.LoadScene(songindex);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Hand"))
		{
			isTouchByHand = true;
			anim.SetBool("Zoom", true);
			bgChanger.OnSongChangeHandler(songindex-1);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Hand"))
		{
			load.fillAmount = 0;
			isTouchByHand = false;
			anim.SetBool("Zoom", false);
		}
	}

}
