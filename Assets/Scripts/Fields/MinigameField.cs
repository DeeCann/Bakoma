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

    void Start() {
        for (int i = 0; i <= 4; i++)
        {
            if (PlayerPrefs.HasKey("FieldSocket_" + gameObject.GetComponent<FieldSocket>().uniqueInstanceID + "_" + i))
                gameObject.GetComponent<FieldSocket>().LockSocket = i;
        }
    }

    void Update()
    {
        if (_hasPlayerForMiniGame && _playerEnteredTime + 1 < Time.time)
        {
            PlayerPrefs.SetInt("FieldSocket_" + gameObject.GetComponent<FieldSocket>().uniqueInstanceID + "_" + gameObject.GetComponent<FieldSocket>().GetSocketNumber, 1);
                    
            async.allowSceneActivation = true;
            foreach (GameObject _players in GameObject.FindGameObjectsWithTag("Player")) {
                _players.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
                _players.GetComponentInChildren<Projector>().enabled = false;
            }
            _hasPlayerForMiniGame = false;
        }
    }

    void OnTriggerEnter(Collider playerCollider)
    {
<<<<<<< HEAD
        

        rand_game = Random.Range(1, 101);
        rand_game = 90;
        Debug.Log(rand_game);
        if (rand_game >= 70&&rand_game<=85)
=======
        if (playerCollider.tag == "Player" && playerCollider.gameObject.GetComponent<PlayerRoute>().NumberOfFieldsToGo == 1)
>>>>>>> 27b1c786f8404ad87d3e1dbcdc48d1bfd19856ea
        {
            rand_game = Random.Range(1, 101);

            if (rand_game >= 70 && rand_game<=85)
            {
                PlayerPrefs.SetInt("EnterdMiniGame", 1);
                   
                PlayerPrefs.SetInt("Difficulty", PlayerPrefs.GetInt("CharacterAge_" + Game.GetCurrentPlayerRound));
                PlayerPrefs.SetString("MiniGameFruit", _minigameNames.ToString());

                GameObject.Find("GeneratedFruitsContainer").gameObject.SetActive(false);
                //GameObject.Find("Hippo").gameObject.SetActive(false);
                StartCoroutine("LoadGame");
                //Application.LoadLevel("Test");

                _hasPlayerForMiniGame = true;
                _playerEnteredTime = Time.time;


                Game._hasEnteredMinigameField = true;
            }
		    else if (rand_game >85)
		    {
				PlayerPrefs.SetInt("EnterdMiniGame", 1);
				PlayerPrefs.SetInt("Difficulty", 1);
				PlayerPrefs.SetString("MiniGameFruit", _minigameNames.ToString());
					
				GameObject.Find("GeneratedFruitsContainer").gameObject.SetActive(false);
				//GameObject.Find("Hippo").gameObject.SetActive(false);
				StartCoroutine("LoadFarm");
				//Application.LoadLevel("Test");
					
				_hasPlayerForMiniGame = true;
				_playerEnteredTime = Time.time;

                Game._hasEnteredMinigameField = true;
		    }
            else if (rand_game <70)
            {
                PlayerPrefs.SetInt("EnterdMiniGame", 1);
                PlayerPrefs.SetInt("Difficulty", PlayerPrefs.GetInt("CharacterAge_" + Game.GetCurrentPlayerRound));
                PlayerPrefs.SetString("MiniGameQuiz", _minigameNames.ToString());

                GameObject.Find("GeneratedFruitsContainer").gameObject.SetActive(false);
                   
                StartCoroutine("LoadQuiz");
                //Application.LoadLevel("Test");

                _hasPlayerForMiniGame = true;
                _playerEnteredTime = Time.time;

                Game._hasEnteredMinigameField = true;
            }
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

	IEnumerator LoadFarm()
	{
		PlayerPrefs.SetString("LoadLevelName", "Farm");
		async = Application.LoadLevelAsync("Loader");
		async.allowSceneActivation = false;
		yield return async;
	}

}
