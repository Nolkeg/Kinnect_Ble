using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongChoice : MonoBehaviour
{
	[SerializeField] int songindex;
	[SerializeField] SongManager songManager;
	BackgroundChanger bgChanger;

	private void Start()
	{
		bgChanger = FindObjectOfType<BackgroundChanger>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Hand"))
		{
			songManager.SongIndex = songindex;
			bgChanger.OnSongChangeHandler(songindex-1);
		}
	}
	
}
