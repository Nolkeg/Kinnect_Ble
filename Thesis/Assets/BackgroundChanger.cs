using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
	SpriteRenderer currentBackground;
	[SerializeField] Sprite[] backgroundImages;

	private void Start()
	{
		currentBackground = GetComponent<SpriteRenderer>();
	}

	public void OnSongChangeHandler(int songIndex)
	{
		currentBackground.sprite = backgroundImages[songIndex];
	}
}
