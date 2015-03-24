/**
 * FlurryAdListener.cs
 * 
 * FlurryAdListener listens to the Admob Ad events.
 * File location: Assets/Scripts/NeatPlug/Ads/FlurryAd/FlurryAdListener.cs
 * 
 * Please read the code comments carefully, or visit 
 * http://www.neatplug.com/integration-guide-unity3d-flurry-ad-plugin to find information 
 * about how to integrate and use this program.
 * 
 * End User License Agreement: http://www.neatplug.com/eula
 * 
 * (c) Copyright 2012 NeatPlug.com All Rights Reserved.
 * 
 * @version 1.6.0
 * @sdk_version(android) 5.1.0
 * @sdk_version(ios) 6.0.0
 *
 */

using UnityEngine;
using System.Collections;

public class FlurryAdListener : MonoBehaviour {
	
	private bool _debug = true;	
	
	private static bool _instanceFound = false;
	
	void Awake()
	{
		// Do not modify the codes below.		
		FlurryAdAgent.RetainGameObject(ref _instanceFound, gameObject, null);
		FlurryAd.Instance();
	}
	
	void OnEnable()
	{
		// Register the Ad events.
		// Do not modify the codes below.	
		FlurryAdAgent.OnReceiveAd += OnReceiveAd;
		FlurryAdAgent.OnFailedToReceiveAd += OnFailedToReceiveAd;
		FlurryAdAgent.OnPresentScreen += OnPresentScreen;
		FlurryAdAgent.OnDismissScreen += OnDismissScreen;
		FlurryAdAgent.OnLeaveApplication += OnLeaveApplication;
		FlurryAdAgent.OnReceiveAdInterstitial += OnReceiveAdInterstitial;
		FlurryAdAgent.OnFailedToReceiveAdInterstitial += OnFailedToReceiveAdInterstitial;
		FlurryAdAgent.OnPresentScreenInterstitial += OnPresentScreenInterstitial;
		FlurryAdAgent.OnDismissScreenInterstitial += OnDismissScreenInterstitial;
		FlurryAdAgent.OnLeaveApplicationInterstitial += OnLeaveApplicationInterstitial;	
		FlurryAdAgent.OnAdShown += OnAdShown;
		FlurryAdAgent.OnAdHidden += OnAdHidden;	
		FlurryAdAgent.OnVideoAdFinished += OnVideoAdFinished;
	}

	void OnDisable()
	{
		// Unregister the Ad events.
		// Do not modify the codes below.		
		FlurryAdAgent.OnReceiveAd -= OnReceiveAd;
		FlurryAdAgent.OnFailedToReceiveAd -= OnFailedToReceiveAd;
		FlurryAdAgent.OnPresentScreen -= OnPresentScreen;
		FlurryAdAgent.OnDismissScreen -= OnDismissScreen;
		FlurryAdAgent.OnLeaveApplication -= OnLeaveApplication;
		FlurryAdAgent.OnReceiveAdInterstitial -= OnReceiveAdInterstitial;
		FlurryAdAgent.OnFailedToReceiveAdInterstitial -= OnFailedToReceiveAdInterstitial;
		FlurryAdAgent.OnPresentScreenInterstitial -= OnPresentScreenInterstitial;
		FlurryAdAgent.OnDismissScreenInterstitial -= OnDismissScreenInterstitial;
		FlurryAdAgent.OnLeaveApplicationInterstitial -= OnLeaveApplicationInterstitial;
		FlurryAdAgent.OnAdShown -= OnAdShown;
		FlurryAdAgent.OnAdHidden -= OnAdHidden;	
		FlurryAdAgent.OnVideoAdFinished -= OnVideoAdFinished;
	}	
	
	/**
	 * Fired when a banner Ad is received successfully.
	 */
	void OnReceiveAd()
	{
		if (_debug)
			Debug.Log (this.GetType().ToString() + " - OnReceiveAd() Fired.");
		
		/// Your code here...
	}
	
	/**
	 * Fired when a banner Ad fails to be received.
	 * 
	 * @param err
	 *          string - The error string
	 */
	void OnFailedToReceiveAd(string err)
	{
		if (_debug)
			Debug.Log (this.GetType().ToString() + " - OnFailedToReceiveAd() Fired. Error: " + err);
		
		/// Your code here...
	}
	
	/**
	 * Fired when a Banner Ad screen is presented.
	 */
	void OnPresentScreen()
	{
		if (_debug)
			Debug.Log (this.GetType().ToString() + " - OnPresentScreen() Fired.");
		
		/// Your code here...
	}
	
	/**
	 * Fired when a Banner Ad screen is dismissed.
	 */
	void OnDismissScreen()
	{
		if (_debug)
			Debug.Log (this.GetType().ToString() + " - OnDismissScreen() Fired.");
		
		/// Your code here...
	}	
	
	/**
	 * Fired when the App loses focus after a Banner Ad is clicked.
	 */
	void OnLeaveApplication()
	{
		if (_debug)
			Debug.Log (this.GetType().ToString() + " - OnLeaveApplication() Fired.");
		
		/// Your code here...
	}
	
	/**
	 * Fired when an Interstitial Ad is received successfully.
	 */
	void OnReceiveAdInterstitial()
	{
		if (_debug)
			Debug.Log (this.GetType().ToString() + " - OnReceiveAdInterstitial() Fired.");
		
		/// Your code here...
	}
	
	/**
	 * Fired when an Interstitial Ad fails to be received.
	 * 
	 *  @param err
	 *          string - The error string
	 */
	void OnFailedToReceiveAdInterstitial(string err)
	{
		if (_debug)
			Debug.Log (this.GetType().ToString() + " - OnFailedToReceiveAdInterstitial() Fired. Error: " + err);
		
		/// Your code here...
	}
	
	/**
	 * Fired when an Interstitial Ad screen is presented.
	 */
	void OnPresentScreenInterstitial()
	{
		if (_debug)
			Debug.Log (this.GetType().ToString() + " - OnPresentScreenInterstitial() Fired.");
		
		/// Your code here...
	}
	
	/**
	 * Fired when an Interstitial Ad screen is dismissed.
	 */
	void OnDismissScreenInterstitial()
	{
		if (_debug)
			Debug.Log (this.GetType().ToString() + " - OnDismissScreenInterstitial() Fired.");
		
		/// Your code here...
	}
	
	/**
	 * Fired when the App loses focus after an Interstitial Ad is clicked.
	 */
	void OnLeaveApplicationInterstitial()
	{
		if (_debug)
			Debug.Log (this.GetType().ToString() + " - OnLeaveApplicationInterstitial() Fired.");
		
		/// Your code here...
	}
	
	/**
	 * Fired when the banner Ad is shown.
	 */
	void OnAdShown()
	{
		if (_debug)
			Debug.Log (this.GetType().ToString() + " - OnAdShown() Fired.");
		
		/// Your code here...
	}
	
	/**
	 * Fired when the banner Ad is hidden.
	 */
	void OnAdHidden()
	{
		if (_debug)
			Debug.Log (this.GetType().ToString() + " - OnAdHidden() Fired.");
		
		/// Your code here...
	}
	
	/**
	 * Fired when a video Ad play is completed.
	 */
	void OnVideoAdFinished()
	{
		if (_debug)
			Debug.Log (this.GetType().ToString() + " - OnVideoAdFinished() Fired.");
		
		/// Your code here...
	}	
	
}
