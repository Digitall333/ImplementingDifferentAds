using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsController : AdProvider, IAdShower, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    void Start()
    {
        InitializeAds();

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    private void InitializeAds()
    {
#if UNITY_IOS
	    Advertisement.Initialize(_myGameIdIOS, testMode, this);
#elif UNITY_ANDROID
        Advertisement.Initialize(_myGameIdAndroid, testMode, this);
#endif
    }

    public void ShowInterstitialAd()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Load(interstitialAdId, this);
            Advertisement.Show(interstitialAdId, this);
        }
        else
        {
            Debug.LogWarning($"Unity Ads {interstitialAdId} haven't initialized yet");
        }
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Load(rewardedAdId, this);
            Advertisement.Show(rewardedAdId, this);
        }
        else
        {
            Debug.LogWarning($"Unity Ads {rewardedAdId} haven't initialized yet");
        }
    }

    public void ShowBanner()
    {
        if (Advertisement.isInitialized)
        {
            BannerOptions options = new BannerOptions()
            {
                clickCallback = OnBannerClicked,
                hideCallback = OnBannerHIdden,
                showCallback = OnBannerShown
            };

            BannerLoadOptions loadOptions = new BannerLoadOptions()
            {
                errorCallback = OnBannerLoadError,
                loadCallback = OnBannerLoaded
            };

            if(!Advertisement.Banner.isLoaded)
                Advertisement.Banner.Load(bannerAdId, loadOptions);

            Advertisement.Banner.Show(bannerAdId, options);
        }
    }
    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    #region Event Handles
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialized successfully");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError($"Unity Ads initizlization failed: {error} - {message}");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log($"Unity Ads {placementId} ad loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Unity Ads {placementId} ad failed to LOAD, {error} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"Unity Ads {placementId} ad failed to SHOW, {error} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log($"Unity Ads {placementId} ad started showing");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log($"Unity Ads {placementId} ad received click");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"Unity Ads {placementId} ad showing is completed - {showCompletionState}");
    }

    private void OnBannerLoaded()
    {
        Debug.Log("Unity Ads Banner loaded successfully");
    }

    private void OnBannerLoadError(string message)
    {
        Debug.LogError($"Unity Ads Banner failed to load - {message}");
    }

    private void OnBannerShown()
    {
        Debug.Log("Unity Ads Banner shown successfully");
    }

    private void OnBannerHIdden()
    {
        Debug.Log("Unity Ads Banner hidden successfuly");
    }

    private void OnBannerClicked()
    {
        Debug.Log("Unity Ads Banner was clicked successfully");
    }
    #endregion
}
