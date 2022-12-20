using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsController : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public bool testMode = true;

    public string myGameIdAndroid = "5082689";
    public string interstitialAdIdAndroid = "Interstitial_Android";
    public string rewardAdIdAndroid = "Rewarded_Android";

    public string myGameIdIOS = "5082688";
    public string interstitialAdIdIOS = "Interstitial_iOS";
    public string rewardAdIdIOS = "Rewarded_iOS";

    public string interstitialAdUnitId;
    public string rewardAdUnitId;

    void Start()
    {
        InitializeAds();
    }

    private void InitializeAds()
    {
#if UNITY_IOS
	    Advertisement.Initialize(myGameIdIOS, testMode, this);
	    interstitialAdUnitId = interstitialAdIdIOS;
        rewardAdUnitId = rewardAdIdIOS;
#elif UNITY_ANDROID
        Advertisement.Initialize(myGameIdAndroid, testMode, this);
        interstitialAdUnitId = interstitialAdIdAndroid;
        rewardAdUnitId = rewardAdIdAndroid;
#endif
    }
    public void ShowInterstitialAd()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Load(interstitialAdUnitId, this);
            Advertisement.Show(interstitialAdUnitId, this);
        }
        else
        {
            Debug.LogWarning($"Unity Ads {interstitialAdUnitId} haven't initialized yet");
        }
    }
    public void ShowRewardedAd()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Load(rewardAdUnitId, this);
            Advertisement.Show(rewardAdUnitId, this);
        }
        else
        {
            Debug.LogWarning($"Unity Ads {rewardAdUnitId} haven't initialized yet");
        }
    }

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
}
