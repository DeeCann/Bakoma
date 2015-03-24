using UnityEngine;
using System.Collections;

public class PlayerSoundsFX : MonoBehaviour {

    public AudioClip boostAudio;
    private AudioSource myAudio;
	
	void Awake () {
        myAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BoostSound() {
        myAudio.clip = boostAudio;
        myAudio.loop = false;
        myAudio.Play();
    }
}
