using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {


    void Start()
    {
		Screen.orientation = ScreenOrientation.Landscape;
        Application.LoadLevel(PlayerPrefs.GetString("LoadLevelName"));
    }


    
}
