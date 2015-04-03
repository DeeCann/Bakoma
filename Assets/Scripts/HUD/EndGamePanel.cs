using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour {

    private GameObject _fruitsPanel;
    private GameObject _pointsPanel;

	void Start () {
        _fruitsPanel = transform.FindChild("Fruits").gameObject;
        _pointsPanel = transform.FindChild("Points").gameObject;

        _fruitsPanel.transform.FindChild("Strawberry").GetComponent<Text>().text = PlayerPrefs.GetInt("GamePoints_Strawberry").ToString() + " / <color=#ffffff>" + Game._fruitsInGame["Strawberry"] + "</color>";
        _fruitsPanel.transform.FindChild("Blueberry").GetComponent<Text>().text = PlayerPrefs.GetInt("GamePoints_Blueberry").ToString() + " / <color=#ffffff>" + Game._fruitsInGame["Blueberry"] + "</color>";
        _fruitsPanel.transform.FindChild("Blackberry").GetComponent<Text>().text = PlayerPrefs.GetInt("GamePoints_Blackberry").ToString() + " / <color=#ffffff>" + Game._fruitsInGame["Blackberry"] + "</color>";
        _fruitsPanel.transform.FindChild("Raspberry").GetComponent<Text>().text = PlayerPrefs.GetInt("GamePoints_Raspberry").ToString() + " / <color=#ffffff>" + Game._fruitsInGame["Raspberry"] + "</color>";
        _fruitsPanel.transform.FindChild("Apple").GetComponent<Text>().text = PlayerPrefs.GetInt("GamePoints_Apple").ToString() + " / <color=#ffffff>" + Game._fruitsInGame["Apple"] + "</color>";
        _fruitsPanel.transform.FindChild("Peach").GetComponent<Text>().text = PlayerPrefs.GetInt("GamePoints_Peach").ToString() + " / <color=#ffffff>" + Game._fruitsInGame["Peach"] + "</color>";

        int fruitsPoints = 0;

        if (PlayerPrefs.GetInt("GamePoints_Strawberry") < Game._fruitsInGame["Strawberry"])
            fruitsPoints += PlayerPrefs.GetInt("GamePoints_Strawberry") * 5;
        else
            fruitsPoints += PlayerPrefs.GetInt("GamePoints_Strawberry") * 10;

        if (PlayerPrefs.GetInt("GamePoints_Blueberry") < Game._fruitsInGame["Blueberry"])
            fruitsPoints += PlayerPrefs.GetInt("GamePoints_Blueberry") * 5;
        else
            fruitsPoints += PlayerPrefs.GetInt("GamePoints_Blueberry") * 10;

        if (PlayerPrefs.GetInt("GamePoints_Blackberry") < Game._fruitsInGame["Blackberry"])
            fruitsPoints += PlayerPrefs.GetInt("GamePoints_Blackberry") * 5;
        else
            fruitsPoints += PlayerPrefs.GetInt("GamePoints_Blackberry") * 10;

        if (PlayerPrefs.GetInt("GamePoints_Raspberry") < Game._fruitsInGame["Raspberry"])
            fruitsPoints += PlayerPrefs.GetInt("GamePoints_Raspberry") * 5;
        else
            fruitsPoints += PlayerPrefs.GetInt("GamePoints_Raspberry") * 10;

        if (PlayerPrefs.GetInt("GamePoints_Apple") < Game._fruitsInGame["Apple"])
            fruitsPoints += PlayerPrefs.GetInt("GamePoints_Apple") * 5;
        else
            fruitsPoints += PlayerPrefs.GetInt("GamePoints_Apple") * 10;

        if (PlayerPrefs.GetInt("GamePoints_Peach") < Game._fruitsInGame["Peach"])
            fruitsPoints += PlayerPrefs.GetInt("GamePoints_Peach") * 5;
        else
            fruitsPoints += PlayerPrefs.GetInt("GamePoints_Peach") * 10;

        _pointsPanel.transform.FindChild("FruitPoints").GetComponent<Text>().text = fruitsPoints.ToString();

        int _throwsPoints = 0;
        if (Dice.GetThrows < 100)
            _throwsPoints = Dice.GetThrows * 20;

        _pointsPanel.transform.FindChild("TimePoints").GetComponent<Text>().text = _throwsPoints.ToString();
        _pointsPanel.transform.FindChild("TotalPoints").GetComponent<Text>().text = (fruitsPoints + _throwsPoints).ToString();


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
