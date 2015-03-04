using UnityEngine;
using System.Collections;

public class FarmCharacterMove : MonoBehaviour {

	private Animator animationControler;
	private float _horizontalInput;

	private bool startJump = false;
	private float startJumpTime = 0;


	void Start ()
	{
		animationControler = GetComponent<Animator>();
	}

	void Update() {
		if(Application.platform == RuntimePlatform.OSXEditor)
			_horizontalInput = Input.GetAxis("Horizontal") * 0.3f;
		else 
			_horizontalInput = Input.acceleration.x;

		if(Application.platform == RuntimePlatform.OSXEditor) {
			if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
				startJump = true;
		} else {
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && IsGrounded)
				startJump = true;
		}
	}

	void FixedUpdate() {
		if(IsGrounded) {
			if(startJumpTime + 0.1f < Time.time)
				animationControler.SetBool("Jump", false);
		}

		if(startJump)
			Jump();

		if(CanMove)
		{
			animationControler.SetFloat("Move", _horizontalInput * 8);

			float angle = (-90 * _horizontalInput * 4) + 180;
			angle = Mathf.Clamp(angle, 90, 270);

			transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
			transform.position = new Vector3(transform.position.x + (_horizontalInput / 5), transform.position.y, 0);
		} else {
			animationControler.SetFloat("Move", Mathf.Lerp( _horizontalInput, 0, Time.deltaTime * 2));
			transform.rotation = Quaternion.Lerp(transform.rotation,  Quaternion.AngleAxis(180, Vector3.up), Time.deltaTime * 6);
		}
	}

	void OnTriggerEnter(Collider collideObject) {
		if(collideObject.tag == "MiniGame_Apple") {
			collideObject.transform.FindChild("GrabWave").animation.Play();
			Destroy(collideObject.transform.FindChild("GrabWave").gameObject, 1);
			collideObject.transform.FindChild("GrabWave").transform.parent = null;
			Destroy(collideObject.gameObject);
		}
	}

	private void Jump() {
		startJumpTime = Time.time;
		startJump = false;
		rigidbody.AddForce(transform.up * 5.8f, ForceMode.Impulse);
		animationControler.SetBool("Jump", true);
	}

	private bool IsGrounded {
		get {
//			RaycastHit hit;
//			if(Physics.Raycast(new Vector3(transform.position.x,transform.position.y +  0.5f,transform.position.z), -Vector3.up, out hit, collider.bounds.extents.y + 0.01f)) {
//				print (hit.collider.name);
//			}
			return Physics.Raycast(new Vector3(transform.position.x,transform.position.y +  0.5f,transform.position.z), Vector3.down, collider.bounds.extents.y + 0.01f);
		}
	}

	private bool CanMove{
		get{
			if(Mathf.Abs(_horizontalInput) > 0.1f)
				return true;
			else
				return false;
		}
	}
}
