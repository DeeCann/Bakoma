using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public Transform _vigniete;
	public Transform _pauseButtonSprite;
	public Transform _playButtonSprite;
	public Transform _cardsPanel;
	public Transform _startFruitsAmountPanel;
    public Transform _trapPanel;
    public Transform _UpperPanel;
    public Transform _EndDemoPanel;
    public Transform _CharactersPanel;
    
    public static bool hasEnteredTrap = false;

	private bool _gameIsPaused = false;
    private static bool _setNewPlayer = false;
    
    private static int _lastPlayer = 0;
    private static int _currentPlayer = 0;
    public void Exit()
    {
        PlayerPrefs.SetString("LoadLevelName", "Start");
        Destroy(GameObject.Find("GeneratedFruitsContainer"));
        Application.LoadLevel("Loader");
		return;
    }

    void Start() {
        for (int i = 1; i <= Game._playersNumber; i++)
        {
            _CharactersPanel.transform.FindChild("Panel" + i).gameObject.SetActive(true);
            _CharactersPanel.transform.FindChild("Panel" + i).GetComponent<Image>().overrideSprite = Resources.Load("Textures/ico" + PlayerPrefs.GetString("Character_" + i), typeof(Sprite)) as Sprite;
            _CharactersPanel.transform.FindChild("Panel" + i).FindChild("Image").GetComponent<Image>().color = hexToColor(PlayerPrefs.GetString("CharacterColor_" + i));

            if (i == Game.GetCurrentPlayerRound)
            {
                _CharactersPanel.transform.FindChild("Panel" + i).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                _lastPlayer = i;
            }
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            TimeControl();

        if (_setNewPlayer) {
            _CharactersPanel.transform.FindChild("Panel" + _lastPlayer).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            _CharactersPanel.transform.FindChild("Panel" + _currentPlayer).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            _setNewPlayer = false;
            _lastPlayer = _currentPlayer;
        }

    }

	public void TimeControl() {
		if (!_gameIsPaused) {
            StartCoroutine(ShowUpperPanel());
			_pauseButtonSprite.gameObject.SetActive(false);
			_playButtonSprite.gameObject.SetActive(true);
			_gameIsPaused = true;

            Camera.main.gameObject.GetComponent<AudioListener>().enabled = false;
			return;
		}

		if (_gameIsPaused) {
			Time.timeScale = 1;
            StartCoroutine(HideUpperPanel());
			_pauseButtonSprite.gameObject.SetActive(true);
			_playButtonSprite.gameObject.SetActive(false);
			_gameIsPaused = false;

            Camera.main.gameObject.GetComponent<AudioListener>().enabled = true;

			return;
		}
	}

	public void ShowTip() {
		_vigniete.gameObject.SetActive (true);
		_startFruitsAmountPanel.gameObject.SetActive (true);
		StartCoroutine (ShowVigniete ());
		StartCoroutine (ShowTipsPanelCorutine ());
	}

	public void CloseTip() {
		StartCoroutine (HideVigniete ());
		StartCoroutine (HideTipsPanelCorutine ());
	}

	public void ShowStartFruitsAmount() {
		_vigniete.gameObject.SetActive (true);
		_startFruitsAmountPanel.gameObject.SetActive (true);
		StartCoroutine (ShowVigniete ());
		StartCoroutine (ShowTipsPanelCorutine ());
	}
	
	public void CloseStartFruitsAmount() {
		StartCoroutine (HideVigniete ());
		StartCoroutine (HideTipsPanelCorutine ());
	}

	public void ShowCardsPanel() {
		_vigniete.gameObject.SetActive (true);
		_cardsPanel.gameObject.SetActive (true);
		StartCoroutine (ShowCardsPanelCorutine ());
		StartCoroutine (ShowVigniete ());
	}

    public void ShowTrapPanel() {
        _vigniete.gameObject.SetActive(true);
        _trapPanel.gameObject.SetActive(true);
        StartCoroutine(ShowTrapPanelCorutine());
        StartCoroutine(ShowVigniete());
    }

    public void ShowEndDemoPanel()
    {
        _EndDemoPanel.gameObject.SetActive(true);
       // StartCoroutine(HideAllMenus());
        StartCoroutine(ShowEndDemoVigniete());
        //_EndDemoPanel.GetComponent<CanvasGroup>().alpha = 1;
    }

    public static void SetNewPlayer(int _player) {
        _currentPlayer = _player;
        _setNewPlayer = true; 
    }

	IEnumerator ShowVigniete() {
		Color vignieteColor = _vigniete.GetComponent<Image> ().color;
		while (vignieteColor.a < 0.6f) {
			vignieteColor.a += 0.16f;
			_vigniete.GetComponent<Image>().color = vignieteColor;
			yield return null;
		}
	}

	IEnumerator HideVigniete() {
		Color vignieteColor = _vigniete.GetComponent<Image> ().color;
		while (vignieteColor.a > 0.1f) {
			vignieteColor.a -= 0.2f;
			_vigniete.GetComponent<Image>().color = vignieteColor;
			yield return null;
		}
		
		vignieteColor.a = 0;
		_vigniete.GetComponent<Image> ().color = vignieteColor;
		_vigniete.gameObject.SetActive (false);
	}

	IEnumerator ShowCardsPanelCorutine() {
		float cardsPanelAplha = _cardsPanel.GetComponent<CanvasGroup> ().alpha;

		while (cardsPanelAplha < 0.99f) {
			cardsPanelAplha += 0.16f;
			_cardsPanel.GetComponent<CanvasGroup> ().alpha = cardsPanelAplha;
			yield return null;
		}
	}

	IEnumerator ShowTipsPanelCorutine() {
		float _tipsPanelAlpha = _startFruitsAmountPanel.GetComponent<CanvasGroup> ().alpha;
		
		while (_tipsPanelAlpha < 0.99f) {
			_tipsPanelAlpha += 0.16f;
			_startFruitsAmountPanel.GetComponent<CanvasGroup> ().alpha = _tipsPanelAlpha;
			yield return null;
		}

		foreach(Transform fruit in _startFruitsAmountPanel.FindChild("FruitsAmountTexts").transform)
			fruit.GetComponent<Text>().text = Game._fruitsInGame[fruit.name].ToString();
		
	}

    IEnumerator ShowTrapPanelCorutine()
    {
        float trapPanelAplha = _trapPanel.GetComponent<CanvasGroup>().alpha;

        while (trapPanelAplha < 0.99f)
        {
            trapPanelAplha += 0.16f;
            _trapPanel.GetComponent<CanvasGroup>().alpha = trapPanelAplha;
            yield return null;
        }

        _trapPanel.GetComponent<trapsPanelControler>().EnablePanel();
    }

	IEnumerator HideTipsPanelCorutine() {
		float _tipsPanelAlpha = _startFruitsAmountPanel.GetComponent<CanvasGroup> ().alpha;
		
		while (_tipsPanelAlpha < 0.99f) {
			_tipsPanelAlpha += 0.16f;
			_startFruitsAmountPanel.GetComponent<CanvasGroup> ().alpha = _tipsPanelAlpha;
			yield return null;
		}

		_startFruitsAmountPanel.gameObject.SetActive (false);
	}

    IEnumerator ShowUpperPanel()
    {
        while (_UpperPanel.GetComponent<RectTransform>().anchoredPosition.y > 0.5f)
        {
            float _panelPosition = Mathf.Lerp(_UpperPanel.GetComponent<RectTransform>().anchoredPosition.y, 0, Time.deltaTime * 10);
            _UpperPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(_UpperPanel.GetComponent<RectTransform>().anchoredPosition.x, _panelPosition);
            yield return null;
        }
        Time.timeScale = 0;
    }

    IEnumerator HideUpperPanel()
    {
        while (_UpperPanel.GetComponent<RectTransform>().anchoredPosition.y < 129.5f)
        {
            float _panelPosition = Mathf.Lerp(_UpperPanel.GetComponent<RectTransform>().anchoredPosition.y, 130, Time.deltaTime * 10);
            _UpperPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(_UpperPanel.GetComponent<RectTransform>().anchoredPosition.x, _panelPosition);
            yield return null;
        }
        
    }

    IEnumerator HideAllMenus() {
        float hudAplha = _vigniete.transform.parent.GetComponent<CanvasGroup> ().alpha;

        while (hudAplha > 0.01f)
        {
            hudAplha -= 0.16f;
            _vigniete.transform.parent.GetComponent<CanvasGroup>().alpha = hudAplha;
            yield return null;
        }
    }

    IEnumerator ShowEndDemoVigniete()
    {
        float endDemoAlpha = _EndDemoPanel.GetComponent<CanvasGroup>().alpha;
        while (endDemoAlpha < 0.80f)
        {
            endDemoAlpha += 0.16f;
            _EndDemoPanel.GetComponent<CanvasGroup>().alpha = endDemoAlpha;
            yield return null;
        }
    }

    private Color hexToColor(string hex)
    {
        hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
        hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
        byte a = 255;//assume fully visible unless specified in hex
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        //Only use alpha if the string has enough characters
        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        }
        return new Color32(r, g, b, a);
    }

}
