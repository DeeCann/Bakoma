using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SignPostCam : MonoBehaviour {
    public Transform arrow;
    private List<Vector3> _endPaths = new List<Vector3>();
    private Vector3 _arrowDelta;

    void Start() {
        foreach (GameObject field in GameObject.FindGameObjectsWithTag("EndPathField"))
            _endPaths.Add(new Vector3(field.transform.position.x, 200, field.transform.position.z));

        _arrowDelta = arrow.transform.position - transform.position;
    }

    void Update() {
        arrow.transform.position = new Vector3(Game.GetCurrentPlayer.transform.position.x, arrow.position.y, Game.GetCurrentPlayer.transform.position.z);
       
        transform.position = arrow.transform.position - _arrowDelta;
        arrow.transform.LookAt(GetNearestEndPoint());
    }

    private Vector3 GetNearestEndPoint() {
        float latestDistance = 10000;
        Vector3 nearestPoint = Vector3.zero;

        foreach (Vector3 endField in _endPaths)
        {
            float distanceToCurrentPoint = Vector3.Distance(endField, arrow.position);
            if (latestDistance > distanceToCurrentPoint)
            {
                latestDistance = distanceToCurrentPoint;
                nearestPoint = endField;
            }

        }
        return nearestPoint;
    }
}
