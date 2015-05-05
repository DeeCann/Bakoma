using UnityEngine;
using System.Collections;

public class FieldSocket : MonoBehaviour {

    public int uniqueInstanceID;
	private Field FieldObj;
    private int _mySocket = 0;

	public int TakeSocketNumber(int _playerID) {
		//get{
        FieldObj.GetFreeSocketNumber(_playerID);
        _mySocket = _playerID; 
			return _mySocket;
		//}
	}
	
	public Vector3 TakeSocketVectorPosition(int socket) {
		return transform.position - FieldObj.GetFreeSocketVectorPosition(socket);
	}
	
	public int ReleaseSocket {
		set{
			FieldObj.ReleaseSocket = value;
            //for (int i = 0; i <= 4; i++)
            //{
            //    if (PlayerPrefs.HasKey("FieldSocket_" + uniqueInstanceID + "_" + i))
            //    {
            //        print("release " + "FieldSocket_" + uniqueInstanceID + "_" + i);
            //        PlayerPrefs.DeleteKey("FieldSocket_" + uniqueInstanceID + "_" + i);
            //        break;
            //    }
            //}
            PlayerPrefs.DeleteKey("FieldSocket_" + uniqueInstanceID + "_" + Game.GetCurrentPlayerRound);
		}
	}

    public int LockSocket {
        set {
            FieldObj.LockSocket = value;
        }
    }
	
	public Field MyFieldObject {
		set{
			FieldObj = value;
		}
	}

    public int UniqueId {
        set {
            uniqueInstanceID = value;
        }

        get {
            return uniqueInstanceID;
        }
    }

    public int GetSocketNumber {
        get {
            return _mySocket;
        }
    }
}
