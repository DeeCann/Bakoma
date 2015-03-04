using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShortcutField : MonoBehaviour {

	public GameObject StartShortCutField;
	public GameObject StopShortCutField = null;

	private Field FieldObj;
	private bool _hasSomeMoveAction = false;
	
	void Awake() {
		FieldObj = new Field();
		FieldObj.SetType(Field.MyFieldType.Shurtcut);
		_hasSomeMoveAction = true;

		gameObject.GetComponent<FieldSocket>().MyFieldObject = FieldObj;	
	} 
	
	public bool HasAnyFieldMoveAction {
		get{
			return _hasSomeMoveAction;
		}
	}
	
	public GameObject GetStartShortCutField {
		get{
			return StartShortCutField;
		}
	}

	public bool IsThereAnFieldAfterShortcut {
		get{
			if(StopShortCutField == null)
				return false;
			else
				return true;
		}
	} 

	public GameObject GetNextFieldAfterShortCut {
		get{
			return StopShortCutField;
		}
	}
}
