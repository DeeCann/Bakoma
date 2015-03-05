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
				}
			}
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
           // _diceValue = 5;
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
