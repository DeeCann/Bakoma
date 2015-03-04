using UnityEngine;
using System.Collections;

public class OnBoardFruit : MonoBehaviour {

    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag == "Player") {
            collider.enabled = false;
            GetComponent<AudioSource>().Play();
            GetComponent<Animation>().CrossFade("FruitIsCought");

            transform.GetComponentInChildren<ParticleSystem>().Emit(100);
            Game.SetFruitPoint(gameObject.name, 1);
        }
    }
}
