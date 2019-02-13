using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

	KinnectJointPosition jointPosition;
	
	enum hand {LeftHand, RightHand};

	public Sprite sunlightSprite;
	public Sprite nobrandSprite;
	[SerializeField] Sprite defaultSpriteRight;
	[SerializeField] Sprite defaultSpriteLeft;
	public SpriteRenderer handSprite;

	bool HaveCloth;
 
	[SerializeField] hand myHand;

    void Start()
    {
		jointPosition = FindObjectOfType<KinnectJointPosition>();
		handSprite = GetComponentInChildren<SpriteRenderer>();
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

		/*if (handSprite.sprite != defaultSpriteLeft || handSprite.sprite != defaultSpriteRight)
		{
			if (myHand == hand.LeftHand)
			{
				handSprite.sprite = defaultSpriteLeft;
			}
			else if (myHand == hand.RightHand)
			{
				handSprite.sprite = defaultSpriteRight;
			}
		}*/
		
		if(collision.CompareTag("Nobrand"))
		{
			handSprite.sprite = nobrandSprite;
		}
		else if(collision.CompareTag("Sunlight"))
		{
			handSprite.sprite = sunlightSprite;
		}
	}
}
