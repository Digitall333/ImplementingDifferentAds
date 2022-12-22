using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using System;

public class AppodealController : MonoBehaviour, IAdShower, IAppodealInitializationListener, IInterstitialAdListener, IRewardedVideoAdListener, IBannerAdListener
{
    [SerializeField] private string _appKey;
	private void Start()
	{
		int adTypes = AppodealAdType.Interstitial | AppodealAdType.Banner | AppodealAdType.RewardedVideo | AppodealAdType.Mrec;
        Appodeal.SetRewardedVideoCallbacks(this);
        Appodeal.SetInterstitialCallbacks(this);
        Appodeal.SetBannerCallbacks(this);
        Appodeal.Initialize(_appKey, adTypes, this);
	}

    public void ShowBanner()
    {
        Appodeal.Show(AppodealShowStyle.BannerBottom);
    }

    public void HideBanner()
    {
        Appodeal.Hide(AppodealAdType.Banner);
    }

    public void ShowInterstitialAd()
    {
        if (Appodeal.IsLoaded(AppodealAdType.Interstitial))
        {
            Appodeal.Show(AppodealShowStyle.Interstitial);
        }
    }


    public void ShowRewardedAd()
    {
        if (Appodeal.IsLoaded(AppodealAdType.RewardedVideo))
        {
            Appodeal.Show(AppodealShowStyle.RewardedVideo);
        }
    }

    #region Event Handles

    public void OnInitializationFinished(List<string> errors)
    {
        Debug.Log($"Appodeal Initialization finished");
    }

    public void OnInterstitialLoaded(bool isPrecache)
    {
        Debug.Log($"Appodeal Interstitial Ad loaded");
    }

    public void OnInterstitialFailedToLoad()
    {
        Debug.LogError($"Appodeal Interstitial Ad failed to load");
    }

    public void OnInterstitialShowFailed()
    {
        Debug.LogError($"Appodeal Interstitial Ad failed to show");
    }

    public void OnInterstitialShown()
    {
        Debug.Log($"Appodeal Interstitial Ad shown");
    }

    public void OnInterstitialClosed()
    {
        Debug.Log($"Appodeal Interstitial Ad is closed");
    }

    public void OnInterstitialClicked()
    {
        Debug.Log($"Appodeal Interstitial Ad was clicked");
    }

    public void OnInterstitialExpired()
    {
        Debug.Log($"Appodeal Interstitial Ad was expired");
    }

    public void OnRewardedVideoLoaded(bool isPrecache)
    {
        Debug.Log($"Appodeal Rewarded Ad loaded");
    }

    public void OnRewardedVideoFailedToLoad()
    {
        Debug.LogError($"Appodeal Rewarded Ad failed to load");
    }

    public void OnRewardedVideoShowFailed()
    {
        Debug.LogError($"Appodeal Rewarded Ad failed to show");
    }

    public void OnRewardedVideoShown()
    {
        Debug.Log($"Appodeal Rewarded Ad shown");
    }

    public void OnRewardedVideoFinished(double amount, string currency)
    {
        Debug.Log($"Appodeal Rewarded ad finished, user earned - {amount}{currency}");
    }

    public void OnRewardedVideoClosed(bool finished)
    {
        Debug.Log($"Appodeal Rewarded Ad is closed. Was it finished? - {finished}");
    }

    public void OnRewardedVideoExpired()
    {
        Debug.Log($"Appodeal Rewarded Ad was expired");
    }

    public void OnRewardedVideoClicked()
    {
        Debug.Log($"Appodeal Rewarded Ad was clicked");
    }

    public void OnBannerLoaded(int height, bool isPrecache)
    {
        Debug.Log($"Appodeal Banner Ad loaded");
    }

    public void OnBannerFailedToLoad()
    {
        Debug.LogError($"Appodeal Banner Ad failed to load");
    }

    public void OnBannerShown()
    {
        Debug.Log($"Appodeal Banner Ad shown");
    }

    public void OnBannerShowFailed()
    {
        Debug.LogError($"Appodeal Banner Ad failed to show");
    }

    public void OnBannerClicked()
    {
        Debug.Log($"Appodeal Banner Ad was clicked");
    }

    public void OnBannerExpired()
    {
        Debug.Log($"Appodeal Banner Ad was expired");
    }
    #endregion
}
