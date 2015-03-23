using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {

	Animator animationControler;
    AudioSource audio;

    private bool _speedUp = false;
    private int _speedUpMaxSpeed = 7;

	void Start ()
	{
		animationControler = GetComponent<Animator>();
		animationControler.SetInteger("RandomIdle", GetComponent<PlayerCharacter>().PlayerNumber);

        audio = GetComponent<AudioSource>();
	}

    void FixedUpdate() {
        if (_speedUp)
            animationControler.speed = Mathf.Lerp(animationControler.speed, 1, Time.deltaTime * 2);
    }
	public void StartMoveAnimation() {
		animationControler.SetBool("PickRoadIdle", false);
		animationControler.SetBool("Run", true);

        audio.Play();
	}
	
	public void StopMoveAnimation() {
		animationControler.SetBool("Run", false);

        audio.Stop();
	}
	
	public void StartPickingRoadIdle() {
		animationControler.SetBool("PickRoadIdle", true);

        audio.Stop();
	}
	
	public void StopPickingRoadIdle() {
		animationControler.SetBool("PickRoadIdle", false);

        audio.Play();
	}

    public void SpeedUp(float speedFactor) {
        _speedUp = true;
        animationControler.speed = _speedUpMaxSpeed - speedFactor;
    }
}
