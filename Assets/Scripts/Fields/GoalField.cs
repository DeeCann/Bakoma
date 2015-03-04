using UnityEngine;
using System.Collections;

public class GoalField : MonoBehaviour {

   

    void OnTriggerEnter(Collider playerCollider)
    {
        if (playerCollider.tag == "Player")
        {
           Game.GameHasEnded = true;
        }
    }

   
}
