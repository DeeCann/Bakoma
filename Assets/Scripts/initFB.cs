using UnityEngine;
using System.Collections;

public class initFB : MonoBehaviour {
	
	// Use this for initialization
	void Awake(){
		FB.Init(SetInit, OnHideUnity);
	}
	void Start () {
		
		StartCoroutine("FBinstall");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void SetInit() {
		enabled = true; 
		// "enabled" is a magic global; this lets us wait for FB before we start rendering
	}
	
	private void OnHideUnity(bool isGameShown) {
		if (!isGameShown) {
			// pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// start the game back up - we're getting focus again
			Time.timeScale = 1;
		}
	}
	IEnumerator FBinstall() {
		yield return new WaitForSeconds(3);
		FB.PublishInstall(delegate(FBResult response) { Debug.Log(response.Text); });
		Debug.Log ("FB!");
	}
	
}
