using UnityEngine;
using System.Collections;

public class SpecialMoveField : MonoBehaviour {
	
	public bool RndMove;
	//public bool RndBackMove;
	//[Range(0,6)]
	public bool ValueMove;
//	[Range(0,6)]
//	public int BackMoveValue;
	
	public bool EnableTextHelper = true;
	
	/*
	 * Field object
	 * */
	private Field FieldObj;
	private bool _hasSomeMoveAction = false;
	
	
	void Awake() {
		FieldObj = new Field();
		if(RndMove) {
			FieldObj.SetType(Field.MyFieldType.RandomMove);
			_hasSomeMoveAction = true;
//		} else if(RndBackMove) {
//			FieldObj.SetType(Field.MyFieldType.RandomBackward);
//			_hasSomeMoveAction = true;
		} else if(ValueMove) {
			FieldObj.SetType(Field.MyFieldType.ValueMove);
			_hasSomeMoveAction = true;
		}
//		} else if(BackMoveValue > 0) {
//			FieldObj.SetType(Field.MyFieldType.ValueBackward);
//			_hasSomeMoveAction = true;
//		}
		
		gameObject.GetComponent<FieldSocket>().MyFieldObject = FieldObj;
	} 
	
	//void Update() {
		//if(HasAnyFieldMoveAction && EnableTextHelper)
		//	DrawGuiText();
	//}
	
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
        
        transform.FindChild("Text").guiText.fontSize =  System.Convert.ToInt16 (40 - Vector3.Distance(Camera.main.transform.position, transform.position) * 3);
	}
}
