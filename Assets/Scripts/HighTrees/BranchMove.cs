using UnityEngine;
using System.Collections;

public class BranchMove : MonoBehaviour {
	private Vector2 destinationPosition = Vector3.zero;
	private bool getPosition = false;

	void Update () {
		if (Input.GetMouseButtonDown(0))       
			getPosition = true;

		if (Input.GetMouseButtonUp(0))       
			getPosition = false;

		if(getPosition) {

			destinationPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);   
			transform.position = new Vector2(transform.position.x, destinationPosition.y); 
		}


	}
}
