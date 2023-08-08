using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adsManager : MonoBehaviour
{
	public static adsManager I;

	string adType;
	string gameId;
	void Awake()
	{
		I = this;

		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			adType = "Rewarded_iOS";
			gameId = "5368112";
		}
		else
		{
			adType = "Rewarded_Android";
			gameId = "5368113";
		}

		Advertisement.Initialize(gameId, true);
	}

	public void ShowRewardAd()
	{
		if (Advertisement.IsReady())
		{
			ShowOptions options = new ShowOptions { resultCallback = ResultAds };
			Advertisement.Show(adType, options);
		}
	}

	void ResultAds(ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Failed:
				Debug.LogError("���� ���⿡ �����߽��ϴ�.");
				break;
			case ShowResult.Skipped:
				Debug.Log("���� ��ŵ�߽��ϴ�.");
				break;
			case ShowResult.Finished:
				// ���� ���� ���� ��� 
				Debug.Log("���� ���⸦ �Ϸ��߽��ϴ�.");
				gameManager.I.retryGame();
				break;
		}
	}
}
