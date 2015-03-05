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

	private bool _gameIsPaused = false;	

    public void Exit()
    {
		Application.LoadLevel ("Start");
		return;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            TimeControl();
    }

	public void TimeControl() {
		if (!_gameIsPaused) {
            StartCoroutine(ShowUpperPanel());
			_pauseButtonSprite.gameObject.SetActive(false);
			_playButtonSprite.gameObject.SetActive(true);
			_gameIsPaused = true;

			return;
		}

		if (_gameIsPaused) {
			Time.timeScale = 1;
            StartCoroutine(HideUpperPanel());
			_pauseButtonSprite.gameObject.SetActive(true);
			_playButtonSprite.gameObject.SetActive(false);
			_gameIsPaused = false;

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

}
