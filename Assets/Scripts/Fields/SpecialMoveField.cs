using UnityEngine;
using System.Collections;

public class SpecialMoveField : MonoBehaviour {
	
	public bool RndMove;
	public bool ValueMove;	
	
	/*
	 * Field object
	 * */
	private Field FieldObj;
    private GameObject _moveGUISymbol;
	private bool _hasSomeMoveAction = false;
    private bool _showGoMoveNumber = false;
    private Color _startTextColor;
    private Collider _playerCollider;

	void Awake() {
		FieldObj = new Field();
		if(RndMove) {
			FieldObj.SetType(Field.MyFieldType.RandomMove);
			_hasSomeMoveAction = true;
		} else if(ValueMove) {
			FieldObj.SetType(Field.MyFieldType.ValueMove);
			_hasSomeMoveAction = true;
		}
		
		gameObject.GetComponent<FieldSocket>().MyFieldObject = FieldObj;
        _moveGUISymbol = transform.FindChild("Text").gameObject;
        _startTextColor = transform.FindChild("Text").guiText.color;
	}

    void Update()
    {
        if (_showGoMoveNumber)
        {

            ShowHint();
        }
    }

    void OnTriggerEnter(Collider playerCollider) {
        if (playerCollider.tag == "Player" && playerCollider.gameObject.GetComponent<PlayerRoute>().NumberOfFieldsToGo == 1)
        {
           // _showGoMoveNumber = true;
            _playerCollider = playerCollider;
            StartCoroutine(SpeedUp());
        }
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
    private void ShowHint()
    {
        Vector3 pos = transform.position;
        _moveGUISymbol.transform.position = Camera.main.WorldToViewportPoint(pos);
        _moveGUISymbol.guiText.text = MoveFieldActionValue.ToString();

        Color textCurrentColor = _moveGUISymbol.guiText.color;
        textCurrentColor.a -= 0.5f * Time.deltaTime;
        _moveGUISymbol.guiText.color = textCurrentColor;

        _moveGUISymbol.guiText.fontSize += 5;
        
        if (textCurrentColor.a <= 0.2f) {
            _moveGUISymbol.guiText.text = "";
            _showGoMoveNumber = false;
            textCurrentColor.a = 0.99f;
            _moveGUISymbol.guiText.color = _startTextColor;
            _moveGUISymbol.guiText.fontSize = 40;
            _playerCollider.transform.FindChild("SpeedUpFX").GetComponent<TrailRenderer>().enabled = false;
        }
    }

    IEnumerator SpeedUp() {
        yield return new WaitForSeconds(0.5f);
        _showGoMoveNumber = true;
        _playerCollider.GetComponent<PlayerAnimations>().SpeedUp(7 - FieldObj.MoveActionValue);
        _playerCollider.GetComponent<PlayerMove>().SpeedUp(7 - FieldObj.MoveActionValue);
        _playerCollider.transform.FindChild("SpeedUpFX").GetComponent<TrailRenderer>().enabled = true;
    }
}
