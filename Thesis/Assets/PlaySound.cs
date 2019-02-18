using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlaySound : MonoBehaviour
{
	[SerializeField] float maximumTimeToPlay;
	[SerializeField] AudioClip[] sounds;
	[SerializeField] float delay = 0.5f;

	AudioSource source;
	bool IsTouchingHand;
	bool IsPlaying;
	float calculateTime;
    void Start()
    {
		IsTouchingHand = false;
		Debug.Log("test");
		source = GetComponent<AudioSource>();
		calculateTime = maximumTimeToPlay;
    }

    // Update is called once per frame
    void Update()
    {

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Hand Enter");
		if (IsTouchingHand)
			return;

		if (collision.CompareTag("Hand"))
		{
			IsTouchingHand = true;
			StartCoroutine(SoundDelay());
		}
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Hand"))
		{
			IsTouchingHand = false;
			StopAllCoroutines();
		}
	}

	IEnumerator SoundDelay()
	{
		while(IsTouchingHand)
		{
			yield return new WaitForSecondsRealtime(delay);
			if (source.isPlaying)
				continue;
			source.PlayOneShot(sounds[Random.Range(0,sounds.Length-1)]);
			StartCoroutine(StopAfter());
		}
	}

	IEnumerator StopAfter()
	{
		yield return new WaitForSecondsRealtime(maximumTimeToPlay);
		source.Stop();
	}
}
