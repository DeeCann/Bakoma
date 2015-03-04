using UnityEngine;
using System.Collections;

public class PlayerBootstrap : MonoBehaviour {

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
}
