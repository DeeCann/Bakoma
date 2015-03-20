using UnityEngine;
using System.Collections;

public class MinigameField : MonoBehaviour
{
    public enum MiniGameName
    {
        Apple = 1,
        Blackberry = 2,
        Blueberry = 3,
        Peach = 4,
        Raspberry = 5,
        Strawberry = 6
    }

    public MiniGameName _minigameNames;
    private Field FieldObj;
    private bool _hasPlayerForMiniGame = false;
    private float _playerEnteredTime = 0;
    private AsyncOperation async;
	private int rand_game;


    void Awake()
    {
        FieldObj = new Field();
        gameObject.GetComponent<FieldSocket>().MyFieldObject = FieldObj;
    }

    void Update()
    {
        if (_hasPlayerForMiniGame && _playerEnteredTime + 1 < Time.time)
        {
            async.allowSceneActivation = true;
            _hasPlayerForMiniGame = false;
        }
    }

    void OnTriggerEnter(Collider playerCollider)
    {
		rand_game = Random.Range (1, 3);
		Debug.Log (rand_game);
		if (rand_game == 1) {
						if (playerCollider.tag == "Player") {
								Debug.Log ("minigame_enter");
								if (playerCollider.gameObject.GetComponent<PlayerRoute> ().NumberOfFieldsToGo == 1) {
					
										PlayerPrefs.SetInt ("EnterdMiniGame", 1);
										PlayerPrefs.SetInt ("Difficulty", Random.Range (1,4));
										PlayerPrefs.SetString ("MiniGameFruit", _minigameNames.ToString ());
					
										GameObject.Find ("GeneratedFruitsContainer").gameObject.SetActive (false);
										//GameObject.Find("Hippo").gameObject.SetActive(false);
										StartCoroutine ("LoadGame");
										//Application.LoadLevel("Test");
					
										_hasPlayerForMiniGame = true;
										_playerEnteredTime = Time.time;
								}

						}
						;
				}
		if (rand_game == 2) {
					if (playerCollider.tag == "Player") {
								Debug.Log ("minigame_enter");
								if (playerCollider.gameObject.GetComponent<PlayerRoute> ().NumberOfFieldsToGo == 1) {
					
										PlayerPrefs.SetInt ("EnterdMiniGame", 1);
										PlayerPrefs.SetInt ("Difficulty", 1);
										PlayerPrefs.SetString ("MiniGameQuiz", _minigameNames.ToString ());
					
										GameObject.Find ("GeneratedFruitsContainer").gameObject.SetActive (false);
										//GameObject.Find("Hippo").gameObject.SetActive(false);
										StartCoroutine ("LoadQuiz");
										//Application.LoadLevel("Test");
					
										_hasPlayerForMiniGame = true;
										_playerEnteredTime = Time.time;
								}

						}
						;
				}
    }


    public Field GetFieldObject
    {
        get
        {
            return FieldObj;
        }
    }

    IEnumerator LoadGame()
    {

        PlayerPrefs.SetString("LoadLevelName", "Trampoliny");
        async = Application.LoadLevelAsync("Loader");
        async.allowSceneActivation = false;
        yield return async;
    }

	IEnumerator LoadQuiz()
	{
		PlayerPrefs.SetString("LoadLevelName", "quiz");
		async = Application.LoadLevelAsync("Loader");
		async.allowSceneActivation = false;
		yield return async;
		}

}
