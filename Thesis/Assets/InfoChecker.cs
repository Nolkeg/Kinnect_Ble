using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class InfoChecker : MonoBehaviour
{
	public RectTransform[] infoDetail;

	public void PopUpInfo(int index)
	{
		foreach(var x in infoDetail)
		{
			if (x == infoDetail[index])
				continue;
			x.DOAnchorPosY(-150, 0.25f);
		}

		infoDetail[index].DOAnchorPosY(70, 0.25f);
	}

	public void PushDownInfo(int index)
	{
		infoDetail[index].DOAnchorPosY(-150, 0.25f);
	}

}
