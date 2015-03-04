using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class trapsPanelControler : MonoBehaviour {

    public Transform _vigniete;

    private Image _trapImage;
    private Transform _cardsContainer;
    private Transform _playerCardsContainer;

    private static bool _trapPanelEnabled = false;

    public void EnablePanel() {
        _trapPanelEnabled = true;

        GetComponent<AudioSource>().Play();
        Camera.main.GetComponent<AudioSource>().Pause();

        _playerCardsContainer = transform.FindChild("PlayerCardsPanel").transform;
        transform.FindChild("ObstaclePresentation").GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/TrapCards/" + Cards.TrapCardName(Cards.GetRandomTrap));
        transform.FindChild("ObstaclePresentation").GetComponent<Image>().color = new Color(1, 1, 1, 1);

        _playerCardsContainer.FindChild("PlayerCard").GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures/DefaultCards/" + Cards.GetProperCardForTrap);
        _playerCardsContainer.FindChild("PlayerCard").GetComponent<Image>().color = new Color(1, 1, 1, 1);
        _playerCardsContainer.FindChild("PlayerCard").GetComponent<PlayerCardsOnTrap>().RegisterListener(this);
    }

    public void ChooseCard(string cardName) {
        GetComponent<AudioSource>().Stop();
        Camera.main.GetComponent<AudioSource>().Play();

        Cards.RemovePlayerUsedCard();
        ClosePanel();
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
        _playerCardsContainer.FindChild("PlayerCard").GetComponent<Image>().sprite = null;
        _playerCardsContainer.FindChild("PlayerCard").GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }
}
