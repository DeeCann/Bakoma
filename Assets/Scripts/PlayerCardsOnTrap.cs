using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCardsOnTrap : MonoBehaviour {
    private bool _listenerAdded = false;


    public void RegisterListener(trapsPanelControler manager) {
        if (!_listenerAdded)
        {
            Button myButton = GetComponent<Button>();
            if (GetComponent<Image>().sprite.name != "Empty")
                myButton.onClick.AddListener(() => { manager.ChooseCard(this.gameObject.name); });
            _listenerAdded = true;
        }
    }
}
