using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {

	Animator animationControler;
    AudioSource audio;

	void Start ()
	{
		animationControler = GetComponent<Animator>();
		animationControler.SetInteger("RandomIdle", GetComponent<PlayerCharacter>().PlayerNumber);

        audio = GetComponent<AudioSource>();
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
}
