using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Cards : MonoBehaviour {
	
	private string _defaultCardsDirectory = "Assets/Resources/Textures/DefaultCards/";
	
	private static Dictionary<int, string> _trapCardDictionary = new Dictionary<int, string>();
	private static Dictionary<int, string> _playerCardDictionary = new Dictionary<int, string>();
	private static Dictionary<int, List<PlayersCards>> _cardsLinks = new Dictionary<int, List<PlayersCards>>();
	private static Dictionary<string, List<int>> _playersCardsLinks = new Dictionary<string, List<int>>();
	
	private static int _randomTrapCardIdSelected = 0;
	private static int _playerCardForTrapSelected = 0;
	
	private class PlayersCards
	{
		private string _playername;
		private int _playerCardId;
		
		public PlayersCards(string playerName, int cardId) {
			_playername = playerName;
			_playerCardId = cardId;
		}
		
		public string GetPlayerName {
			get {
				return _playername;
			}
		}
		
		public int GetCardId
		{
			get
			{
				return _playerCardId;
			}
		}
	}
	
	void Awake() {

		if(!PlayerPrefs.HasKey("FirstRun"))
		{
			PlayerPrefs.DeleteAll ();
			PlayerPrefs.DeleteKey ("HasSomeCards");
			PlayerPrefs.SetInt ("FirstRun",1);
		}
		if (!PlayerPrefs.HasKey("HasSomeCards"))
		{
			
			PlayerPrefs.SetInt("HasSomeCards", 1);
			
			//if (Application.platform == RuntimePlatform.OSXWebPlayer || Application.platform == RuntimePlatform.WindowsWebPlayer)
			GenerateDefaultCardsForWeb();
			
			//GenerateTrapCardsDictionary();
			//GeneratePlayerCardsDictionary();
			//GeneratePlayersCardsLinks();
			//GeneratePlayerTrapCardsLinks();
			//else
			//GenerateDefaultCards();
		}
		GenerateTrapCardsDictionary();
		GeneratePlayerCardsDictionary();
		GeneratePlayersCardsLinks();
		GeneratePlayerTrapCardsLinks();
		//PlayerPrefs.DeleteAll ();
		//PlayerPrefs.DeleteKey ("HasSomeCards");
		
	}
	
	
	
	//private void GenerateDefaultCards() {
	//    string[] files = Directory.GetFiles(_defaultCardsDirectory, "*.png", SearchOption.AllDirectories);
	//    string currentAnimalName = "";
	//    string lastAnimalName = "";
	//    int animalCardNumber = 0;
	//    foreach (var file in files)
	//    {
	//        currentAnimalName = Path.GetDirectoryName(file).Split('/').Last();
	
	//        if (lastAnimalName != currentAnimalName && lastAnimalName != "")
	//        {
	//            PlayerPrefs.SetInt(lastAnimalName + "_Cards_Amount", animalCardNumber);
	//            animalCardNumber = 0;
	//        }
	//        string cardName = Path.GetFileName(file).Split('.').First();
	//        PlayerPrefs.SetString(currentAnimalName + "_Card_" + (animalCardNumber + 1) + "_Name", cardName);
	//        PlayerPrefs.SetInt(currentAnimalName + "_Card_" + (animalCardNumber + 1) + "_Amount", 1);
	
	//        lastAnimalName = currentAnimalName;
	//        animalCardNumber++;
	//    }
	
	//    PlayerPrefs.SetInt(lastAnimalName + "_Cards_Amount", animalCardNumber);
	//}
	
	public static int GetRandomTrap {
		get {
			_randomTrapCardIdSelected = Random.Range(1, _trapCardDictionary.Count);
			return _randomTrapCardIdSelected;
		}
	}
	
	public static string TrapCardName(int cardId) {
		return _trapCardDictionary[cardId];
	}
	
	public static string GetProperCardForTrap {
		get {
			bool cardFound = false;
			foreach (PlayersCards cardElement in _cardsLinks[_randomTrapCardIdSelected])
			{
				if ((cardElement.GetPlayerName == Game.GetCurrentCharacterName && PlayerPrefs.GetInt("Card_" + cardElement.GetCardId + "_Amount") >= 1))
				{
					_playerCardForTrapSelected = cardElement.GetCardId;
					cardFound = true;
				}
			}
			
			if (!cardFound)
				_playerCardForTrapSelected = 0;
			
			return _playerCardDictionary[_playerCardForTrapSelected];
		}
	}
	
	public static string GetPlayerCardName(int cardId) {
		return _playerCardDictionary[cardId];
	}
	
	public static void RemovePlayerUsedCard() {
		print(_playerCardForTrapSelected + ": " + PlayerPrefs.GetInt("Card_" + _playerCardForTrapSelected + "_Amount"));
		PlayerPrefs.SetInt("Card_"+_playerCardForTrapSelected+"_Amount", PlayerPrefs.GetInt("Card_"+_playerCardForTrapSelected+"_Amount")-1); 
	}
	
	private void GenerateDefaultCardsForWeb()
	{
		for (int i = 1; i <= 25; i++)
		{
			PlayerPrefs.SetInt("Card_" + i, i); PlayerPrefs.SetInt("Card_" + i + "_Amount", 3);
		}
	}
	
	private void GenerateTrapCardsDictionary()
	{
		if (_trapCardDictionary.Count == 0)
		{
			_trapCardDictionary.Add(1, "Gorące kamienie");
			_trapCardDictionary.Add(2, "Kałuże wody");
			_trapCardDictionary.Add(3, "Klejąca guma do żucia");
			_trapCardDictionary.Add(4, "Kłoda na ścieżce");
			_trapCardDictionary.Add(5, "Małe bagno");
			_trapCardDictionary.Add(6, "Pokrzywy");
			_trapCardDictionary.Add(7, "Pułapka kłusownika");
			_trapCardDictionary.Add(8, "Rosiczka");
			_trapCardDictionary.Add(9, "Sterta kamieni");
			_trapCardDictionary.Add(10, "Tlące się ognisko");
		}
	}
	
	
	private void GeneratePlayerCardsDictionary() {
		if (_playerCardDictionary.Count == 0)
		{
			_playerCardDictionary.Add(0, "Empty");
			_playerCardDictionary.Add(1, "Lawina spychająca");
			_playerCardDictionary.Add(2, "Lodowisko");
			_playerCardDictionary.Add(3, "Przysypanie lodem");
			_playerCardDictionary.Add(4, "Rzut śnieżką");
			_playerCardDictionary.Add(5, "Zamrażanie przeszkody");
			_playerCardDictionary.Add(6, "Energia uspokojenia");
			_playerCardDictionary.Add(7, "Lewitacja nad przeszkodą");
			_playerCardDictionary.Add(8, "Osłona energii");
			_playerCardDictionary.Add(9, "Rzut telekinetyczny");
			_playerCardDictionary.Add(10, "Teleportacja");
			_playerCardDictionary.Add(11, "Elastyczny most");
			_playerCardDictionary.Add(12, "Proca wyrzucająca");
			_playerCardDictionary.Add(13, "Super salto wirujące");
			_playerCardDictionary.Add(14, "Szybki skok");
			_playerCardDictionary.Add(15, "Wysoki skok");
			_playerCardDictionary.Add(16, "Pancerna skóra");
			_playerCardDictionary.Add(17, "Pływanie");
			_playerCardDictionary.Add(18, "Siła - przesunięcie");
			_playerCardDictionary.Add(19, "Siła - wyrwanie się z przeszkody");
			_playerCardDictionary.Add(20, "Turlanie się");
			_playerCardDictionary.Add(21, "Dmuchnięcie i zasypanie piaskiem");
			_playerCardDictionary.Add(22, "Kula wiatru - zdmuchnięcie");
			_playerCardDictionary.Add(23, "Lot nad przeszkodą");
			_playerCardDictionary.Add(24, "Osłona wiatru - ostudzenie");
			_playerCardDictionary.Add(25, "Uderzenie wiatru - wypchnięcie");
		}
	}
	
	private void GeneratePlayersCardsLinks() {
		if (_playersCardsLinks.Count == 0)
		{
			_playersCardsLinks.Add("Bear", new List<int>() { 2, 1, 3, 4, 5 });
			_playersCardsLinks.Add("Dog", new List<int>() { 10, 9, 8, 6, 7 });
			_playersCardsLinks.Add("Hippo", new List<int>() { 17, 18, 16, 20, 19 });
			_playersCardsLinks.Add("Frog", new List<int>() { 11, 12, 14, 13, 15 });
			_playersCardsLinks.Add("Tiger", new List<int>() { 23, 25, 24, 22, 21 });
		}
	}
	
	private void GeneratePlayerTrapCardsLinks() {
		if (_cardsLinks.Count == 0)
		{
			List<PlayersCards> hotStonesAcions = new List<PlayersCards>();
			hotStonesAcions.Add(new PlayersCards("Bear", 3));
			hotStonesAcions.Add(new PlayersCards("Dog", 8));
			hotStonesAcions.Add(new PlayersCards("Frog", 14));
			hotStonesAcions.Add(new PlayersCards("Hippo", 16));
			hotStonesAcions.Add(new PlayersCards("Tiger", 24));
			_cardsLinks.Add(1, hotStonesAcions);
			
			List<PlayersCards> waterPool = new List<PlayersCards>();
			waterPool.Add(new PlayersCards("Bear", 2));
			waterPool.Add(new PlayersCards("Dog", 10));
			waterPool.Add(new PlayersCards("Frog", 11));
			waterPool.Add(new PlayersCards("Hippo", 17));
			waterPool.Add(new PlayersCards("Tiger", 23));
			_cardsLinks.Add(2, waterPool);
			
			List<PlayersCards> gum = new List<PlayersCards>();
			gum.Add(new PlayersCards("Bear", 5));
			gum.Add(new PlayersCards("Dog", 7));
			gum.Add(new PlayersCards("Frog", 15));
			gum.Add(new PlayersCards("Hippo", 19));
			gum.Add(new PlayersCards("Tiger", 21));
			_cardsLinks.Add(3, gum);
			
			List<PlayersCards> pathLog = new List<PlayersCards>();
			pathLog.Add(new PlayersCards("Bear", 1));
			pathLog.Add(new PlayersCards("Dog", 9));
			pathLog.Add(new PlayersCards("Frog", 12));
			pathLog.Add(new PlayersCards("Hippo", 18));
			pathLog.Add(new PlayersCards("Tiger", 25));
			_cardsLinks.Add(4, pathLog);
			
			List<PlayersCards> littleSwamp = new List<PlayersCards>();
			littleSwamp.Add(new PlayersCards("Bear", 2));
			littleSwamp.Add(new PlayersCards("Dog", 10));
			littleSwamp.Add(new PlayersCards("Frog", 11));
			littleSwamp.Add(new PlayersCards("Hippo", 17));
			littleSwamp.Add(new PlayersCards("Tiger", 23));
			_cardsLinks.Add(5, littleSwamp);
			
			List<PlayersCards> nettle = new List<PlayersCards>();
			nettle.Add(new PlayersCards("Bear", 4));
			nettle.Add(new PlayersCards("Dog", 6));
			nettle.Add(new PlayersCards("Frog", 13));
			nettle.Add(new PlayersCards("Hippo", 20));
			nettle.Add(new PlayersCards("Tiger", 22));
			_cardsLinks.Add(6, nettle);
			
			List<PlayersCards> poacherTrap = new List<PlayersCards>();
			poacherTrap.Add(new PlayersCards("Bear", 5));
			poacherTrap.Add(new PlayersCards("Dog", 7));
			poacherTrap.Add(new PlayersCards("Frog", 15));
			poacherTrap.Add(new PlayersCards("Hippo", 19));
			poacherTrap.Add(new PlayersCards("Tiger", 21));
			_cardsLinks.Add(7, poacherTrap);
			
			List<PlayersCards> sundew = new List<PlayersCards>();
			sundew.Add(new PlayersCards("Bear", 4));
			sundew.Add(new PlayersCards("Dog", 6));
			sundew.Add(new PlayersCards("Frog", 13));
			sundew.Add(new PlayersCards("Hippo", 20));
			sundew.Add(new PlayersCards("Tiger", 22));
			_cardsLinks.Add(8, sundew);
			
			List<PlayersCards> rocksStack = new List<PlayersCards>();
			rocksStack.Add(new PlayersCards("Bear", 1));
			rocksStack.Add(new PlayersCards("Dog", 9));
			rocksStack.Add(new PlayersCards("Frog", 12));
			rocksStack.Add(new PlayersCards("Hippo", 18));
			rocksStack.Add(new PlayersCards("Tiger", 25));
			_cardsLinks.Add(9, rocksStack);
			
			List<PlayersCards> campfire = new List<PlayersCards>();
			campfire.Add(new PlayersCards("Bear", 3));
			campfire.Add(new PlayersCards("Dog", 8));
			campfire.Add(new PlayersCards("Frog", 14));
			campfire.Add(new PlayersCards("Hippo", 16));
			campfire.Add(new PlayersCards("Tiger", 24));
			_cardsLinks.Add(10, campfire);
		}
	}
}
