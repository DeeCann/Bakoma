using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour {

	private bool _hasNewMove = false;
	private Vector3 _nextField = Vector3.zero;
	private Quaternion lookAtRotation = Quaternion.AngleAxis(180, Vector3.up);

	void Awake() {
		// isKinematic must be blocked on hills to stop character from slide down
		rigidbody.isKinematic = true;
	}

	void Update() {
		if(GetComponent<PlayerRoute>().IsMyMove) { 
			if(Dice.HasNewDiceThrow) {
				GetComponent<PlayerRoute>().NumberOfFieldsToGo = Dice.FieldsToGo;
				_hasNewMove = true;
				rigidbody.isKinematic = false;
			}
		}
	}

	void FixedUpdate() {
		if(_hasNewMove) {
			_nextField = GetComponent<PlayerRoute>().MyNextField;

			if(!GetComponent<PlayerRoute>().IsWaitingForInteraction)
				RotateTowards();

			if(GetComponent<PlayerRoute>().MoveHasEnded()) {
				_hasNewMove = false;
				Dice.CanDoDiceRoll = true;
			}

			transform.position = Vector3.MoveTowards(transform.position, _nextField, Time.deltaTime * 0.6f);
		} else {
			transform.rotation = lookAtRotation;
			rigidbody.isKinematic = true;
		}
	}

	private void RotateTowards() {
		lookAtRotation = Quaternion.LookRotation(new Vector3( _nextField.x, transform.position.y, _nextField.z) - transform.position, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, Time.deltaTime * 12);
	}

}
