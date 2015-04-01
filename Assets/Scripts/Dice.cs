using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour {

	public Transform diceCamera; 

	private float rollingStartTime = 0;
	private float rollingTime = 1;

	private bool startToRoll = false;
	private static bool releaseDiceToRoll = false;

	private static bool _newDiceThrow = false;
	private static int _diceValue = 0;

	void FixedUpdate() {
		if(startToRoll && rollingStartTime + rollingTime < Time.time ) {
			animation.Stop();
			transform.rotation = showRandomRollDice;
			startToRoll = false;
		}
	}

	void Update () {
		if(Input.GetMouseButtonDown(0) && !startToRoll && releaseDiceToRoll && !trapsPanelControler.IsTrapPanelEnabled && !cardPanelControler.IsCardPanelEnabled) {
			Ray ray = diceCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit)){
				if(hit.collider.gameObject.name == "DiceCollider"){
					animation.Play();
					rollingStartTime = Time.time;
					startToRoll = true;
					releaseDiceToRoll = false;
                    hit.collider.gameObject.GetComponent<AudioSource>().Play();
				}
			}
		}

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            _newDiceThrow = true;
            _diceValue = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _newDiceThrow = true;
            _diceValue = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _newDiceThrow = true;
            _diceValue = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _newDiceThrow = true;
            _diceValue = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _newDiceThrow = true;
            _diceValue = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _newDiceThrow = true;
            _diceValue = 6;
        }
	}

	public static bool CanDoDiceRoll {
		get{
			return releaseDiceToRoll;
		}

		set{
			releaseDiceToRoll = value;
		}
	}

	public static bool HasNewDiceThrow {
		get{
			if(_newDiceThrow) {
				_newDiceThrow = false;
				return true;
			}
			
			return false;
		}
	}
	
	public static int FieldsToGo {
		get{
			return _diceValue;
		}
	}

	private Quaternion showRandomRollDice {
		get{
			_diceValue = Random.Range(1,7);

            
            //switch (Input.GetKeyDown) { 
            //    case KeyCode.Alpha1:  _diceValue = 1;  break;
            //    case KeyCode.Alpha2: _diceValue = 2; break;
            //    case KeyCode.Alpha3: _diceValue = 3; break;
            //    case KeyCode.Alpha4: _diceValue = 4; break;
            //    case KeyCode.Alpha5: _diceValue = 5; break;
            //    case KeyCode.Alpha6: _diceValue = 5; break;
            //}
            //_diceValue = 4;
			_newDiceThrow = true;
			switch(_diceValue) {
				case 1: return Quaternion.AngleAxis(180, Vector3.right);
				case 2: return Quaternion.identity;
				case 3: return Quaternion.AngleAxis(-90, Vector3.right); 
				case 4: return Quaternion.AngleAxis(90, Vector3.right);
				case 5: return Quaternion.AngleAxis(-90, Vector3.forward); 
				case 6: return Quaternion.AngleAxis(90, Vector3.forward); 
				default: return Quaternion.identity; 
			}
		}
	}



}
