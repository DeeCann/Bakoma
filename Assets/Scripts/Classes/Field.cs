using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Field : IField  {

	private MyFieldType MyType;

	public enum MyFieldType {
		Null = 0,
		RandomMove = 1,
		//RandomBackward = 2,
		ValueMove = 2,
		//ValueBackward = 4,
		Shurtcut = 3
	}

	private int _randomFieldsMovementValue = 0;
	
	private List<bool> sockets = new List<bool>() {false, false, false, false, false};
    private List<Vector3> socketsPositions = new List<Vector3>() { new Vector3(-0.01f, 0, -0.01f), new Vector3(-0.07f, 0, 0.07f), new Vector3(0.07f, 0, 0.07f), new Vector3(-0.07f, 0, -0.07f), new Vector3(0.07f, 0, -0.07f) };

	public Field() {
		MyType = MyFieldType.Null;
	}

	public void SetType(MyFieldType _type){
		MyType = _type;
		if(MyType == MyFieldType.RandomMove) {
			_randomFieldsMovementValue = Random.Range(1,7);
		}

		if(MyType == MyFieldType.ValueMove) {
			_randomFieldsMovementValue = Random.Range(1,3) * 3;
		}
	}


	public int MoveActionValue{
		get{
			return _randomFieldsMovementValue;
		}
	}

	public int GetFreeSocketNumber(int _playerID) {
		//get{
            //for(int i = 0; i < sockets.Count; i++) {
            //    if(sockets[i] == false) {
            //        sockets[i] = true;
            //        return i;
            //    }
            //}
            //return 0;
		//}
        sockets[_playerID] = true;
        return _playerID;
	}

    public int LockSocket {
        set {
            sockets[value] = true;
        }
    }

	public Vector3 GetFreeSocketVectorPosition(int socket) {;
		return socketsPositions[socket];
	}

	public int ReleaseSocket {
		set{
			sockets[value] = false;
		}
	}

	public void OnHoldAction() {}

	public void OnPressAction() {}

	public void OnUnpressAction() {}

	public void OnClikAction() {}

	public void OnObjectEnterAction() {}

	public void OnObjectExitAction() {}

}
