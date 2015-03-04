using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InsertCodePanelControler : MonoBehaviour {
    public Transform _cardsPanel;
    public Transform _hintPanel;
    public Transform _codeField;
    public Transform _messageText;
    public Transform _waitText;

    public void CloseInsertCardPanel()
    {
        StartCoroutine(HideInsertCodeCorutine());
        StartCoroutine(ShowCardsPanelCorutine());
        
    }

    public void CheckCode() {
        _waitText.GetComponent<Text>().text = "Sprawdzam kod ...";
        StartCoroutine(WebserwisConnect());
    }

    void AnaliseReceiver(string json)
    {
        _waitText.GetComponent<Text>().text = "";
        JSONObject jo = new JSONObject(json);

        if (jo.keys[0] == "status" && jo[0].ToString() == "-1")
            _messageText.GetComponent<Text>().text = "Kod niepoprawny.\nSpróbuj ponownie później";

        if (jo.keys[0] == "status" && jo[0].ToString() == "0")
            _messageText.GetComponent<Text>().text = "Kod nieaktualny.";

        if (jo.keys[1] == "status" && jo[1].ToString() == "1")
        {
            GenerateRandomCards();
            StartCoroutine(HideInsertCodeCorutine());
            StartCoroutine(ShowHintPanelCorutine());
        }

        
    }

    private void GenerateRandomCards() {
        for(int i = 1; i <= 25; i++)
        {
            int randomCard = Random.Range(1, 26);
            PlayerPrefs.SetInt("Card_" + randomCard + "_Amount",  PlayerPrefs.GetInt("Card_" + randomCard + "_Amount") + 1);
        }
        
    }

    IEnumerator HideInsertCodeCorutine()
    {
        _codeField.parent.GetComponent<InputField>().text = "";
        float insertCodePanelAplha = GetComponent<CanvasGroup>().alpha;

        while (insertCodePanelAplha > 0.1f)
        {
            insertCodePanelAplha -= 0.16f;
            GetComponent<CanvasGroup>().alpha = insertCodePanelAplha;
            yield return null;
        }
        _cardsPanel.GetComponent<cardPanelControler>().RegenerateCards = false;
        _messageText.GetComponent<Text>().text = "";
        gameObject.SetActive(false);
    }

    IEnumerator ShowCardsPanelCorutine()
    {
        float cardsPanelAplha = _cardsPanel.GetComponent<CanvasGroup>().alpha;

        while (cardsPanelAplha < 0.99f)
        {
            cardsPanelAplha += 0.16f;
            _cardsPanel.GetComponent<CanvasGroup>().alpha = cardsPanelAplha;
            
            yield return null;
        }
        
    }

    IEnumerator ShowHintPanelCorutine()
    {
        _hintPanel.gameObject.SetActive(true);
        float hintPanelAplha = _hintPanel.GetComponent<CanvasGroup>().alpha;

        while (hintPanelAplha < 0.99f)
        {
            hintPanelAplha += 0.16f;
            _hintPanel.GetComponent<CanvasGroup>().alpha = hintPanelAplha;

            yield return null;
        }

    }

    IEnumerator WebserwisConnect()
    {
        WWWForm form = new WWWForm();
        form.AddField("code", _codeField.parent.GetComponent<InputField>().text);
        form.AddField("type", "2");
        form.AddField("uid", "test");

        WWW w = new WWW("http://apps.pc-fb.com/bakoma/connect/update_product.php", form);
        yield return w;

        print("Waiting for code\n");
        yield return new WaitForSeconds(1f);
        print("Received code\n");

        AnaliseReceiver(w.text);
    }
}
