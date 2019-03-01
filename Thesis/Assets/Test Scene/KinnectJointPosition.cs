using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinnectJointPosition : MonoBehaviour
{
	KinectManager manager;
	public KinectWrapper.NuiSkeletonPositionIndex RightHandJointIndex = KinectWrapper.NuiSkeletonPositionIndex.HandRight;
	public KinectWrapper.NuiSkeletonPositionIndex LeftHandJointIndex = KinectWrapper.NuiSkeletonPositionIndex.HandLeft;
	public Vector3 LeftJointPosition,RightJointPosition;
	public Vector3 LeftJointPosition2, RightJointPosition2;

	private void Start()
	{
		manager = KinectManager.Instance;
	}
	// Update is called once per frame
	void Update()
	{
		if (manager.IsInitialized()) // check if kinnect is connected
		{
			if (manager.IsUserDetected()) // check if there's any user in the screen
			{
				
				if(manager.GetPlayer2ID() != 0 ) // if there's player 2
				{
					uint user2Id = manager.GetPlayer2ID();
					GetRightHandPos(user2Id,ref RightJointPosition2);
					GetLeftHandPos(user2Id,ref LeftJointPosition2);
				}
				else if(manager.GetPlayer2ID() == 0)
				{
					RightJointPosition2 = Vector3.zero;
					LeftJointPosition2 = Vector3.zero;
				}

				if(manager.GetPlayer1ID() != 0) // if there's player 1
				{
					uint userId = manager.GetPlayer1ID(); //if there's player on screen, save the player id to a variable
					GetRightHandPos(userId,ref RightJointPosition);
					GetLeftHandPos(userId,ref LeftJointPosition);
				}
				else if (manager.GetPlayer1ID() == 0)
				{
					RightJointPosition = Vector3.zero;
					LeftJointPosition = Vector3.zero;
				}
			}
		}
	}

	private void GetRightHandPos(uint userId,ref Vector3 pos)
	{
		print("inside methode GetRightHandPos");
		if (manager.IsJointTracked(userId, (int)RightHandJointIndex)) //check if the manager is tracking the joint we need
		{
			print("Joint is being tracked");
			Vector3 tempPose = manager.GetJointPosition(userId, (int)RightHandJointIndex); //method to get joint value
			tempPose.z = 0;
			tempPose.x = tempPose.x * 10;
			tempPose.y = tempPose.y * 10;
			pos = tempPose;
		}
	}

	private void GetLeftHandPos(uint userId,ref Vector3 pos)
	{
		if (manager.IsJointTracked(userId, (int)LeftHandJointIndex)) //check if the manager is tracking the joint we need
		{
			Vector3 tempPose = manager.GetJointPosition(userId, (int)LeftHandJointIndex); //method to get joint value
			tempPose.z = 0;
			tempPose.x = tempPose.x * 10;
			tempPose.y = tempPose.y *10;
			pos = tempPose;
		}
	}
}
