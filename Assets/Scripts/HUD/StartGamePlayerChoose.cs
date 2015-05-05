using UnityEngine;
using System.Collections;

public class StartGamePlayerChoose : MonoBehaviour {

    public Transform playerDetailsPanel;

    private bool _startRotation = false;
    private float _currentAngleRotation = 3;
    private float _currentStepRotation = 0;
    private Camera _characterChooseCamera;

    void Awake() {
        /** Usuwamy potencjalne obiekty przeniesione z levelu gry po powrocie **/
        if (GameObject.Find("Bear") != null && GameObject.Find("Bear").transform.parent == null)
            Destroy(GameObject.Find("Bear"));
        if (GameObject.Find("Hippo") != null && GameObject.Find("Hippo").transform.parent == null)
            Destroy(GameObject.Find("Hippo"));
        if (GameObject.Find("Frog") != null && GameObject.Find("Frog").transform.parent == null)
            Destroy(GameObject.Find("Frog"));
        if (GameObject.Find("Dog") != null && GameObject.Find("Dog").transform.parent == null)
            Destroy(GameObject.Find("Dog"));
        if (GameObject.Find("Tiger") != null && GameObject.Find("Tiger").transform.parent == null)
            Destroy(GameObject.Find("Tiger"));

        PlayerPrefs.SetInt("ResetGameBoard", 1);
    }

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

        Time.timeScale = 1;
    }

    void Update() {
        Ray ray = _characterChooseCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
            if (Physics.Raycast(ray, out hit))
            {
                foreach (Transform child in transform)
                    child.gameObject.SetActive(false);

                playerDetailsPanel.gameObject.SetActive(true);
                playerDetailsPanel.GetComponent<StartGamePlayerDetails>().CharacterSelected(hit.collider.name);
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

    public void Exit() {
        Application.Quit();
    }
}

