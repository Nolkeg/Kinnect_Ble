using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinnectJointPosition : MonoBehaviour
{
	KinectManager manager;
	public KinectWrapper.NuiSkeletonPositionIndex RightHandJointIndex = KinectWrapper.NuiSkeletonPositionIndex.HandRight;
	public KinectWrapper.NuiSkeletonPositionIndex LeftHandJointIndex = KinectWrapper.NuiSkeletonPositionIndex.HandLeft;
	public Vector3 LeftJointPosition,RightJointPosition;


	private void Start()
	{
		manager = KinectManager.Instance;
	}
	// Update is called once per frame
	void Update()
	{
		

		if (manager && manager.IsInitialized()) // check if kinnect is connected
		{
			if (manager.IsUserDetected()) // check if there's any user in the screen
			{
				uint userId = manager.GetPlayer1ID(); //if there's player on screen, save the player id to a variable
				GetRightHandPos(userId);
				GetLeftHandPos(userId);
			}
		}
	}

	private void GetRightHandPos(uint userId)
	{
		if (manager.IsJointTracked(userId, (int)RightHandJointIndex)) //check if the manager is tracking the joint we need
		{
			Vector3 tempPose = manager.GetJointPosition(userId, (int)RightHandJointIndex); //method to get joint value
			tempPose.z = 0;
			tempPose.x = tempPose.x * 10;
			tempPose.y = tempPose.y * 10;
			RightJointPosition = tempPose;
		}
	}

	private void GetLeftHandPos(uint userId)
	{
		if (manager.IsJointTracked(userId, (int)LeftHandJointIndex)) //check if the manager is tracking the joint we need
		{
			Vector3 tempPose = manager.GetJointPosition(userId, (int)LeftHandJointIndex); //method to get joint value
			tempPose.z = 0;
			tempPose.x = tempPose.x * 10;
			tempPose.y = tempPose.y *10;
			LeftJointPosition = tempPose;
		}
	}
}
