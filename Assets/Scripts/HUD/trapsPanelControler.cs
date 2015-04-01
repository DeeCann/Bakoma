using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class trapsPanelControler : MonoBehaviour {

    public Transform _vigniete;

    private Image _trapImage;
    private Transform _cardsContainer;
    private Transform _playerCardsContainer;

    private static bool _trapPanelEnabled = false;
    private string _properCardName = "";

    private int _maxOffsetXAnchor = -480;
    private int _gap = 280;
    private int _offset = 0;
    private int _lastOffset = 0;

    public void EnablePanel() {
        _trapPanelEnabled = true;

        GetComponent<AudioSource>().Play();
        Camera.main.GetComponent<AudioSource>().Pause();

        _playerCardsContainer = transform.FindChild("PlayerCardsPanel").transform;
        transform.FindChild("ObstaclePresentation").GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/TrapCards/" + Cards.TrapCardName(Cards.GetRandomTrap));
        transform.FindChild("ObstaclePresentation").GetComponent<Image>().color = new Color(1, 1, 1, 1);

        List<string> cardForUse = Cards.GetAllCardsForCharacter();

       
        bool useEmptyCard = false;
        if (cardForUse.Count == 0) {
            _offset = 560;
            useEmptyCard = true;
        }
        if (cardForUse.Count > 0 && cardForUse.Count < 5)
            _offset = (5 - cardForUse.Count) * 140;
        else if (cardForUse.Count == 5)
            _offset = 0;

        if (_lastOffset == _offset)
            _offset = 0;
        else
            _lastOffset = _offset;

        if (useEmptyCard)
        {
            //_playerCardsContainer.FindChild("PlayerCard1").GetComponent<RectTransform>().anchoredPosition = new Vector2(_playerCardsContainer.FindChild("PlayerCard1").GetComponent<RectTransform>().anchoredPosition.x + _offset, _playerCardsContainer.FindChild("PlayerCard1").GetComponent<RectTransform>().anchoredPosition.y);
            _playerCardsContainer.FindChild("PlayerCard1").GetComponent<RectTransform>().anchoredPosition = new Vector2(_maxOffsetXAnchor + _offset, _playerCardsContainer.FindChild("PlayerCard1").GetComponent<RectTransform>().anchoredPosition.y);
            
            _playerCardsContainer.FindChild("PlayerCard1").gameObject.SetActive(true);
            _playerCardsContainer.FindChild("PlayerCard1").GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/DefaultCards/Empty");
            _playerCardsContainer.FindChild("PlayerCard1").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            _playerCardsContainer.FindChild("PlayerCard1").GetComponent<PlayerCardsOnTrap>().RegisterListener(this);

            useEmptyCard = false;
        }
        else
        {
            for (int i = 1; i <= cardForUse.Count; i++)
            {
                _playerCardsContainer.FindChild("PlayerCard" + i).GetComponent<RectTransform>().anchoredPosition = new Vector2(_playerCardsContainer.FindChild("PlayerCard" + i).GetComponent<RectTransform>().anchoredPosition.x + _offset, _playerCardsContainer.FindChild("PlayerCard" + i).GetComponent<RectTransform>().anchoredPosition.y);
                _playerCardsContainer.FindChild("PlayerCard" + i).gameObject.SetActive(true);
                _playerCardsContainer.FindChild("PlayerCard" + i).GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/DefaultCards/" + cardForUse[i - 1]);
                _playerCardsContainer.FindChild("PlayerCard" + i).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                _playerCardsContainer.FindChild("PlayerCard" + i).GetComponent<PlayerCardsOnTrap>().RegisterListener(this);
            }
        }

       
        _properCardName = Cards.GetProperCardForTrap;
    }

    public void ChooseCard(string cardName) {
        if (_properCardName != cardName)
            transform.FindChild("ErrorSound").GetComponent<AudioSource>().Play();
        else {
            GetComponent<AudioSource>().Stop();
            Camera.main.GetComponent<AudioSource>().Play();

            Cards.RemovePlayerUsedCard();
            ClosePanel();
        }
    }

    public void GetSomeFruit()
    {
        GetComponent<AudioSource>().Stop();
        Camera.main.GetComponent<AudioSource>().Play();

        Game.RemoveRandomFruitPoint(1);

        ClosePanel();
    }

    public void ClosePanel()
    {
        _trapPanelEnabled = false;

        StartCoroutine(HideVigniete());
        StartCoroutine(HideTrapPanelCorutine());
    }

    public static bool IsTrapPanelEnabled {
        get {
            return _trapPanelEnabled;
        }
    }

    IEnumerator HideVigniete()
    {
        Color vignieteColor = _vigniete.GetComponent<Image>().color;
        while (vignieteColor.a > 0.1f)
        {
            vignieteColor.a -= 0.2f;
            _vigniete.GetComponent<Image>().color = vignieteColor;
            yield return null;
        }

        vignieteColor.a = 0;
        _vigniete.GetComponent<Image>().color = vignieteColor;
        _vigniete.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    IEnumerator HideTrapPanelCorutine()
    {
        float trapPanelAplha = gameObject.GetComponent<CanvasGroup>().alpha;

        while (trapPanelAplha > 0.1f)
        {
            trapPanelAplha -= 1.6f;
            gameObject.GetComponent<CanvasGroup>().alpha = trapPanelAplha;
            yield return null;
        }
        transform.FindChild("ObstaclePresentation").GetComponent<Image>().sprite = null;
        transform.FindChild("ObstaclePresentation").GetComponent<Image>().color = new Color(1, 1, 1, 0);

        for (int i = 0; i <= 4; i++)
        {
            _playerCardsContainer.FindChild("PlayerCard" + i).GetComponent<Image>().sprite = null;
            _playerCardsContainer.FindChild("PlayerCard" + i).GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
    }
}
