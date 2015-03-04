using UnityEngine;
using System.Collections;

public class FieldsBootstrap : MonoBehaviour {

    private bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
        }
        else
            Destroy(gameObject);

        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            gameObject.SetActive(false);
    }
}
