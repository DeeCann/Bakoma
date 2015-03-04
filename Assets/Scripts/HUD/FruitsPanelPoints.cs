using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FruitsPanelPoints : MonoBehaviour {

    public enum fruitsNames
    {
        Apple = 1,
        Raspberry = 2,
        Blueberry = 3,
        Blackberry = 4,
        Peach = 5,
        Strawberry = 6
    }

    public fruitsNames fruitNamePoints;

    void Update() {
        GetComponent<Text>().text = PlayerPrefs.GetInt("GamePoints_"+ fruitNamePoints.ToString()).ToString();
    }
}
