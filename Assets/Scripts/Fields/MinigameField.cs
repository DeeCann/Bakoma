using UnityEngine;
using System.Collections;

public class MinigameField : MonoBehaviour
{
    public enum MiniGameName
    {
        Apple = 1,
        Blackberry = 2,
        Blueberry = 3,
        Peach = 4,
        Raspberry = 5,
        Strawberry = 6
    }

    public MiniGameName _minigameNames;
    private Field FieldObj;
    private bool _hasPlayerForMiniGame = false;
    private float _playerEnteredTime = 0;
    private AsyncOperation async;
    void Awake()
    {
        FieldObj = new Field();
        gameObject.GetComponent<FieldSocket>().MyFieldObject = FieldObj;
    }

    void Update()
    {
        if (_hasPlayerForMiniGame && _playerEnteredTime + 1 < Time.time)
        {
            async.allowSceneActivation = true;
            _hasPlayerForMiniGame = false;
        }
    }

    void OnTriggerEnter(Collider playerCollider)
    {
        if (playerCollider.tag == "Player")
        {
            if (playerCollider.gameObject.GetComponent<PlayerRoute>().NumberOfFieldsToGo == 1)
            {
                PlayerPrefs.SetInt("EnterdMiniGame", 1);
                PlayerPrefs.SetInt("Difficulty", 1);
                PlayerPrefs.SetString("MiniGameFruit", _minigameNames.ToString());
                GameObject.Find("GeneratedFruitsContainer").gameObject.SetActive(false);
                //GameObject.Find("Hippo").gameObject.SetActive(false);
                StartCoroutine("LoadGame");
                //Application.LoadLevel("Test");
                _hasPlayerForMiniGame = true;
                _playerEnteredTime = Time.time;
            }

        };
    }


    public Field GetFieldObject
    {
        get
        {
            return FieldObj;
        }
    }

    IEnumerator LoadGame()
    {
        PlayerPrefs.SetString("LoadLevelName", "Trampoliny");
        async = Application.LoadLevelAsync("Loader");
        async.allowSceneActivation = false;
        yield return async;
    }

}
