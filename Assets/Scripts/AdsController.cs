using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsController : MonoBehaviour
{
    private UnityAdsController _unityAds;
    private AdsProvider _adsProvider;
    private void Start()
    {
        _unityAds = FindObjectOfType<UnityAdsController>();
    }
    public void ShowInterstitialAd()
    {
        switch(_adsProvider)
        {
            case AdsProvider.UnityAds:
                _unityAds.ShowInterstitialAd();
                break;
        }
    }
    public void ShowRewardedAd()
    {
        switch (_adsProvider)
        {
            case AdsProvider.UnityAds:
                _unityAds.ShowRewardedAd();
                break;
        }
    }
    public void ChooseAdsProvider(int provider)
    {
        _adsProvider = (AdsProvider)provider;
        Debug.Log($"Successfully choosed {_adsProvider}");
    }
}
public enum AdsProvider
{
    UnityAds = 0
}
