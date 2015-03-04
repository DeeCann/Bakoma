using UnityEngine;
using System.Collections;

public class MiniGameFarm : MonoBehaviour {
	private GameObject _myCharacter;
	private Vector3 _myCharacterStartPosition = new Vector3(0,0.5f,0);

	void Awake () {
		switch(PlayerPrefs.GetInt("Character")) {
			case 5: _myCharacter = (GameObject)Instantiate(Resources.Load("zaba"), _myCharacterStartPosition, Quaternion.identity); break;
			case 4: _myCharacter = (GameObject)Instantiate(Resources.Load("tygrys"), _myCharacterStartPosition, Quaternion.identity); break;
			case 3: _myCharacter = (GameObject)Instantiate(Resources.Load("pies"), _myCharacterStartPosition, Quaternion.identity); break;
			case 2: _myCharacter = (GameObject)Instantiate(Resources.Load("mis"), _myCharacterStartPosition, Quaternion.identity); break;
			case 1: _myCharacter = (GameObject)Instantiate(Resources.Load("hipcio"), _myCharacterStartPosition, Quaternion.identity); break;
			default:  _myCharacter = (GameObject)Instantiate(Resources.Load("zaba"), _myCharacterStartPosition, Quaternion.identity); break;
		}

		//_myCharacter = (GameObject)Instantiate(Resources.Load("pies"), _myCharacterStartPosition, Quaternion.identity);
	}
}
