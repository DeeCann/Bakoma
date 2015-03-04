using UnityEngine;
using System.Collections;

public class GameInputs : MonoBehaviour {

//	private static GameObject ClickedField;
//	private static bool NewDiceThrow;
//	private static int DiceValue = 0;

//	void Update () {
//		if(Input.GetKeyDown(KeyCode.Alpha1)) {
//			NewDiceThrow = true;
//			DiceValue = 1;
//		}
//
//		if(Input.GetKeyDown(KeyCode.Alpha2)) {
//			NewDiceThrow = true;
//			DiceValue = 2;
//		}
//
//		if(Input.GetKeyDown(KeyCode.Alpha3)) {
//			NewDiceThrow = true;
//			DiceValue = 3;
//		}
//
//		if(Input.GetKeyDown(KeyCode.Alpha4)) {
//			NewDiceThrow = true;
//			DiceValue = 4;
//		}
//
//		if(Input.GetKeyDown(KeyCode.Alpha5)) {
//			NewDiceThrow = true;
//			DiceValue = 5;
//		}
//
//		if(Input.GetKeyDown(KeyCode.Alpha6)) {
//			NewDiceThrow = true;
//			DiceValue = 6;
//		}
//	}

//	public static GameObject GetNextFieldObject {
//		get{
//			return ClickedField;
//		}
//	}

//	public static bool HasNewDiceThrow {
//		get{
//			if(NewDiceThrow) {
//				NewDiceThrow = false;
//				return true;
//			}
//
//			return false;
//		}
//	}
//
//	public static int FieldsToGo {
//		get{
//			return DiceValue;
//		}
//	}
    public static bool isButtonDown = false;

    void Update() {
        if (Input.GetMouseButtonDown(0))
            isButtonDown = true;

        if (Input.GetMouseButtonUp(0))
            isButtonDown = false;

    }
}
