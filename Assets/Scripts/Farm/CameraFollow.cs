using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public float xSmooth = 8;
	private Transform player;

	void Start() {
		if (GameObject.Find ("hipcio(Clone)")) {
			player = GameObject.Find ("hipcio(Clone)").transform;
				}
		if (GameObject.Find ("zaba(Clone)")) {
			player = GameObject.Find ("zaba(Clone)").transform;
				}
		if (GameObject.Find ("tygrys(Clone)")) {
			player = GameObject.Find ("tygrys(Clone)").transform;
		}
		if (GameObject.Find ("mis(Clone)")) {
			player = GameObject.Find ("mis(Clone)").transform;
		}
		if (GameObject.Find ("pies(Clone)")) {
			player = GameObject.Find ("pies(Clone)").transform;
		}

	}

	void FixedUpdate() {
		TrackPlayer();
	}

	void TrackPlayer() {

		float targetX = transform.position.x;
		targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime * 2);
		targetX = Mathf.Clamp(targetX, -13, 37);
		transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
	}
}
