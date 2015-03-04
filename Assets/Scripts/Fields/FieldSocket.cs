using UnityEngine;
using System.Collections;

public class FieldSocket : MonoBehaviour {

    public int uniqueInstanceID;
	private Field FieldObj;
	
	public int TakeSocketNumber {
		get{
			return FieldObj.GetFreeSocketNumber;
		}
	}
	
	public Vector3 TakeSocketVectorPosition(int socket) {
		return transform.position - FieldObj.GetFreeSocketVectorPosition(socket);
	}
	
	public int ReleaseSocket {
		set{
			FieldObj.ReleaseSocket = value;
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
}
