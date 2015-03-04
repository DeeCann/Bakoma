using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HintPanel : MonoBehaviour {
    public Transform _vigniete;
    private string _hintText;
    private bool _showHint;

    public string SetHintText {
        set {
            _hintText = value;
        }
    }

    public void ShowHint() {
        _showHint = true;
    }

    public void HideHint() {
        StartCoroutine(HideVigniete());
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
}
