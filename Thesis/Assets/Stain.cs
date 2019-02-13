using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stain : MonoBehaviour
{
	//GameObject hand;
	GameObject hand;
	Hand enemyHand;
	public Sprite Stage3,Stage2,Stage1;
	SpriteRenderer stainSprite;
	public int calHP;
	public int HP = 2;
    void Start()
    {
		calHP = HP;
		stainSprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
		if(calHP <= 0)
		{
			if (stainSprite.sprite)
				stainSprite.sprite = Stage2;
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		gameObject.SetActive(false);
		/*if (collision.CompareTag("Hand"))
		{
			if (collision.GetComponent<Hand>() != null)
			{
				hand = collision.gameObject;
				enemyHand =hand.GetComponent<Hand>();
				print("hit");
				if (enemyHand.handSprite == enemyHand.sunlightSprite)
				{
					HP -= 2;
				}
				else if (enemyHand.handSprite == enemyHand.nobrandSprite)
				{
					HP--;
				}
			}
		}*/

	}
}
