using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {

	private int _myNumber = 0;

	public int PlayerNumber {
		set{
			_myNumber = value;
		}
		get{
			return _myNumber;
		}
	}
}
