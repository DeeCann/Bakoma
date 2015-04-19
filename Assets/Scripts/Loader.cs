using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	void Awake(){
		Screen.orientation = ScreenOrientation.Landscape;
		}
    void Start()
    {

        Application.LoadLevel(PlayerPrefs.GetString("LoadLevelName"));

    }




    
}
