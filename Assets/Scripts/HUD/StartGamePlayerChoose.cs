using UnityEngine;
using System.Collections;

public class StartGamePlayerChoose : MonoBehaviour {

    private bool _startRotation = false;
    private float _currentAngleRotation = 3;
    private float _currentStepRotation = 0;
    private Camera _characterChooseCamera;

    void Start() {
        PlayerPrefs.SetInt("EnterdMiniGame", 0);
        PlayerPrefs.SetInt("StartFruitsAmountShowed", 0);

        _characterChooseCamera = GameObject.Find("CharacterChooseCamera").GetComponent<Camera>();

        float radiusX = 1.4f;
        float radiusZ = 1.4f;
        int numPoints = 5; 
    
        for (int pointNum = 0; pointNum < numPoints; pointNum++)
        {      
            float i = (pointNum * 1.0f) / numPoints;
            float angle = i * Mathf.PI * 2;
            float x = Mathf.Sin(angle) * radiusX;
            float z = Mathf.Cos(angle) * radiusZ;
            transform.GetChild(pointNum).transform.position = new Vector3(x, 0, z);
        }
    }

    void Update() {
        Ray ray = _characterChooseCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
            if (Physics.Raycast(ray, out hit))
            {
                switch(hit.collider.name) {
                    case "Frog": PlayerPrefs.SetInt("Character", 4); break;
                    case "Bear": PlayerPrefs.SetInt("Character", 3); break;
                    case "Dog": PlayerPrefs.SetInt("Character", 2); break;
                    case "Tiger": PlayerPrefs.SetInt("Character", 1); break;
                    case "Hippo": PlayerPrefs.SetInt("Character", 0); break;
                }
                PlayerPrefs.SetString("LoadLevelName", "Game_Board");
                Application.LoadLevel("Loader");
            }
    }

    void FixedUpdate() {
        if (_startRotation) {    
            foreach (Transform character in transform)
            {
                character.transform.RotateAround(Vector3.zero, Vector3.up, _currentAngleRotation);
                character.transform.LookAt(Vector3.forward * 100);
            }

            _currentStepRotation++;
            if (_currentStepRotation == 24)
                _startRotation = false;
        }
    }

    public void RotateRight() {
        if (!_startRotation)
        {
            _startRotation = true;
            _currentStepRotation = 0;
            _currentAngleRotation = -3;
        }
    }

    public void RotateLeft()
    {
        if (!_startRotation) {
            _startRotation = true;
            _currentStepRotation = 0;
            _currentAngleRotation = 3;
        }
    }
}

