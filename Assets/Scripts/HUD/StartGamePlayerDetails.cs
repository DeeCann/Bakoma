using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGamePlayerDetails : MonoBehaviour {

    public Transform PlayerColor;

    private int _selectedAge = 0;
    private int _currentCharacterCounter = 1;
    private int _charactersSelected = 0;
    private bool _colorSelected = false;
    private bool _colorErrorAction = false;

    private bool _ageSelected = false;
    private bool _ageErrorAction = false;

    void Start() {
        _currentCharacterCounter = 1;
    }

    void OnEnable() {
        PlayerColor.GetComponent<Image>().color = hexToColor("ffffff");
        _colorSelected = false;
        _colorErrorAction = false;
        _ageSelected = false;
        _ageErrorAction = false;
        _charactersSelected++;

        if (_charactersSelected == 4)
        {
            transform.FindChild("AddPlayer").gameObject.SetActive(false);
            transform.FindChild("Text1").gameObject.SetActive(false);
            transform.FindChild("Text2").gameObject.SetActive(false);
        }
        else {
            transform.FindChild("AddPlayer").gameObject.SetActive(true);
            transform.FindChild("Text1").gameObject.SetActive(true);
            transform.FindChild("Text2").gameObject.SetActive(true);
        }

        foreach (Transform color in transform.FindChild("AgePanel").transform)
        {
            color.GetComponent<Image>().color = new Color(1,1,1,0.5f);
        }
    }

    void Update() {
        if (_colorErrorAction)
            StartCoroutine( ColorErrorAction() );

        if (_ageErrorAction)
            StartCoroutine(AgeErrorAction());
    }

    public void SetColor(string _spriteColorName) {
        PlayerColor.GetComponent<Image>().color = hexToColor(_spriteColorName);
        PlayerPrefs.SetString("CharacterColor_" + _currentCharacterCounter, _spriteColorName);
        _colorSelected = true;
    }

    public void CharacterSelected(string _name) {
        transform.FindChild("IcoPanel").GetComponent<Image>().overrideSprite = Resources.Load("Textures/ico" + _name, typeof(Sprite)) as Sprite;
        string properName = "";
        switch (_name) {
            case "Frog": properName = "ŻABA";  break;
            case "Bear": properName = "MIŚ";  break;
            case "Dog": properName = "PIES"; break;
            case "Tiger": properName = "TYGRYS"; break;
            case "Hippo": properName = "HIPCIO";  break;
        }
        PlayerPrefs.SetString("Character_" + _currentCharacterCounter, _name);
        transform.FindChild("PlayerName").GetComponent<Text>().text = properName;
        
    }

    public void AddAnotherPlayer() {
        if (!_colorSelected)
        {
            _colorErrorAction = true;
            transform.GetComponentInChildren<AudioSource>().Play();
            return;
        }

        if (!_ageSelected)
        {
            _ageErrorAction = true;
            transform.GetComponentInChildren<AudioSource>().Play();
            return;
        }

        _currentCharacterCounter++;
        foreach (Transform child in GameObject.Find("Presentation").transform)
            child.gameObject.SetActive(true);

        gameObject.SetActive(false);
    }

    public void StartGame() {
        if (!_colorSelected)
        {
            _colorErrorAction = true;
            transform.GetComponentInChildren<AudioSource>().Play();
            return;
        }

        if (!_ageSelected)
        {
            _ageErrorAction = true;
            transform.GetComponentInChildren<AudioSource>().Play();
            return;
        }

        Game._playersNumber = _currentCharacterCounter;
        PlayerPrefs.SetString("LoadLevelName", "Game_Board");
        Application.LoadLevel("Loader");
    }

    public void SetAge(int _age) {
        if (_selectedAge > 0) {
            switch (_selectedAge)
            {
                case 1:
                    transform.FindChild("AgePanel").transform.FindChild("Kid").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f); break;
                case 2:
                    transform.FindChild("AgePanel").transform.FindChild("Teen").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f); break;
                case 3:
                    transform.FindChild("AgePanel").transform.FindChild("Adult").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f); break;
            }
        }

        _selectedAge = _age;
        switch (_age) { 
            case 1:
                transform.FindChild("AgePanel").transform.FindChild("Kid").GetComponent<Image>().color = new Color(1, 1, 1, 1); break;
            case 2: 
                transform.FindChild("AgePanel").transform.FindChild("Teen").GetComponent<Image>().color = new Color(1, 1, 1, 1); break;
            case 3: 
                transform.FindChild("AgePanel").transform.FindChild("Adult").GetComponent<Image>().color = new Color(1, 1, 1, 1); break;
        }
        _ageSelected = true;
        PlayerPrefs.SetInt("CharacterAge_" + _currentCharacterCounter, _selectedAge);

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

    private IEnumerator ColorErrorAction() {
        foreach (Transform color in transform.FindChild("ColorsPanel").transform) {
            color.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100);
        }

        yield return new WaitForSeconds(0.2f);

        foreach (Transform color in transform.FindChild("ColorsPanel").transform)
        {
            color.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
        }

        _colorErrorAction = false;
    }

    private IEnumerator AgeErrorAction()
    {
        foreach (Transform color in transform.FindChild("AgePanel").transform)
        {
            color.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 250);
        }

        yield return new WaitForSeconds(0.2f);

        foreach (Transform color in transform.FindChild("AgePanel").transform)
        {
            color.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200);
        }

        _ageErrorAction = false;
    }
}
