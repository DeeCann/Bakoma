using UnityEngine;
using System.Collections;

public class EndField : MonoBehaviour
{
    
    private Field FieldObj;
    private float _playerEnteredTime = 0;
    private bool _playerHasReachedEnd = false;

    void Awake()
    {
        FieldObj = new Field();
        gameObject.GetComponent<FieldSocket>().MyFieldObject = FieldObj;
    }

    void Update()
    {
        if (_playerHasReachedEnd && _playerEnteredTime + 1 < Time.time)
        {
            print("koniec");
        }
    }

    void OnTriggerEnter(Collider playerCollider)
    {
        if (playerCollider.tag == "Player" && playerCollider.gameObject.GetComponent<PlayerRoute>().NumberOfFieldsToGo == 1 && gameObject.transform.parent.tag == "EndPathField")
        {
            _playerHasReachedEnd = true;
        }
    }


    public Field GetFieldObject
    {
        get
        {
            return FieldObj;
        }
    }

}
