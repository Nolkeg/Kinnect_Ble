using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

	KinnectJointPosition jointPosition;
	[SerializeField] int sunlightDamage = 2;
	[SerializeField] int nobrandDamage = 1;
	int defaultDamage = 0;
	
	[SerializeField] Sprite sunlightHand;
	[SerializeField] Sprite nobrandHand;
	[SerializeField] Sprite defaultSprite;


	SpriteRenderer handSprite;
	int currentHandDamage;
	bool HaveCloth;

	enum hand { LeftHand, RightHand };
	public enum handstate { Default, Sunlight, Nobrand};

	[SerializeField] hand myHand;
	handstate currentHandState;

	public handstate getHandState
	{
		get { return currentHandState; }
	}

    void Start()
    {
		jointPosition = FindObjectOfType<KinnectJointPosition>();
		handSprite = GetComponentInChildren<SpriteRenderer>();
		currentHandDamage = defaultDamage;
    }
	
    void Update()
    {
        if(myHand == hand.LeftHand)
		{
			transform.position = jointPosition.LeftJointPosition;
		}
		else if(myHand == hand.RightHand)
		{
			transform.position = jointPosition.RightJointPosition;
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (handSprite == null)
		{
			Debug.Log("Did not find Sprite Renderer");
			return;
		}

		if(collision.CompareTag("Sunlight"))
		{
			if(currentHandState == handstate.Default)
			{
				SetHandState(handstate.Sunlight,sunlightHand);
			}
			else
			{
				SetHandState(handstate.Default, defaultSprite);
			}
		}
		else if(collision.CompareTag("Nobrand"))
		{
			if (currentHandState == handstate.Default)
			{
				SetHandState(handstate.Nobrand, nobrandHand);
			}
			else
			{
				SetHandState(handstate.Default, defaultSprite);
			}
		}
		else if(collision.CompareTag("Stain"))
		{
			Stain hitStain = collision.gameObject.GetComponent<Stain>();
			hitStain.OnHitHandler(currentHandDamage);
		}
	}

	void SetHandState(handstate currentHand, Sprite haveItemSprite)
	{
		currentHandState = currentHand;
		handSprite.sprite = haveItemSprite;
		
		switch (currentHandState)
		{
			case handstate.Sunlight:
				currentHandDamage = sunlightDamage;
				break;
			case handstate.Nobrand:
				currentHandDamage = nobrandDamage;
				break;
			case handstate.Default:
				currentHandDamage = defaultDamage;
				break;
		}
	}

	
}
