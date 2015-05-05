using UnityEngine;
using System.Collections;

public class WalkCollider : MonoBehaviour {

    private float _playerEnteredTime = 0;
    private bool _hasPlayerEntered = false;

    void Update()
    {
        //if (_hasPlayerEntered && _playerEnteredTime + 0.1f < Time.time)
        //{
        //    print("Set " + "FieldSocket_" + transform.parent.GetComponent<FieldSocket>().uniqueInstanceID + "_" + Game.GetCurrentPlayerRound);
        //    PlayerPrefs.SetInt("FieldSocket_" + transform.parent.GetComponent<FieldSocket>().uniqueInstanceID + "_" + Game.GetCurrentPlayerRound, 1);
        //    _hasPlayerEntered = false;
        //}
    }

    void OnTriggerEnter(Collider playerCollider)
    {
        if (playerCollider.tag == "Player" && playerCollider.gameObject.GetComponent<PlayerRoute>().NumberOfFieldsToGo == 1)
        {
            PlayerPrefs.SetInt("FieldSocket_" + transform.parent.GetComponent<FieldSocket>().uniqueInstanceID + "_" + Game.GetCurrentPlayerRound, 1);
           // _hasPlayerEntered = true;
           // _playerEnteredTime = Time.time;
        }
            
    }

    //void OnTriggerExit(Collider playerCollider)
    //{
    //    if (playerCollider.tag == "Player" && playerCollider.gameObject.GetComponent<PlayerRoute>().NumberOfFieldsToGo == 1)
    //        _hasPlayerForMiniGame = true;
    //}
}
