using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public float xSmooth = 8;
	private Transform player;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void FixedUpdate() {
		TrackPlayer();
	}

	void TrackPlayer() {

		float targetX = transform.position.x;
		targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime * 2);
		targetX = Mathf.Clamp(targetX, -13, 13);
		transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
	}
}
