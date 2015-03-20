using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
    public Transform TilesContainer;
    public Transform TilesArrowContainer;
    public Transform TilesAppleContainer;
    public Transform TilesRabbirHoleContainer;
    public Transform TilesBerriesContainer;
    public Transform TilesStrawberryContainer;
    public Transform TilesTrampContainer;
    public Transform TilesBlackberryContainer;
    public Transform TilesRaspkberryContainer;
    public Transform TilesPeachContainer;
	public static Dictionary<string, int> _fruitsInGame = new Dictionary<string, int> ();
	public static Dictionary<string, int> _fruitsCollected = new Dictionary<string, int> ();
    public static List<int> tilesListUniqueIds = new List<int>();
    public static List<int> tilesArrowsListUniqueIds = new List<int>();
    public static List<int> tilesAppleListUniqueIds = new List<int>();
    public static List<int> tilesRabbitholeListUniqueIds = new List<int>();
    public static List<int> tilesBerriesListUniqueIds = new List<int>();
    public static List<int> tilesStrawberryListUniqueIds = new List<int>();
    public static List<int> tilesTrampListUniqueIds = new List<int>();
    public static List<int> tilesBlackberryListUniqueIds = new List<int>();
    public static List<int> tilesRaspberryListUniqueIds = new List<int>();
    public static List<int> tilesPeachListUniqueIds = new List<int>();
    public static GameObject GeneratedFruitsContainer;

	private static GameObject[] Players = new GameObject[5];
    private string[] characterNames = new string[] { "Hippo", "Tiger", "Dog", "Bear", "Frog" };
    private static string[] _onBoardFruitsNames = new string[] { "Apple", "Blackberry", "Blueberry", "Peach", "Raspberry", "Strawberry" };
    private static Dictionary<string, int> _myPoints = new Dictionary<string, int>() { {"Apple", 0}, {"Blackberry", 0}, {"Blueberry", 0}, {"Peach", 0}, {"Raspberry", 0}, {"Strawberry", 0} };

	private static int _playersNumber = 1;
	private static int _currentPlayerRound = 0;

	private bool _showStartFruitsAmountPanel = false;
    private static bool _playerHasSomeFruit = false;

	private static GameObject _startField;
	private GameObject _HUDControler;

    private static bool _gameHasEnded = false;

	private enum fruitsNames {
		Apple = 1,
		Raspberry = 2,
		Blueberry = 3,
		Blackberry = 4,
		Peach = 5,
		Strawberry = 6
	}

	void Awake() {
        Physics.gravity = new Vector3(0, -9.8f, 0);
		_startField = GameObject.FindGameObjectsWithTag(Tags.StartPoint)[Random.Range(1,2)];
		_HUDControler = GameObject.FindGameObjectWithTag(Tags.HUDControler);

        if (PlayerPrefs.GetInt("EnterdMiniGame") == 0)
        {
           
            /* narazie sinlge player */


            //for (int i = 0; i < _playersNumber; i++)
            //{

            //    //GameObject player = Instantiate(Resources.Load(characterNames[i]), Vector3.zero, Quaternion.identity) as GameObject;
            //    GameObject player = Instantiate(Resources.Load(PlayerPrefs.GetString("CharacterSelected")), Vector3.zero, Quaternion.identity) as GameObject;
            //    player.name = characterNames[i];

            //    player.GetComponent<PlayerRoute>().StartFieldSocket = _startField.GetComponent<FieldSocket>().TakeSocketNumber;
            //    player.transform.position = _startField.GetComponent<FieldSocket>().TakeSocketVectorPosition(player.GetComponent<PlayerRoute>().StartFieldSocket);
            //    player.transform.position = new Vector3(player.transform.position.x, 0.06f, player.transform.position.z);

            //    player.GetComponent<PlayerCharacter>().PlayerNumber = i + 1;
            //    Players[i] = player;

            //    PlayerPrefs.SetString("Player" + i, characterNames[i]);
            //}

            //GameObject player = Instantiate(Resources.Load(characterNames[i]), Vector3.zero, Quaternion.identity) as GameObject;

            GameObject player = Instantiate(Resources.Load(characterNames[PlayerPrefs.GetInt("Character")]), Vector3.zero, Quaternion.identity) as GameObject;
            player.name = characterNames[PlayerPrefs.GetInt("Character")];

            player.GetComponent<PlayerRoute>().StartFieldSocket = _startField.GetComponent<FieldSocket>().TakeSocketNumber;
            player.transform.position = _startField.GetComponent<FieldSocket>().TakeSocketVectorPosition(player.GetComponent<PlayerRoute>().StartFieldSocket);
            player.transform.position = new Vector3(player.transform.position.x, 0.06f, player.transform.position.z);

            player.GetComponent<PlayerCharacter>().PlayerNumber = 1;
            Players[0] = player;

            PlayerPrefs.SetString("Player" + 0, characterNames[PlayerPrefs.GetInt("Character")]);
        }



		_currentPlayerRound = 1;

        if (PlayerPrefs.GetInt("EnterdMiniGame") == 0)
        {
            _fruitsInGame.Add(fruitsNames.Apple.ToString(), Random.Range(10, 20));
            _fruitsInGame.Add(fruitsNames.Raspberry.ToString(), Random.Range(10, 20));
            _fruitsInGame.Add(fruitsNames.Blueberry.ToString(), Random.Range(10, 20));
            _fruitsInGame.Add(fruitsNames.Blackberry.ToString(), Random.Range(10, 20));
            _fruitsInGame.Add(fruitsNames.Peach.ToString(), Random.Range(10, 20));
            _fruitsInGame.Add(fruitsNames.Strawberry.ToString(), Random.Range(10, 20));

            

            GeneratedFruitsContainer = (GameObject)Instantiate(Resources.Load("Prefabs/GeneratedFruitsContainer"), Vector3.zero, Quaternion.identity);
            GeneratedFruitsContainer.name = "GeneratedFruitsContainer";
          
            /* Normal tiles */
            foreach (Transform tile in TilesContainer.FindChild("t1").transform)
            {
                int uniqueInstanceID = Random.Range(1, 999999);
                tile.GetComponent<FieldSocket>().UniqueId = uniqueInstanceID;
                tilesListUniqueIds.Add(uniqueInstanceID);
            }

            GenerateUniqueIds(TilesArrowContainer, tilesArrowsListUniqueIds);
            GenerateUniqueIds(TilesAppleContainer, tilesAppleListUniqueIds);
            GenerateUniqueIds(TilesRabbirHoleContainer, tilesRabbitholeListUniqueIds);
            GenerateUniqueIds(TilesBerriesContainer, tilesBerriesListUniqueIds);
            GenerateUniqueIds(TilesStrawberryContainer, tilesStrawberryListUniqueIds);
            GenerateUniqueIds(TilesTrampContainer, tilesTrampListUniqueIds);
            GenerateUniqueIds(TilesBlackberryContainer, tilesBlackberryListUniqueIds);
            GenerateUniqueIds(TilesRaspkberryContainer, tilesRaspberryListUniqueIds);
            GenerateUniqueIds(TilesPeachContainer, tilesPeachListUniqueIds);

            foreach (string fruit in _onBoardFruitsNames)
                PlayerPrefs.SetInt("GamePoints_" + fruit, 0);
        }
        else {
            /* Normal tiles */
            for (int i = 0; i < tilesListUniqueIds.Count; i++)
                TilesContainer.FindChild("t1").GetChild(i).GetComponent<FieldSocket>().UniqueId = tilesListUniqueIds[i];

            /* Arrow tiles */
            for (int i = 0; i < tilesArrowsListUniqueIds.Count; i++)
                TilesArrowContainer.GetChild(i).GetComponent<FieldSocket>().UniqueId = tilesArrowsListUniqueIds[i];

            /* Apple tiles */
            for (int i = 0; i < tilesAppleListUniqueIds.Count; i++)
                TilesAppleContainer.GetChild(i).GetComponent<FieldSocket>().UniqueId = tilesAppleListUniqueIds[i];

            /* Rabbit hoile tiles */
            for (int i = 0; i < tilesRabbitholeListUniqueIds.Count; i++)
                TilesRabbirHoleContainer.GetChild(i).GetComponent<FieldSocket>().UniqueId = tilesRabbitholeListUniqueIds[i];

            /* Berries tiles */
            for (int i = 0; i < tilesBerriesListUniqueIds.Count; i++)
                TilesBerriesContainer.GetChild(i).GetComponent<FieldSocket>().UniqueId = tilesBerriesListUniqueIds[i];

            /* Strawberry tiles */
            for (int i = 0; i < tilesStrawberryListUniqueIds.Count; i++)
                TilesStrawberryContainer.GetChild(i).GetComponent<FieldSocket>().UniqueId = tilesStrawberryListUniqueIds[i];

            /* Blackberry tiles */
            for (int i = 0; i < tilesBlackberryListUniqueIds.Count; i++)
                TilesBlackberryContainer.GetChild(i).GetComponent<FieldSocket>().UniqueId = tilesBlackberryListUniqueIds[i];

            /* Tramp tiles */
            for (int i = 0; i < tilesTrampListUniqueIds.Count; i++)
                TilesTrampContainer.GetChild(i).GetComponent<FieldSocket>().UniqueId = tilesTrampListUniqueIds[i];

            /* Raspberry tiles */
            for (int i = 0; i < tilesRaspberryListUniqueIds.Count; i++)
                TilesRaspkberryContainer.GetChild(i).GetComponent<FieldSocket>().UniqueId = tilesRaspberryListUniqueIds[i];

            /* Peach tiles */
            for (int i = 0; i < tilesPeachListUniqueIds.Count; i++)
                TilesPeachContainer.GetChild(i).GetComponent<FieldSocket>().UniqueId = tilesPeachListUniqueIds[i];

        }

        if (PlayerPrefs.GetInt("EnterdMiniGame") == 1)
        {
            //GameObject.Find("Hippo").gameObject.SetActive(true);
            GeneratedFruitsContainer.gameObject.SetActive(true);
        }


       
	}

	void Start() {
		Dice.CanDoDiceRoll = true;
		Screen.orientation = ScreenOrientation.Landscape;
	}

	void FixedUpdate() {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    PlayerPrefs.SetInt("EnterdMiniGame", 1);
        //    GeneratedFruitsContainer.gameObject.SetActive(false);
        //    Application.LoadLevel("Test");
        //}

		if (!_showStartFruitsAmountPanel && PlayerPrefs.GetInt("StartFruitsAmountShowed") == 0) {
			_HUDControler.GetComponent<HUD> ().ShowStartFruitsAmount ();
            PlayerPrefs.SetInt("StartFruitsAmountShowed", 1);
			_showStartFruitsAmountPanel = true;
		}

        if (_gameHasEnded) {
            _HUDControler.GetComponent<HUD>().ShowEndDemoPanel();
        }
	}

	public static GameObject GetStartField {
		get{
			return _startField;
		}
	}

	public static GameObject GetCurrentPlayer {
		get{
			return Players[_currentPlayerRound - 1];
		}
	}

    public static string GetCurrentCharacterName
    {
        get
        {
            return Players[_currentPlayerRound - 1].name;
        }
    }

    public static bool GameHasEnded {
        set {
            _gameHasEnded = value;
        }

        get {
            return _gameHasEnded;
        }
    }

    public static bool DidPlayerGetAllFruits() {
        //PlayerPrefs.SetInt("GamePoints_" + fruitsNames.Apple.ToString(), 20);
        //PlayerPrefs.SetInt("GamePoints_" + fruitsNames.Blackberry.ToString(), 20);
        //PlayerPrefs.SetInt("GamePoints_" + fruitsNames.Blueberry.ToString(), 20);
        //PlayerPrefs.SetInt("GamePoints_" + fruitsNames.Peach.ToString(), 20);
        //PlayerPrefs.SetInt("GamePoints_" + fruitsNames.Raspberry.ToString(), 20);
        //PlayerPrefs.SetInt("GamePoints_" + fruitsNames.Strawberry.ToString(), 20); 

        if (
            PlayerPrefs.GetInt("GamePoints_" + fruitsNames.Apple.ToString()) >= _fruitsInGame[fruitsNames.Apple.ToString()] &&
            PlayerPrefs.GetInt("GamePoints_" + fruitsNames.Blackberry.ToString()) >= _fruitsInGame[fruitsNames.Blackberry.ToString()] &&
            PlayerPrefs.GetInt("GamePoints_" + fruitsNames.Blueberry.ToString()) >= _fruitsInGame[fruitsNames.Blueberry.ToString()] &&
            PlayerPrefs.GetInt("GamePoints_" + fruitsNames.Peach.ToString()) >= _fruitsInGame[fruitsNames.Peach.ToString()] &&
            PlayerPrefs.GetInt("GamePoints_" + fruitsNames.Raspberry.ToString()) >= _fruitsInGame[fruitsNames.Raspberry.ToString()] &&
            PlayerPrefs.GetInt("GamePoints_" + fruitsNames.Strawberry.ToString()) >= _fruitsInGame[fruitsNames.Strawberry.ToString()]
        ) {
            GameHasEnded = true;
            
            return true;
        }

        return false;
    }

	public static void NextRound() {
		if(_currentPlayerRound == _playersNumber)
			_currentPlayerRound = 1;
		else
			_currentPlayerRound++;

		PinchZoom.ResetZoom();
	}

    public static void SetFruitPoint(string fruit, int amount) {
        //_myPoints[fruit] = _myPoints[fruit] + amount;
		//Debug.Log (_myPoints ["Apple"]);
		//Debug.Log (_myPoints ["Blackberry"]);
		//Debug.Log (_myPoints ["Blueberry"]);
		//Debug.Log (_myPoints ["Peach"]);
		//Debug.Log (_myPoints ["Raspberry"]);
		//Debug.Log (_myPoints ["Strawberry"]);

        PlayerPrefs.SetInt("GamePoints_" + fruit, PlayerPrefs.GetInt ("GamePoints_"+fruit)+amount);
		PlayerPrefs.Save ();
        FruitsPanel.SetPoint(fruit);
        _playerHasSomeFruit = true;
    }

    public static void RemoveRandomFruitPoint(int amount)
    {
        if (_playerHasSomeFruit)
        {
            bool foundFruitsGreaterThanZero = false;
            int fruitRandomName = 0;
            while (!foundFruitsGreaterThanZero)
            {
                fruitRandomName = Random.Range(0, 6);
				if (PlayerPrefs.GetInt ("GamePoints_"+_onBoardFruitsNames[fruitRandomName]) > 0)
                {
                    SetFruitPoint(_onBoardFruitsNames[fruitRandomName], amount * -1);
                    foundFruitsGreaterThanZero = true;
                }
            }

            FruitsPanel.SetPoint(_onBoardFruitsNames[fruitRandomName]);
        }
    }

    private void GenerateUniqueIds(Transform container, List<int> list) {
        foreach (Transform tile in container)
        {
            int uniqueInstanceID = Random.Range(1, 999999);
            tile.GetComponent<FieldSocket>().UniqueId = uniqueInstanceID;
            list.Add(uniqueInstanceID);
        }
    }
} 
