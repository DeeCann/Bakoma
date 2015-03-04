using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FruitsPanel : MonoBehaviour {

    private static string _setPointForFruitName;
    private static int _setPointForFruitAmount;
    private static bool _changeScore = false;
    private int _animationState = Animator.StringToHash("Base Layer.GrabFruitGUIEffect");
    private static List<string> _animationFruitStack = new List<string>();

	void Start() {
        foreach (Transform fruit in transform)
			fruit.FindChild("TextPanel").transform.FindChild("IsText").GetComponent<Text>().text = Game._fruitsInGame[fruit.name].ToString();
	}

    void Update() {
        string _fruitAnimationCompleted = "";
        if (_animationFruitStack.Count > 0) {
            foreach (string fruit in _animationFruitStack) {
                Animator animControler = transform.FindChild(fruit).FindChild("GrabEffect").GetComponent<Animator>();
                AnimatorStateInfo stateInfo = animControler.GetCurrentAnimatorStateInfo(0);

                if (stateInfo.IsName("Idle"))
                    animControler.SetBool("Play", true);

                if (stateInfo.IsName("StopGrabAnimation"))
                {
                    transform.FindChild(fruit).FindChild("GrabEffect").GetComponent<Animator>().SetBool("Play", false);
                    _fruitAnimationCompleted = fruit;
                    break;
                }
            }

            if (_fruitAnimationCompleted.Length > 0)
            {
                _animationFruitStack.Remove(_fruitAnimationCompleted);
                _fruitAnimationCompleted = "";
            }           
        }
    }

    public static void SetPoint(string fruitName) {
        _setPointForFruitName = fruitName;
        _setPointForFruitAmount = PlayerPrefs.GetInt("GamePoints_" + fruitName);
        if (!_animationFruitStack.Contains(fruitName))
            _animationFruitStack.Add(fruitName);

        _changeScore = true;
    }
}
