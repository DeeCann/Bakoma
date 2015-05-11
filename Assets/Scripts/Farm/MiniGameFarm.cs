using UnityEngine;
using System.Collections;

public class MiniGameFarm : MonoBehaviour {
	private GameObject _myCharacter;
	private Vector3 _myCharacterStartPosition = new Vector3(-16f,0.5f,0);

	void Awake () {
		//Debug.Log(PlayerPrefs.GetString("Character_1"));

		switch(PlayerPrefs.GetString("Current_character")) {

		case "Frog": _myCharacter = (GameObject)Instantiate(Resources.Load("zaba"), _myCharacterStartPosition, Quaternion.identity); break;
		case "Bear": _myCharacter = (GameObject)Instantiate(Resources.Load("mis"), _myCharacterStartPosition, Quaternion.identity); break;
		case "Dog": _myCharacter = (GameObject)Instantiate(Resources.Load("pies"), _myCharacterStartPosition, Quaternion.identity);  break;
		case "Tiger": _myCharacter = (GameObject)Instantiate(Resources.Load("tygrys"), _myCharacterStartPosition, Quaternion.identity);  break;
		case "Hippo": _myCharacter = (GameObject)Instantiate(Resources.Load("hipcio"), _myCharacterStartPosition, Quaternion.identity); break;
		default:  _myCharacter = (GameObject)Instantiate(Resources.Load("zaba"), _myCharacterStartPosition, Quaternion.identity);  break;
		}


		//_myCharacter = (GameObject)Instantiate(Resources.Load("pies"), _myCharacterStartPosition, Quaternion.identity);
	}
}
