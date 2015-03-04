using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	
    //private bool _isTouchAction = false;

    //void Start() {
    //    PlayerPrefs.SetInt("EnterdMiniGame", 0);
    //    PlayerPrefs.SetInt("StartFruitsAmountShowed", 0);
    //}
    //void Update () {
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;

    //    if(Application.platform == RuntimePlatform.OSXEditor) {
    //        if(Input.GetMouseButtonDown(0))
    //            _isTouchAction = true;
    //        else
    //            _isTouchAction = false;
    //    } else {
    //        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    //            _isTouchAction = true;
    //        else
    //            _isTouchAction = false;
    //    }

    //    if (Physics.Raycast (ray,out hit) && hit.collider.tag == "StartGameCharacter" && _isTouchAction) {
    //        switch(hit.collider.name) {
    //            case "zaba_skin": PlayerPrefs.SetInt("Character", 5); break;
    //            case "tygrys_skin": PlayerPrefs.SetInt("Character", 4); break;
    //            case "pies_skin": PlayerPrefs.SetInt("Character", 3); break;
    //            case "mis_skin": PlayerPrefs.SetInt("Character", 2); break;
    //            case "hipcio_skin": PlayerPrefs.SetInt("Character", 1); break;
    //        }

    //        Application.LoadLevel("Farm");
    //    }
    //}
}
