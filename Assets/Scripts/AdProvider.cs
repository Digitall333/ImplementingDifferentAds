using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdProvider : MonoBehaviour
{
    [SerializeField] protected bool testMode = true;

    [SerializeField] protected string _myGameIdAndroid;
    [SerializeField] private string _interstitialAdIdAndroid;
    [SerializeField] private string _rewardAdIdAndroid;
    [SerializeField] private string _bannerAdIdAndroid;

    [SerializeField] protected string _myGameIdIOS;
    [SerializeField] private string _interstitialAdIdIOS;
    [SerializeField] private string _rewardAdIdIOS;
    [SerializeField] private string _bannerAdIdIOS;

    protected string interstitialAdId;
    protected string rewardedAdId;
    protected string bannerAdId;

    void Awake()
    {
#if UNITY_IOS
	    interstitialAdId = _interstitialAdIdIOS;
        rewardedAdId = _rewardAdIdIOS;
        bannerAdId = _bannerAdIdIOS;
#elif UNITY_ANDROID
        interstitialAdId = _interstitialAdIdAndroid;
        rewardedAdId = _rewardAdIdAndroid;
        bannerAdId = _bannerAdIdAndroid;
#endif
    }
    public abstract void ShowBanner();
    public abstract void HideBanner();
    public abstract void ShowInterstitialAd();
    public abstract void ShowRewardedAd();
}
