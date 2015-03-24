/**
 * FlurryAd.cs
 * 
 * A Singleton class encapsulating public access methods for Admob Ad processes.
 * 
 * Please read the code comments carefully, or visit 
 * http://www.neatplug.com/integration-guide-unity3d-flurry-ad-plugin to find information how 
 * to use this program.
 * 
 * End User License Agreement: http://www.neatplug.com/eula
 * 
 * (c) Copyright 2012 NeatPlug.com All rights reserved.
 * 
 * @version 1.6.0
 * @sdk_version(android) 5.1.0
 * @sdk_version(ios) 6.0.0
 *
 */

using UnityEngine;
using System;
using System.Collections;

public class FlurryAd  {
	
	#region Fields
		
	public enum BannerAdType
	{		
		Universal_Banner = 1
	};
	
	public enum AdLayout
	{
		Top_Centered = 0,		
		Bottom_Centered = 3		
	};
	
	private class FlurryAdNativeHelper : IFlurryAdNativeHelper {
		
#if UNITY_ANDROID	
		private AndroidJavaObject _plugin = null;
#endif		
		public FlurryAdNativeHelper()
		{
			
		}
		
		public void CreateInstance(string className, string instanceMethod)
		{	
#if UNITY_ANDROID			
			AndroidJavaClass jClass = new AndroidJavaClass(className);
			_plugin = jClass.CallStatic<AndroidJavaObject>(instanceMethod);	
#endif			
		}
		
		public void Call(string methodName, params object[] args)
		{
#if UNITY_ANDROID			
			_plugin.Call(methodName, args);	
#endif
		}
		
		public void Call(string methodName, string signature, object arg)
		{
#if UNITY_ANDROID			
			var method = AndroidJNI.GetMethodID(_plugin.GetRawClass(), methodName, signature);			
			AndroidJNI.CallObjectMethod(_plugin.GetRawObject(), method, AndroidJNIHelper.CreateJNIArgArray(new object[] {arg}));
#endif			
		}
		
		public ReturnType Call<ReturnType> (string methodName, params object[] args)
		{
#if UNITY_ANDROID			
			return _plugin.Call<ReturnType>(methodName, args);
#else
			return default(ReturnType);			
#endif			
		}
	
	};	
	
	private static FlurryAd _instance = null;
	
	#endregion
	
	#region Functions
	
	/**
	 * Constructor.
	 */
	private FlurryAd()
	{	
#if UNITY_ANDROID		
		FlurryAdAndroid.Instance().SetNativeHelper(new FlurryAdNativeHelper());
#endif	
#if UNITY_IPHONE
		FlurryAdIOS.Instance();
#endif
	}
	
	/**
	 * Instance method.
	 */
	public static FlurryAd Instance()
	{		
		if (_instance == null) 
		{
			_instance = new FlurryAd();
		}
		
		return _instance;
	}	
	
	/**
	 * Initialization.
	 * 
	 * @param apiKey
	 *            string - Your App API key.
	 * 
	 * @param adSpaceTopBanner
	 *            string - The Ad space name of top banner.
	 * 
	 * @param adSpaceBottomBanner
	 *            string - The Ad space name of bottom banner.
	 * 
	 * @param adSpaceFullScreen
	 *            string - The Ad space name of full screen (interstitial).
	 * 
	 */
	public void Init(string apiKey, string adSpaceTopBanner, string adSpaceBottomBanner,
		             string adSpaceFullScreen)
	{
#if UNITY_ANDROID		
		FlurryAdAndroid.Instance().Init(apiKey, adSpaceTopBanner, adSpaceBottomBanner, 
		                                     adSpaceFullScreen);		
#endif	
#if UNITY_IPHONE
		FlurryAdIOS.Instance().Init(apiKey, adSpaceTopBanner, adSpaceBottomBanner, 
		                                     adSpaceFullScreen);	
#endif		
	}
	
	/**
	 * Set test mode for Ad.
	 *
	 * @param testMode
	 *             bool - true for test mode On, false for test mode Off.
	 */
	public void SetTestMode(bool testMode)
	{
#if UNITY_ANDROID		
		FlurryAdAndroid.Instance().SetTestMode(testMode);		
#endif	
#if UNITY_IPHONE
		FlurryAdIOS.Instance().SetTestMode(testMode);
#endif			
	}
	
	/**
	 * Load a Banner Ad and show it it immediately once loaded.
	 * 
	 * @param adType
	 *           BannerAdType - type of the Ad.
	 * 
	 * @param layout
	 *           AdLayout - in which layout the Ad should display.
	 *	
	 */
	public void LoadBannerAd(BannerAdType adType, AdLayout layout)
	{
#if UNITY_ANDROID		
		FlurryAdAndroid.Instance().LoadBannerAd((int)adType, (int)layout, false);
#endif	
#if UNITY_IPHONE
		FlurryAdIOS.Instance().LoadBannerAd((int)adType, (int)layout, false);
#endif		
	}

