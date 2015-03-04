using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cardPanelControler : MonoBehaviour {
	public Transform _vigniete;
    public Transform _codePanel;
    private Transform _cardsContainer;
    private int _currentCardPanelsScreen = 1;
    private int _totalCardPanel = 0;

    private bool _slidePanelsRight = false;
    private bool _slidePanelsLeft = false;
    private static bool _cardPanelEnabled = false;
    private bool _cardGenerated = false;

    private GameObject _slideLeftBtn;
    private GameObject _slideRightBtn;

    void Start() {
        _cardsContainer = transform.FindChild("CardsList");
        _slideLeftBtn = transform.FindChild("SlideLeft").gameObject;
        _slideRightBtn = transform.FindChild("SlideRight").gameObject;
        

        _cardPanelEnabled = true;
    }

    void FixedUpdate() {
        if (!_cardGenerated)
            GenerateMyCards();

        if (_slidePanelsRight) {
            SlideOutLeft(_currentCardPanelsScreen);
            SlideInRight(_currentCardPanelsScreen + 1);
        }

        if (_slidePanelsLeft)
        {
            SlideOutRight(_currentCardPanelsScreen);
            SlideInLeft(_currentCardPanelsScreen - 1);
        }
    }


    private void GenerateMyCards()
    {
        _currentCardPanelsScreen = 1;
        Sprite cardSprite = new Sprite();
        _cardsContainer.FindChild("Screen" + _currentCardPanelsScreen).gameObject.SetActive(true);
        int _cardAmountInPanel = 0;
        bool hasCard = true;
        int cardCounter = 1;

        while (hasCard) {
            if (PlayerPrefs.GetInt("Card_" + cardCounter) != 0)
            {
                cardSprite = Resources.Load<Sprite>("Textures/DefaultCards/" + Cards.GetPlayerCardName(PlayerPrefs.GetInt("Card_" + cardCounter)));
                Transform _cardObj = _cardsContainer.FindChild("Screen" + _currentCardPanelsScreen).GetChild(_cardAmountInPanel).transform;
                _cardObj.GetComponent<Image>().sprite = cardSprite;
                _cardObj.gameObject.SetActive(true);
                _cardObj.GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("Card_" + cardCounter + "_Amount").ToString();
                _cardAmountInPanel++;
                if (_cardAmountInPanel == 10)
                {
                    _cardAmountInPanel = 0;
                    _currentCardPanelsScreen++;
                }

                cardCounter++;
            }
            else
                hasCard = false;
        }

        
        /* Activate slider */
        if (_currentCardPanelsScreen > 1)
            _slideRightBtn.gameObject.SetActive(true);

        /* Set total number of screens */
        _totalCardPanel = _currentCardPanelsScreen;

        /* Reset current panel */
        _currentCardPanelsScreen = 1;

        _cardGenerated = true;
    }

    public void ClosePanel()
    {
        _cardPanelEnabled = false;
        _cardGenerated = false;
        StartCoroutine(HideVigniete());
        StartCoroutine(HideCardsPanelCorutine());
    }

    

    public void SlideRight() {
        _slidePanelsRight = true;
    }

    public void SlideLeft() {
        _slidePanelsLeft = true;
    }

    public static bool IsCardPanelEnabled
    {
        get
        {
            return _cardPanelEnabled;
        }
    }

    public bool RegenerateCards
    {
        set
        {
            _cardGenerated = false;
        }
    }

    public void OpenInsertCodePanel() {
        StartCoroutine(HideCardsPanelCorutine());
        _codePanel.gameObject.SetActive(true);
        OpenCodePanel();
    }

    public void OpenCodePanel() {
        StartCoroutine(ShowInsertCodeCorutine());
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
		gameObject.SetActive (false);
	}

    IEnumerator ShowCardsPanelCorutine()
    {
        float cardsPanelAplha = gameObject.GetComponent<CanvasGroup>().alpha;

        while (cardsPanelAplha < 0.99f)
        {
            cardsPanelAplha += 1.6f;
            gameObject.GetComponent<CanvasGroup>().alpha = cardsPanelAplha;
            yield return null;
        }
    }

	

    IEnumerator ShowInsertCodeCorutine()
    {
        float insertCodePanelAplha = _codePanel.GetComponent<CanvasGroup>().alpha;

        while (insertCodePanelAplha < 0.99f)
        {
            insertCodePanelAplha += 0.16f;
            _codePanel.GetComponent<CanvasGroup>().alpha = insertCodePanelAplha;
            yield return null;
        }
    }

    IEnumerator HideCardsPanelCorutine()
    {
        float cardsPanelAplha = gameObject.GetComponent<CanvasGroup>().alpha;

        while (cardsPanelAplha > 0.1f)
        {
            cardsPanelAplha -= 0.6f;
            gameObject.GetComponent<CanvasGroup>().alpha = cardsPanelAplha;
            yield return null;
        }
        _slideRightBtn.gameObject.SetActive(true);
        _slideLeftBtn.gameObject.SetActive(false);
        _currentCardPanelsScreen = 1;

        _cardsContainer.FindChild("Screen1").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        _cardsContainer.FindChild("Screen1").GetComponent<CanvasGroup>().alpha = 1;
        _cardsContainer.FindChild("Screen2").GetComponent<RectTransform>().anchoredPosition = new Vector2(2000, 0);
        _cardsContainer.FindChild("Screen3").GetComponent<RectTransform>().anchoredPosition = new Vector2(2000,0);
        //gameObject.SetActive(false);
    }

   

    private void SlideOutLeft(float currentPanel)
    {
        float currentPanelTargetPosition = -2000;

        Vector2 XanchoredPosition = _cardsContainer.FindChild("Screen" + currentPanel).GetComponent<RectTransform>().anchoredPosition;
        XanchoredPosition.x = Mathf.Lerp(XanchoredPosition.x, currentPanelTargetPosition, Time.deltaTime * 15);
        _cardsContainer.FindChild("Screen" + currentPanel).GetComponent<RectTransform>().anchoredPosition = XanchoredPosition;

        if (_cardsContainer.FindChild("Screen" + currentPanel).GetComponent<CanvasGroup>().alpha >= 0)
            _cardsContainer.FindChild("Screen" + currentPanel).GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 7;
    }

    private void SlideInRight(float nextPanel)
    {
        float nextPanelTargetPosition = 0;

        Vector2 nextPanelAnchorPosition = _cardsContainer.FindChild("Screen" + nextPanel).GetComponent<RectTransform>().anchoredPosition;
        nextPanelAnchorPosition.x = Mathf.Lerp(nextPanelAnchorPosition.x, nextPanelTargetPosition, Time.deltaTime * 15);
        _cardsContainer.FindChild("Screen" + nextPanel).GetComponent<RectTransform>().anchoredPosition = nextPanelAnchorPosition;
        _cardsContainer.FindChild("Screen" + nextPanel).GetComponent<CanvasGroup>().alpha += Time.deltaTime * 7;
        
        if (nextPanelAnchorPosition.x <= 1) {
            nextPanelAnchorPosition.x = 0;
            _cardsContainer.FindChild("Screen" + nextPanel).GetComponent<RectTransform>().anchoredPosition = nextPanelAnchorPosition;
            _cardsContainer.FindChild("Screen" + nextPanel).GetComponent<CanvasGroup>().alpha = 1;
            _currentCardPanelsScreen++;

            if (_currentCardPanelsScreen == _totalCardPanel)
                _slideRightBtn.gameObject.SetActive(false);

            if (_currentCardPanelsScreen > 1)
                _slideLeftBtn.gameObject.SetActive(true); 

            _slidePanelsRight = false;
        }
    }

    private void SlideOutRight(float currentPanel)
    {
        float currentPanelTargetPosition = 2000;

        Vector2 XanchoredPosition = _cardsContainer.FindChild("Screen" + currentPanel).GetComponent<RectTransform>().anchoredPosition;
        XanchoredPosition.x = Mathf.Lerp(XanchoredPosition.x, currentPanelTargetPosition, Time.deltaTime * 15);
        _cardsContainer.FindChild("Screen" + currentPanel).GetComponent<RectTransform>().anchoredPosition = XanchoredPosition;

        if (_cardsContainer.FindChild("Screen" + currentPanel).GetComponent<CanvasGroup>().alpha >= 0)
            _cardsContainer.FindChild("Screen" + currentPanel).GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 7;
    }

    private void SlideInLeft(float prevPanel)
    {
        float nextPanelTargetPosition = 0;

        Vector2 nextPanelAnchorPosition = _cardsContainer.FindChild("Screen" + prevPanel).GetComponent<RectTransform>().anchoredPosition;
        nextPanelAnchorPosition.x = Mathf.Lerp(nextPanelAnchorPosition.x, nextPanelTargetPosition, Time.deltaTime * 15);
        _cardsContainer.FindChild("Screen" + prevPanel).GetComponent<RectTransform>().anchoredPosition = nextPanelAnchorPosition;
        _cardsContainer.FindChild("Screen" + prevPanel).GetComponent<CanvasGroup>().alpha += Time.deltaTime * 7;

        if (nextPanelAnchorPosition.x >= -1)
        {
            nextPanelAnchorPosition.x = 0;
            _cardsContainer.FindChild("Screen" + prevPanel).GetComponent<RectTransform>().anchoredPosition = nextPanelAnchorPosition;
            _cardsContainer.FindChild("Screen" + prevPanel).GetComponent<CanvasGroup>().alpha = 1;
            _currentCardPanelsScreen--;

            if (_currentCardPanelsScreen == 1)
                _slideLeftBtn.gameObject.SetActive(false);

            if (_currentCardPanelsScreen < _totalCardPanel)
                _slideRightBtn.gameObject.SetActive(true); 

            _slidePanelsLeft = false;
        }
    }
}
