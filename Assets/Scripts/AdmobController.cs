using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdmobController : AdProvider
{
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;

    public void Start()
    {
        MobileAds.Initialize(HandleInitCompleteAction);
    }

    public override void ShowInterstitialAd()
    {
        interstitial = new InterstitialAd(interstitialAdId);
        interstitial.OnAdLoaded += HandleInterstitialAdLoaded;
        interstitial.OnAdFailedToLoad += HandleInterstitialAdFailedToLoad;
        interstitial.OnAdOpening += HandleInterstitialAdOpening;
        interstitial.OnAdFailedToShow += HandleInterstitialAdFailedToShow;
        interstitial.OnAdClosed += HandleInterstitialAdClosed;
        interstitial.OnPaidEvent += HandleInterstitialAdPaidEvent;
        interstitial.OnAdDidRecordImpression += HandleInterstitialAdDidRecordImpression;

        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);

        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public override void ShowRewardedAd()
    {
        rewardedAd = new RewardedAd(rewardedAdId);
        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        rewardedAd.OnAdDidRecordImpression += HandleRewardedAdDidRecordImpression;
        rewardedAd.OnPaidEvent += HandleRewardedAdPaidEvent;

        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);

        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    public override void ShowBanner()
    {
        bannerView?.Destroy();

        bannerView = new BannerView(bannerAdId, AdSize.Banner, AdPosition.Bottom);
        bannerView.OnAdLoaded += HandleBannerAdLoaded;
        bannerView.OnAdFailedToLoad += HandleBannerAdFailedToLoad;
        bannerView.OnAdOpening += HandleBannerAdOpened;
        bannerView.OnAdClosed += HandleBannerAdClosed;
        bannerView.OnPaidEvent += HandleBannerPaidEvent;

        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }
    public override void HideBanner()
    {
        //Destroying is better than hiding, according to https://github.com/Poing-Studios/godot-admob-android/discussions/101
        bannerView?.Destroy();
    }

    #region Event Handles
    private void HandleInitCompleteAction(InitializationStatus initstatus)
    {
        Debug.Log("Admob Initialization complete.");
    }

    private void HandleBannerAdClosed(object sender, EventArgs e)
    {
        Debug.Log("Admob Banner successfully closed");
    }

    private void HandleBannerAdOpened(object sender, EventArgs e)
    {
        Debug.Log("Admob Banner was successfully clicked");
    }

    private void HandleBannerAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        Debug.LogError($"Admob Banner failed to load, {e.LoadAdError.GetMessage()}");
    }

    private void HandleBannerAdLoaded(object sender, EventArgs e)
    {
        Debug.Log("Admob Banned successfully loaded");
    }
    private void HandleBannerPaidEvent(object sender, AdValueEventArgs e)
    {
        Debug.Log($"Admob Banned received OnPaidEvent - {e.AdValue}");
    }

    private void HandleRewardedAdClosed(object sender, EventArgs e)
    {
        Debug.Log("Admob Rewarded Ad successfully closed");
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {
        Debug.Log($"Admob user successfully earned reward - {e.Amount} {e.Type}");
    }

    private void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs e)
    {
        Debug.LogError($"Admob Rewarded Ad failed to show - {e.AdError.GetMessage()}");
    }

    private void HandleRewardedAdOpening(object sender, EventArgs e)
    {
        Debug.Log("Admob Rewarded Ad successfully shown");
    }

    private void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        Debug.LogError($"Admob Rewarded Ad failed to load - {e.LoadAdError.GetMessage()}");
    }

    private void HandleRewardedAdLoaded(object sender, EventArgs e)
    {
        Debug.Log("Admob Rewarded Ad successfully loaded");
    }

    private void HandleRewardedAdPaidEvent(object sender, AdValueEventArgs e)
    {
        Debug.Log($"Admob Rewarded Ad received OnPaidEvent - {e.AdValue}");
    }

    private void HandleRewardedAdDidRecordImpression(object sender, EventArgs e)
    {
        Debug.Log($"Admob Rewarded Ad received OnAdDidRecordImpression");
    }

    private void HandleInterstitialAdDidRecordImpression(object sender, EventArgs e)
    {
        Debug.Log($"Admob Interstitial Ad received OnAdDidRecordImpression");
    }

    private void HandleInterstitialAdPaidEvent(object sender, AdValueEventArgs e)
    {
        Debug.Log($"Admob Interstitial Ad received OnPaidEvent - {e.AdValue}");
    }

    private void HandleInterstitialAdClosed(object sender, EventArgs e)
    {
        Debug.Log("Admob Interstitial Ad successfully closed");
    }

    private void HandleInterstitialAdFailedToShow(object sender, AdErrorEventArgs e)
    {
        Debug.LogError($"Admob Interstitial Ad failed to show - {e.AdError.GetMessage()}");
    }

    private void HandleInterstitialAdOpening(object sender, EventArgs e)
    {
        Debug.Log("Admob Interstitial Ad successfully shown");
    }

    private void HandleInterstitialAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        Debug.LogError($"Admob Interstitial Ad failed to load - {e.LoadAdError.GetMessage()}");
    }

    private void HandleInterstitialAdLoaded(object sender, EventArgs e)
    {
        Debug.Log("Admob Interstitial Ad successfully loaded");
    }
    #endregion
}