	/**
	 * Load a Banner Ad.
	 * 
	 * @param adType
	 *           BannerAdType - type of the Ad.
	 * 
	 * @param layout
	 *           AdLayout - in which layout the Ad should display.
	 * 
     * @param hide
	 *           bool - whether the ad should keep being invisible after loaded,
	 *                  true for making the ad hidden, false for showing the 
	 *                  ad immediately. if the parameter is set to true, then 
	 *                  you need to programmatically display the ad by calling 
	 *                  ShowBannerAd() after you get notified with event
	 *                  OnReceiveAd from FlurryAdListener.
	 *	
	 */
	public void LoadBannerAd(BannerAdType adType, AdLayout layout, bool hide)
	{
#if UNITY_ANDROID		
		FlurryAdAndroid.Instance().LoadBannerAd((int)adType, (int)layout, hide);
#endif	
#if UNITY_IPHONE
		FlurryAdIOS.Instance().LoadBannerAd((int)adType, (int)layout, hide);
#endif		
	}
	
	/**
	 * Show the Banner Ad.
	 * 
	 * This sets the banner ad to be visible.
	 */
	public void ShowBannerAd()
	{
#if UNITY_ANDROID		
		FlurryAdAndroid.Instance().ShowBannerAd();
#endif	
#if UNITY_IPHONE
		FlurryAdIOS.Instance().ShowBannerAd();
#endif
	}
	
	/**
	 * Hide the Banner Ad.
	 * 
	 * This sets the banner ad to be invisible again.
	 */
	public void HideBannerAd()
	{
#if UNITY_ANDROID		
		FlurryAdAndroid.Instance().HideBannerAd();
#endif	
#if UNITY_IPHONE
		FlurryAdIOS.Instance().HideBannerAd();
#endif
	}	
	
	/**
	 * Destroy the Banner Ad.
	 */
	public void DestroyBannerAd()
	{
#if UNITY_ANDROID		
		FlurryAdAndroid.Instance().DestroyBannerAd();
#endif	
#if UNITY_IPHONE
		FlurryAdIOS.Instance().DestroyBannerAd();
#endif
	}
	
	/**
	 * Load an Interstitial Ad and show it immediately once loaded. 	 
	 */
	public void LoadInterstitialAd()
	{
#if UNITY_ANDROID		
		FlurryAdAndroid.Instance().LoadInterstitialAd(false);
#endif	
#if UNITY_IPHONE
		FlurryAdIOS.Instance().LoadInterstitialAd(false);
#endif
	}	
	
	/**
	 * Load an Interstitial Ad.	 
	 * 
	 * @param hide
	 *           bool - whether the ad should keep being invisible after loaded,
	 *                  true for making the ad hidden, false for showing the 
	 *                  ad immediately. if the parameter is set to true, then 
	 *                  you need to programmatically display the ad by calling 
	 *                  ShowInterstitialAd() after you get notified with event
	 *                  OnReceiveAdInterstitial from FlurryAdListener.
	 */
	public void LoadInterstitialAd(bool hide)
	{
#if UNITY_ANDROID		
		FlurryAdAndroid.Instance().LoadInterstitialAd(hide);
#endif	
#if UNITY_IPHONE
		FlurryAdIOS.Instance().LoadInterstitialAd(hide);
#endif
	}
	
	/**
	 * Show the Interstitial Ad.
	 * 
	 * This sets the Interstitial ad to be visible.
	 */
	public void ShowInterstitialAd()
	{
#if UNITY_ANDROID		
		FlurryAdAndroid.Instance().ShowInterstitialAd();
#endif	
#if UNITY_IPHONE
		FlurryAdIOS.Instance().ShowInterstitialAd();
#endif
	}
	
	/**
	 * Disable all Ads (Banners and Interstitials).
	 * 
	 * This function is very useful when you want to disable the Ads after
	 * the user makes an In-App Purchase. In this case, you should call
	 * this function in OnPurchaseCompleted() event handler of an IAP
	 * plugin. 
	 * 
	 * This function also persists the state on the user's device so you
	 * don't need to set any variable in the PlayerPrefs.	
	 */
	public void DisableAd()
	{
#if UNITY_ANDROID		
		FlurryAdAndroid.Instance().DisableAd();
#endif	
#if UNITY_IPHONE
		FlurryAdIOS.Instance().DisableAd();
#endif
#if UNITY_WP8
		FlurryAdWP.Instance().DisableAd();
#endif		
	}
	
	/**
	 * Enable Ads (Banners and Interstitials).
	 * 
	 * This function is for re-enabling the Ads after you called DisableAd().
	 * After calling this function, you will be able to call LoadBannerAd() or
	 * LoadInterstitialAd() then. And if the "Auto Load" switch is turned on, the
	 * Ad will continue to be served then.
	 * Persistent state is also taken care of, you don't need to set any variables
	 * in the PlayerPrefs either.	
	 */
	public void EnableAd()
	{
#if UNITY_ANDROID		
		FlurryAdAndroid.Instance().EnableAd();
#endif	
#if UNITY_IPHONE
		FlurryAdIOS.Instance().EnableAd();
#endif
#if UNITY_WP8
		FlurryAdWP.Instance().EnableAd();
#endif		
	}
	
	/**
	 * Check if Ad is enabled or not.
	 * 
	 * This function is for getting the current state of the Ad.
	 * 
	 * @result bool - True if the Ad is enabled, false if the Ad has 
	 *                been disabled by calling DisableAd().
	 */
	public bool IsAdEnabled()
	{
		bool result = true;
#if UNITY_ANDROID		
		result = FlurryAdAndroid.Instance().IsAdEnabled();
#endif	
#if UNITY_IPHONE
		result = FlurryAdIOS.Instance().IsAdEnabled();
#endif
#if UNITY_WP8
		result = FlurryAdWP.Instance().IsAdEnabled();
#endif		
		return result;
	}		
	
	#endregion
}
