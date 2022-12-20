using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsController : MonoBehaviour
{
    private UnityAdsController _unityAds;
    private AdmobController _admob;
    private AdsProvider _adsProvider;
    private AdProvider _provider;

    private void Start()
    {
        _unityAds = FindObjectOfType<UnityAdsController>();
        _admob = FindObjectOfType<AdmobController>();

        ChooseAdsProvider(0);
    }
    public void ShowInterstitialAd()
    {
        _provider?.ShowInterstitialAd();
    }
    public void ShowRewardedAd()
    {
        _provider?.ShowRewardedAd();
    }
    public void ShowBanner()
    {
        _provider?.ShowBanner();
    }
    public void HideBanner()
    {
        _provider?.HideBanner();
    }
    public void ChooseAdsProvider(int provider)
    {
        HideBanner();

        _adsProvider = (AdsProvider)provider;
        switch(_adsProvider)
        {
            case AdsProvider.UnityAds:
                _provider = _unityAds;
                break;
            case AdsProvider.Admob:
                _provider = _admob;
                break;
        }

        Debug.Log($"Successfully selected {_adsProvider}");
    }
}
public enum AdsProvider
{
    UnityAds = 0,
    Admob = 1
}
