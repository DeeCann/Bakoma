using UnityEngine;
using System.Collections;

public class NormalField : MonoBehaviour {

	private Field FieldObj;
	private bool _hasSomeMoveAction = false;
	private bool _enableTextHelper = true;

	void Awake() {
		FieldObj = new Field();
		gameObject.GetComponent<FieldSocket>().MyFieldObject = FieldObj;
	} 

	void Update() {
		if(HasAnyFieldMoveAction && _enableTextHelper)
			DrawGuiText();
	}

	
	public bool HasAnyFieldMoveAction {
		get{
			return _hasSomeMoveAction;
		}
	}
	
	public int MoveFieldActionValue {
		get{
			return FieldObj.MoveActionValue;
		}
	}
	
	public Field GetFieldObject {
		get{
			return FieldObj;
		}
	}
	
	/*
	 * TEST
	 * */
	private void DrawGuiText() {
		Vector3 pos = transform.position;
		transform.FindChild("Text").transform.position = Camera.main.WorldToViewportPoint(pos);
		transform.FindChild("Text").guiText.text = MoveFieldActionValue.ToString();
		
		Color textCurrentColor = transform.FindChild("Text").guiText.color;
		textCurrentColor.a = (Mathf.Sin(Time.time * 4) + 1.0f) / 2.0f;
		transform.FindChild("Text").guiText.color = textCurrentColor;


	}
}
