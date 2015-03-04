using UnityEngine;
using System.Collections;

public class StartGuiControler : MonoBehaviour {

	public void PlayBoardGame() {
		Application.LoadLevel (1);
	}

	public void PlayMiniGame_Farm() {
		Application.LoadLevel (2);
	}
}
