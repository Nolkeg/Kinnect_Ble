using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand2 : MonoBehaviour
{
	KinnectJointPosition jointPosition;
	enum hand { LeftHand, RightHand };
	[SerializeField] hand myHand;

	void Start()
    {
		jointPosition = FindObjectOfType<KinnectJointPosition>();
	}
	
	void Update()
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
}
