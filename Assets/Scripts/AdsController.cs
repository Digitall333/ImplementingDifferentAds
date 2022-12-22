using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdsController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown changeProviderDropdown;

    private UnityAdsController _unityAds;
    private AdmobController _admob;
    private AppodealController _appodeal;
    private AdsProvider _adsProvider;
    private IAdShower _adShower;

    private void Start()
    {
        _unityAds = FindObjectOfType<UnityAdsController>();
        _admob = FindObjectOfType<AdmobController>();
        _appodeal = FindObjectOfType<AppodealController>();

        changeProviderDropdown.onValueChanged.AddListener(ChooseAdsProvider);

        ChooseAdsProvider(0);
    }
    public void ShowInterstitialAd()
    {
        _adShower?.ShowInterstitialAd();
    }
    public void ShowRewardedAd()
    {
        _adShower?.ShowRewardedAd();
    }
    public void ShowBanner()
    {
        _adShower?.ShowBanner();
    }
    public void HideBanner()
    {
        _adShower?.HideBanner();
    }
    public void ChooseAdsProvider(int value)
    {
        HideBanner();

        _adsProvider = (AdsProvider)value;
        switch(_adsProvider)
        {
            case AdsProvider.UnityAds:
                _adShower = _unityAds;
                break;
            case AdsProvider.Admob:
                _adShower = _admob;
                break;
            case AdsProvider.Appodeal:
                _adShower = _appodeal;
                break;
        }

        Debug.Log($"Successfully selected {_adsProvider}");
    }
}
public enum AdsProvider
{
    UnityAds = 0,
    Admob = 1,
    Appodeal = 2
}
