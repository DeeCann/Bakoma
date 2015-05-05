using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	public GameObject not_ram;
	public GameObject not_free;
	private int flag;

	void Start () {
		flag = 0;
		#if UNITY_ANDROID || UNITY_IPHONE
			//call this every time you want to get updated data
			//if it returns false no memory data was retrieved
			bool mi = meminfo.getMemInfo();
			if(!mi) Debug.Log("Could not get Memory Info");
		if(meminfo.minf.memtotal<500000){not_ram.SetActive (true);flag=1;}
		if(meminfo.minf.memfree<1000){not_free.SetActive (true);flag=1;}
		if(flag==0){Application.LoadLevelAsync(1);}
		#endif

	}


	void Update () {
	
	}
	
	void OnGUI(){

		#if UNITY_ANDROID || UNITY_IPHONE
			//if(GUI.Button(new Rect(10,Screen.height-50,180,40),"Get MemInfo")){meminfo.getMemInfo();}
		#endif

		#if UNITY_ANDROID
			//GUI.Label(new Rect(50,10,250,40),"memtotal: " + meminfo.minf.memtotal.ToString() + " kb");
			//GUI.Label(new Rect(50,50,250,40),"memfree: " + meminfo.minf.memfree.ToString() + " kb");
			//GUI.Label(new Rect(50,90,250,40),"active: " + meminfo.minf.active.ToString() + " kb");
			//GUI.Label(new Rect(50,130,250,40),"inactive: " + meminfo.minf.inactive.ToString() + " kb");
			//GUI.Label(new Rect(50,170,250,40),"cached: " + meminfo.minf.cached.ToString() + " kb");
			//GUI.Label(new Rect(50,210,250,40),"swapcached: " + meminfo.minf.swapcached.ToString() + " kb");
			//GUI.Label(new Rect(50,250,250,40),"swaptotal: " + meminfo.minf.swaptotal.ToString() + " kb");
			//GUI.Label(new Rect(50,290,250,40),"swapfree: " + meminfo.minf.swapfree.ToString() + " kb");
		#endif
		
		#if UNITY_IPHONE
			GUI.Label(new Rect(50,10,250,40),"memtotal: " + meminfo.minf.memtotal.ToString() + " bytes");
			GUI.Label(new Rect(50,50,250,40),"memfree: " + meminfo.minf.memfree.ToString() + " bytes");
			GUI.Label(new Rect(50,90,250,40),"memused: " + meminfo.minf.memused.ToString() + " bytes");		
		#endif
	}
	
}
