using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IAdShower
{
    public abstract void ShowBanner();
    public abstract void HideBanner();
    public abstract void ShowInterstitialAd();
    public abstract void ShowRewardedAd();
}
