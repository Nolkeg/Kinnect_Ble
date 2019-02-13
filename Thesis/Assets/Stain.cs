using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stain : MonoBehaviour
{

	enum StainState { Stage3,Stage2,Stage1 }
	StainState currentStainState;

	public Sprite Stage3,Stage2,Stage1;

	SpriteRenderer stainSprite;
	public int calHP;
	public int HP = 2;

	public delegate void DamageDelegate(int damage);
	public event DamageDelegate DamageEvent;


    void Start()
    {
		calHP = HP;
		stainSprite = GetComponent<SpriteRenderer>();
		currentStainState = StainState.Stage3;
		DamageEvent += TakeDamage;
    }

    
    void Update()
    {
		
    }

	public void OnHitHandler(int damage)
	{
		if (DamageEvent == null)
			return;
		DamageEvent(damage);
	}

	void TakeDamage(int damageTaken)
	{
		calHP -= damageTaken;
		if (calHP <= 0 && currentStainState == StainState.Stage1)
		{
			gameObject.SetActive(false);
		}
		else if (calHP<=0)
		{
			calHP = HP;
			currentStainState++;
			ChangeSprite();
		}
	}

	void ChangeSprite()
	{
		switch (currentStainState)
		{
			case StainState.Stage3:
				stainSprite.sprite = Stage3;
				break;
			case StainState.Stage2:
				stainSprite.sprite = Stage2;
				break;
			case StainState.Stage1:
				stainSprite.sprite = Stage1;
				break;
		}
	}

}
