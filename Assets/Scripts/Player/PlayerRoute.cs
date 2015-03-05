using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerRoute: MonoBehaviour {

	private GameObject _myCurrentOccupiedField;
	private GameObject _myLastOccupiedField;
    private int _myLastOccupiedFieldID;
	
	private Stack<Vector3> _myCrossRoadsBackRoute = new Stack<Vector3>();


    /**
     * IMPRTANT!!!
     * */
    private bool _wasInMiniGame = false;

	/**
	 * NEW
	 * */
	private List<GameObject> _myPossibleFields = new List<GameObject>();
	
	private Vector3 _myNextFieldPosition = Vector3.zero;
	private GameObject _goToFieldAfterShortCut;
	
	private int _fieldsToGo = 0;
	private int _myFieldSocketNumber = 0;

	private bool _hasNewFieldToMove = false;
	private bool _isGoingBack = false;
	private bool _hasBackMovement = false;
	private bool _imOnAShortCut = false;
	private bool _iWasOnAShortCut = false;
	private bool _iGotFieldAfterShortCut = false;

	private bool _isWaitingForCrossRoadDecision = false;
    private bool _bypassColliderOnEnterFromMinigame = false;

	void Start() {
        if (PlayerPrefs.GetInt("EnterdMiniGame") == 0)
        {
            _myLastOccupiedField = null;
            _myCurrentOccupiedField = Game.GetStartField;
        }
        


		
	}

    void OnLevelWasLoaded() {
        if (PlayerPrefs.GetInt("EnterdMiniGame") == 1 && Application.loadedLevelName == "Game_Board")
        {
            //_bypassColliderOnEnterFromMinigame = true;
            _wasInMiniGame = true;


            foreach (Transform tile in GameObject.FindGameObjectWithTag("Tiles").transform.FindChild("t1").transform)
            {
                if (tile.GetComponent<FieldSocket>().UniqueId == _myLastOccupiedFieldID)
                    _myLastOccupiedField = tile.gameObject;
            }
            
        }
    }


    void FixedUpdate() {
        if (Game.GameHasEnded)
            _fieldsToGo = 0;

    }
	void OnTriggerEnter(Collider collideObject) {
		if(IfIsNewFieldCollision(collideObject)) {
            //if (!_bypassColliderOnEnterFromMinigame)
            //{
              // if (_myLastOccupiedField != null)
                    //_myLastOccupiedFieldID = _myLastOccupiedField.GetComponent<FieldSocket>().uniqueInstanceID;
               //print(_myLastOccupiedFieldID);
                _myLastOccupiedField = _myCurrentOccupiedField;

                //_bypassColliderOnEnterFromMinigame = false;
            //}
           
			_myCurrentOccupiedField = collideObject.transform.parent.gameObject;
			--_fieldsToGo;
			
			if(_fieldsToGo >= 0) {
				_myFieldSocketNumber = collideObject.transform.parent.GetComponent<FieldSocket>().TakeSocketNumber;
				_myNextFieldPosition = collideObject.transform.parent.GetComponent<FieldSocket>().TakeSocketVectorPosition(_myFieldSocketNumber);
                
                if (collideObject.transform.parent.tag == "EndPathField") {
                    if (Game.DidPlayerGetAllFruits())
                        _fieldsToGo = 0;
                }
			}

            
		}

        
	}

    void OnTriggerExit(Collider collideObject)
    {


        if (collideObject.name == "Tile-tramp" || collideObject.transform.root.name == "SpecialTiles")
        {
            _myLastOccupiedFieldID = collideObject.GetComponent<FieldSocket>().uniqueInstanceID;
        }
        else if (collideObject.name != "CrossRoadsArrowField")
        {
            //print(collideObject.name + " - " + collideObject.transform.parent.name);
            _myLastOccupiedFieldID = collideObject.transform.parent.GetComponent<FieldSocket>().uniqueInstanceID;
        }
        //print(_myLastOccupiedFieldID);
    }

	public bool IsMyMove {
		get {
			if(Game.GetCurrentPlayer.GetInstanceID() == gameObject.GetInstanceID())
				return true;
			else
				return false;
		}
	}

	public int NumberOfFieldsToGo {
		set{
			_fieldsToGo = value;
			GeneratePossibleWayFields();
			FindNextFieldToGo();
		}

        get {
            return _fieldsToGo;
        }
	}

	public Vector3 MyNextField {
		get {
			return _myNextFieldPosition;
		}
	}

	public bool IsWaitingForInteraction {
		get{
			return _isWaitingForCrossRoadDecision;
		}
	}

	public bool MoveHasEnded() {
		// Check distance only in X and Z positions. Y can be different 
		Vector2 currentPositionInXZ = new Vector2(transform.position.x, transform.position.z);
		Vector2 nextPositionInXZ = new Vector2(_myNextFieldPosition.x, _myNextFieldPosition.z);

		if(Vector3.Distance(currentPositionInXZ, nextPositionInXZ) < 0.05f && _hasNewFieldToMove) {

			if(_imOnAShortCut) {
				_imOnAShortCut = false;
				return false;
			}
            
			GeneratePossibleWayFields();

			//print (_fieldsToGo);
			/**
			 * REACHED END OF ROUTE
			 * */
			if(_fieldsToGo > 0 && _myPossibleFields.Count == 0) {
				GetComponent<PlayerAnimations>().StopMoveAnimation();
				Game.NextRound();
				return true;
			}

			/**
			 * HAS ROUTE FIELDS
			 * */
			if(_fieldsToGo > 0 && _myPossibleFields.Count >= 0) {
				if(!_isWaitingForCrossRoadDecision)
					FindNextFieldToGo();
				return false;
			}

			/**
			 * HAS NO MORE FIELDS TO GO
			 * CHECK WHAT KIND OF FIELD WE HAVE
			 * */

			if(_fieldsToGo == 0) {

				/** 
				 * MAYBE WE ARE GOING BACK FROM SOME BACWARD FIELD
				* THIS MUST BE FIRST BECAUSE IN DoWeHaveAnyFieldAction() WE CHANGE _hasBackMovement = TRUE;
				 * */
				if(_hasBackMovement) {
					_isGoingBack = true;
					_hasBackMovement = false;
					return false;
				}

				/**
				 * DO WE HAVE ANY ACTION ON FIELD
				 * */
				if(!DoWeHaveAnyFieldAction()) {
					GetComponent<PlayerAnimations>().StopMoveAnimation();

					// set proper socket position on end of movement
					transform.position = new Vector3(_myNextFieldPosition.x, transform.position.y,  _myNextFieldPosition.z);
					Game.NextRound();

					return true;
				}

				/** 
				 * IF WE ARE ON A SHORTCUT CHECK IF WE HAVE CROSSROADS .. NEAREST STOP POINT
				 * */
				if(_imOnAShortCut) {
					if(_myPossibleFields.Count > 1) {
						_imOnAShortCut = false;
						_iWasOnAShortCut = true;
						StopMove();
						
						return true;
					}
					_fieldsToGo++;
					FindNextFieldToGo();
					
					return false;
				}


				return false;
			}
			return false;
		}

		return false;
	}

	public bool IsThisLastMovement {
		get{
			if(_fieldsToGo == 0) 
				return true;
			else
				return false;
		}
	}
	
	public void GoInThisDirection(Vector3 directionPoint) {
		foreach(GameObject _field in _myPossibleFields) {
			_field.GetComponentInChildren<CrossRoad>().DectivateRouteArrow();
		}
		SetNextMoveParams(directionPoint);
		_isWaitingForCrossRoadDecision = false;

        PinchZoom.ResetZoom();

       // _bypassColliderOnEnterFromMinigame = false;
	}
	
	public int StartFieldSocket {
		set{
			_myFieldSocketNumber = value;
		}
		get{
			return _myFieldSocketNumber;
		}
	}


	private void FindNextFieldToGo() {
		if(_isGoingBack) {
			// going back where we came from - one time action, else is _hasBackMovement
			_myPossibleFields.Add(_myLastOccupiedField);
			SetNextMoveParams(_myLastOccupiedField.transform.position);
			return;
		}
		
		if(_iWasOnAShortCut && _iGotFieldAfterShortCut) {
			_myPossibleFields.Add(_goToFieldAfterShortCut);
			SetNextMoveParams(_goToFieldAfterShortCut.transform.position);
			_iWasOnAShortCut = false;
			_iGotFieldAfterShortCut = false;
			return;
		}

		if(_myPossibleFields.Count == 0) {
            if (_myCurrentOccupiedField.tag == Tags.StartPoint)
            {
                _myLastOccupiedFieldID = _myLastOccupiedField.GetComponent<FieldSocket>().uniqueInstanceID;
                _myLastOccupiedField = _myCurrentOccupiedField;
            }
			StopMove();
		} else if(_myPossibleFields.Count > 1) {
			// if we were on a shortcut, we stop. End of moving
			if(_imOnAShortCut) { 
				_imOnAShortCut = false;
				_iWasOnAShortCut = true;
				StopMove();

				return;
			}
			// if we are goin back we take from stack first crossroad route
			else if(_hasBackMovement) {
				SetNextMoveParams(_myCrossRoadsBackRoute.Pop());
				return;
			}
			else {
				_myCrossRoadsBackRoute.Push(_myLastOccupiedField.transform.position);
				// We must check if the crossroad isn't somekind of shortcut
				if(_myCurrentOccupiedField.GetComponent<ShortcutField>() == null) {
					GetComponent<PlayerAnimations>().StartPickingRoadIdle();
					
					foreach(GameObject _field in _myPossibleFields) {
      
						if(_field != null) {
							_field.GetComponentInChildren<CrossRoad>().ActivateRouteArrow( _myCurrentOccupiedField, gameObject );
						}
					}

                    PinchZoom.ZoomOutForCrossroads();
					_isWaitingForCrossRoadDecision = true;

				} else {
					// If it is shortcut we must choose direction different than shortcut
					foreach(GameObject fieldObjectPosition in _myPossibleFields) {
						if(_myCurrentOccupiedField.GetComponent<ShortcutField>().GetStartShortCutField.GetInstanceID() != fieldObjectPosition.GetInstanceID()) {
							SetNextMoveParams(fieldObjectPosition.transform.position);

							break;
						}
					}
					
				}
			}
		} else 
			SetNextMoveParams(_myPossibleFields[0].transform.position);
	}

	private void GeneratePossibleWayFields() {
		_myPossibleFields.Clear();
		GameObject[] possibleFields = _myCurrentOccupiedField.transform.FindChild("RouteCollider").GetComponent<RouteCollider>().SearchForNextFieldToGo();
		foreach(GameObject fieldObject in possibleFields) {

			// check if the only way is back and we are standin on StartPathField - can happen when we came back to start field on route
            if (fieldObject != null && fieldObject.GetInstanceID() == _myLastOccupiedField.GetInstanceID() && (_myCurrentOccupiedField.tag == "StartPathField" || _myCurrentOccupiedField.tag == "EndPathField"))
				_myPossibleFields.Add (fieldObject);

            if (_wasInMiniGame)
            {
                if (fieldObject != null) {
                    if(fieldObject.GetComponent<FieldSocket>().uniqueInstanceID != _myLastOccupiedFieldID)
                        _myPossibleFields.Add(fieldObject);
                    else
                        _myLastOccupiedField = fieldObject;
                }
            }
            else if (fieldObject != null && fieldObject.GetInstanceID() != _myLastOccupiedField.GetInstanceID())
            {

                //if (fieldObject.GetComponent<FieldSocket>().uniqueInstanceID != _myLastOccupiedFieldID)
                //{
                    _myPossibleFields.Add(fieldObject);
                //}
			}
		}

        if (_wasInMiniGame)
            _wasInMiniGame = false;
	}

	private void SetNextMoveParams(Vector3 fieldTransform) {
		_myCurrentOccupiedField.GetComponent<FieldSocket>().ReleaseSocket = _myFieldSocketNumber;
		_myNextFieldPosition = fieldTransform;
		_isGoingBack = false;
		_hasNewFieldToMove = true;

		GetComponent<PlayerAnimations>().StartMoveAnimation();
	}
	
	private void StopMove() {
		_isGoingBack = false;

		if(_hasBackMovement) 
			_isGoingBack = true;

		_hasBackMovement = false;
		_hasNewFieldToMove = false;
		
		GetComponent<PlayerAnimations>().StopMoveAnimation();
		
		Game.NextRound();
	}
	
	private bool IfIsNewFieldCollision(Collider someSollider) {
        if (someSollider.transform.tag != Tags.Player && someSollider.transform.tag != Tags.FruitOnBoard && someSollider.transform.parent.tag.Contains(Tags.PathField))
			return true;
		else
			return false;
	}
	
	private bool DoWeHaveAnyFieldAction() {
		if(_myCurrentOccupiedField.transform.GetComponentInParent<SpecialMoveField>() != null) {
			if(_myCurrentOccupiedField.transform.GetComponentInParent<SpecialMoveField>().HasAnyFieldMoveAction) {
				_fieldsToGo = _myCurrentOccupiedField.transform.GetComponentInParent<SpecialMoveField>().MoveFieldActionValue;

				_myPossibleFields.Clear();
				GameObject specialMoveField = _myCurrentOccupiedField.transform.FindChild("RouteCollider").GetComponent<RouteCollider>().GetSpecialMoveField();

                if (specialMoveField.GetInstanceID() == _myLastOccupiedField.GetInstanceID())
                {
					_isGoingBack = true;
					_hasBackMovement = true;
				} else {
					if(_hasBackMovement)
						_hasBackMovement = false;
				}

				_myPossibleFields.Add (specialMoveField);
				SetNextMoveParams(_myPossibleFields[0].transform.position);















//				if(_fieldsToGo < 0) {
//					_isGoingBack = true;
//					_hasBackMovement = true;
//					_fieldsToGo *= -1;
//				} else {
//					if(_hasBackMovement) {
//						_hasBackMovement = false;
//					}
//				}
				return true;
			} else
				return false;
		}
		
		if(_myCurrentOccupiedField.transform.GetComponentInParent<ShortcutField>() != null) {
			_imOnAShortCut = true;
			SetNextMoveParams(_myCurrentOccupiedField.transform.GetComponentInParent<ShortcutField>().GetStartShortCutField.transform.position);
			if(_myCurrentOccupiedField.transform.GetComponentInParent<ShortcutField>().IsThereAnFieldAfterShortcut) {
				_goToFieldAfterShortCut = _myCurrentOccupiedField.transform.GetComponentInParent<ShortcutField>().GetNextFieldAfterShortCut;
				_iGotFieldAfterShortCut = true;
			}
			
			_fieldsToGo = 1; 	// on shortcuts we use "by one step"
			return true;
		}
		
		return false;
		
		
	}
}
