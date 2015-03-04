using UnityEngine;
using System;
using System.Collections;

public class RouteCollider : MonoBehaviour {

	private static GameObject[] foundWayFields = new GameObject[4];

	/*
	 * DEBUG
	 * */
	private bool showDebug = true;
	private int debugRayDisplayTime = 1;
	private Vector3[] debugStartRay = new Vector3[4];
	private Vector3[] debugStopRay = new Vector3[4];
	private bool showDebugRay = true;
	private float debugRayTime = 0;

	void Update() {
		if(showDebug && showDebugRay && debugRayTime + debugRayDisplayTime > Time.time) {
			for (int i =0; i <= 3; i++)
				Debug.DrawRay(debugStartRay[i], debugStopRay[i], Color.green);
		}
	}
	
	public GameObject[] SearchForNextFieldToGo() {
		Array.Clear(foundWayFields, 0, 4);
		showDebugRay = false;
		int foundedFieldsArrCounter = 0;
		Ray ray;
		RaycastHit hit;
		Vector3 startRayDirection = Vector3.zero;
		Vector3 stopRayDirection = Vector3.zero;

		for(int i = 0; i <= 3; i++) {
			switch(i) {
				case 0: 
					startRayDirection = transform.position + (transform.right * -1 * (transform.localScale.x / 2)); 
					stopRayDirection = transform.right * -1; break;
				case 1: 
					startRayDirection = transform.position + (transform.right * (transform.localScale.x / 2)); 
					stopRayDirection = transform.right; break;
				case 2:
					startRayDirection = transform.position + (transform.forward * (transform.localScale.x / 2)); 
					stopRayDirection = transform.forward; break;
				case 3: 
					startRayDirection = transform.position + (transform.forward * -1 * (transform.localScale.x / 2)); 
					stopRayDirection = transform.forward * -1; break;
			}

			ray = new Ray(startRayDirection, stopRayDirection);
			Debug.DrawRay(startRayDirection, stopRayDirection);
			if(Physics.Raycast(ray, out hit, 0.4f) && hit.collider.transform.parent.gameObject.layer != 11) {
				debugStartRay[foundedFieldsArrCounter] = startRayDirection;
				debugStopRay[foundedFieldsArrCounter] = stopRayDirection;
				foundWayFields[foundedFieldsArrCounter] = hit.collider.transform.parent.gameObject;
				foundedFieldsArrCounter++;
			}
		}
		debugRayTime = Time.time;
		showDebugRay = true;
		return foundWayFields;
	}

	public GameObject GetSpecialMoveField() {
		Ray ray;
		RaycastHit hit;
		Vector3 startRayDirection = transform.position;
		Vector3 stopRayDirection = transform.forward;
		GameObject foundedField = new GameObject();


		ray = new Ray(startRayDirection, stopRayDirection);
		Debug.DrawRay(startRayDirection, stopRayDirection);
		if(Physics.Raycast(ray, out hit, 0.4f)) {
			foundedField = hit.collider.transform.parent.gameObject;
		}

		return foundedField;

	}
}
