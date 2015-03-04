using UnityEngine;
using System.Collections;

public class TrapField : MonoBehaviour {

	private Field FieldObj;
    private HUD _HUDControler;

	void Awake() {
		FieldObj = new Field();
		gameObject.GetComponent<FieldSocket>().MyFieldObject = FieldObj;
        _HUDControler = GameObject.FindGameObjectWithTag("HUDControler").GetComponent<HUD>();
	} 
	
	void OnTriggerEnter(Collider playerCollider) {
        if (playerCollider.tag == "Player")
        {
            if (playerCollider.gameObject.GetComponent<PlayerRoute>().NumberOfFieldsToGo == 1)
                PlayerHasEnterTrap();
        };
	}


	public Field GetFieldObject {
		get{
			return FieldObj;
		}
	}

    private void PlayerHasEnterTrap() {
        _HUDControler.ShowTrapPanel();
    }
}
