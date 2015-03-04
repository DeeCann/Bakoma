using UnityEngine;
using System.Collections;

public class CrossRoadArrow : MonoBehaviour {

	private GameObject _myParentCharacter;
	private GameObject _myParentField;

	private bool _listenForClickAction = false;

    void Update() {
        if (_listenForClickAction)
            FollowCamera.RayFroCrossRoadsArrow();
    }

	public GameObject SetMyParentCharacterReference {
		set {
			_myParentCharacter = value;
			_listenForClickAction = true;
		}
	}

	public GameObject SetMyParentFieldReference {
		set {
			_myParentField = value;
		}
	}

    public bool CanListen {
        set {
            _listenForClickAction = value;
        }

        get {
            return _listenForClickAction;
        }
    }

    public void GoIntoMyDirection() {
        _listenForClickAction = false;
        _myParentCharacter.GetComponent<PlayerRoute>().GoInThisDirection(_myParentField.transform.position);
    }
}
