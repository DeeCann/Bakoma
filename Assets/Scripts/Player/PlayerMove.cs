using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour {
    
	private bool _hasNewMove = false;
	private Vector3 _nextField = Vector3.zero;
	private Quaternion lookAtRotation = Quaternion.AngleAxis(180, Vector3.up);
    private bool _speedUp = false;
    private float _speedUpMaxTIme = 3;
    private float _speedFieldFactor = 0;

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

            if (_speedUp) {

                transform.position = Vector3.MoveTowards(transform.position, _nextField, Time.deltaTime * _speedUpMaxTIme);
                print(Time.deltaTime * _speedUpMaxTIme);
                _speedUpMaxTIme -= 0.1f * _speedFieldFactor;

                if (_speedUpMaxTIme <= 0.6f)
                    _speedUp = false;
            } else
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

    public void SpeedUp(float speedFieldFactor) {
        
        _speedUp = true;
        _speedFieldFactor = speedFieldFactor * 0.5f;
        _speedUpMaxTIme = 3;
        transform.FindChild("SoundFX").GetComponent<PlayerSoundsFX>().BoostSound();

    }

}
