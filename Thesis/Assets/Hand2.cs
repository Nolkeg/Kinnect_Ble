using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hand2 : MonoBehaviour
{
	[SerializeField] KinnectJointPosition jointPosition;
	enum hand { LeftHand, RightHand };
	enum user { user1, user2 };
	[SerializeField] hand myHand;
	[SerializeField] user thisUser;
	public Image loadImage;

	void Update()
	{
		/*
		if(thisUser == user.user1)
		{
			if (myHand == hand.LeftHand)
			{
				transform.position = jointPosition.LeftJointPosition;
			}
			else if (myHand == hand.RightHand)
			{
				transform.position = jointPosition.RightJointPosition;
			}
		}
		else if (thisUser == user.user2)
		{
			if (myHand == hand.LeftHand)
			{
				transform.position = jointPosition.LeftJointPosition2;
			}
			else if (myHand == hand.RightHand)
			{
				transform.position = jointPosition.RightJointPosition2;
			}
		}*/
		
	}
}
