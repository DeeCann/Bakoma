/**
 * FlurryAdTest.cs
 * 
 * A Test script for demonstrating the usage of FlurryAd Plugin.
 * 
 * Please read the code comments carefully, or visit 
 * http://www.neatplug.com/integration-guide-unity3d-flurry-ad-plugin to find information 
 * about how to integrate and use this program.
 * 
 * End User License Agreement: http://www.neatplug.com/eula
 * 
 * (c) Copyright 2013 NeatPlug.com All Rights Reserved. 
 *
 */

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FlurryAdTest : MonoBehaviour {	
	
	private float _buttonWidth =  (Mathf.Min(Screen.height, Screen.width) - 40f) / 3f;	
	private float _buttonHeight = 60f;	
	private float _topMargin = 30f;
	
	void Awake() {
		GameObject go = GameObject.Find("FlurryAdAgent");
		if (go == null)
		{
			string levelName = Application.loadedLevelName;			
			if (!levelName.Equals("SampleScene", StringComparison.InvariantCultureIgnoreCase))
			{
				Application.LoadLevel("SampleScene");
			}
		}		
	}
	
	void OnGUI() {	
		
		UnityEngine.GUI.Label(new Rect(10f, 10f, Screen.width * 0.5f, _buttonHeight), Application.loadedLevelName);
		
		if (UnityEngine.GUI.Button (new Rect(10f, 100f + _topMargin, _buttonWidth, _buttonHeight), "Hide Banner")) {		
			FlurryAd.Instance().HideBannerAd();
		}
		
		if (UnityEngine.GUI.Button (new Rect(20f + _buttonWidth, 100f + _topMargin, _buttonWidth, _buttonHeight), "Show Banner")) {		
			FlurryAd.Instance().ShowBannerAd();
		}		
		
		if (UnityEngine.GUI.Button (new Rect(30f + 2f * _buttonWidth, 100f + _topMargin, _buttonWidth, _buttonHeight), "Destroy Banner")) {		
			FlurryAd.Instance().DestroyBannerAd();
		}
		
		if (UnityEngine.GUI.Button (new Rect(10f, 170f + _topMargin, _buttonWidth, _buttonHeight), "Load Banner (Bottom)")) {			 
			FlurryAd.Instance().LoadBannerAd(FlurryAd.BannerAdType.Universal_Banner, FlurryAd.AdLayout.Bottom_Centered);	
		}		
		
		if (UnityEngine.GUI.Button (new Rect(20f + _buttonWidth, 170f + _topMargin, _buttonWidth, _buttonHeight), "Load Banner (Top)")) {			
			FlurryAd.Instance().LoadBannerAd(FlurryAd.BannerAdType.Universal_Banner, FlurryAd.AdLayout.Top_Centered);
		}		
		
		if (UnityEngine.GUI.Button (new Rect(30f + 2f * _buttonWidth, 170f + _topMargin, _buttonWidth, _buttonHeight), "Load & Show\nInterstitial")) {		
			FlurryAd.Instance().LoadInterstitialAd(false);	
		}		
		
		
		if (UnityEngine.GUI.Button (new Rect(10f, 240f + _topMargin, _buttonWidth, _buttonHeight), "Load & Hide\nInterstitial")) {			 
			FlurryAd.Instance().LoadInterstitialAd(true);
		}		
		
		if (UnityEngine.GUI.Button (new Rect(20f + _buttonWidth, 240f + _topMargin, _buttonWidth, _buttonHeight), "Show Interstitial")) {			
			FlurryAd.Instance().ShowInterstitialAd();
		}		
			
		if (UnityEngine.GUI.Button (new Rect(30f + 2f * _buttonWidth, 240f + _topMargin, _buttonWidth, _buttonHeight), "Disable Ad\n(Can be used with IAP)")) {		
			FlurryAd.Instance().DisableAd();
		}	
		
		if (UnityEngine.GUI.Button (new Rect(10f, 310f + _topMargin, _buttonWidth, _buttonHeight), "Enable Ad\n(Re-enable the Ads)")) {			
			FlurryAd.Instance().EnableAd();	
		}
		
		if (UnityEngine.GUI.Button (new Rect(20f + _buttonWidth, 310f + _topMargin, _buttonWidth, _buttonHeight), "Is Ad Enabled?")) {			
			Debug.Log("Is Ad Enabled? : " + FlurryAd.Instance().IsAdEnabled().ToString());
		}		
		
		if (UnityEngine.GUI.Button (new Rect(30f + 2f * _buttonWidth, 310f + _topMargin, _buttonWidth, _buttonHeight), "Load Next Scene")) {			
			string levelName = Application.loadedLevelName;
			string nextScene = null;
			
			if (levelName.Equals("SampleScene", StringComparison.InvariantCultureIgnoreCase))
			{
				nextScene = "SampleSceneNext1";
			}
			else if (levelName.Equals("SampleSceneNext1", StringComparison.InvariantCultureIgnoreCase))
			{
				nextScene = "SampleSceneNext2";
			}
			else if (levelName.Equals("SampleSceneNext2", StringComparison.InvariantCultureIgnoreCase))
			{
				nextScene = "SampleScene";
			}
			
			if (nextScene != null)
			{
				Application.LoadLevel(nextScene);	
			}
		}
		
		
	}
		
	// Quit test app when back button is tapped.
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{					
			Application.Quit();
		}	
	}
}
