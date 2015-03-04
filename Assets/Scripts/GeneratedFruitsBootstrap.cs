using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneratedFruitsBootstrap : MonoBehaviour {

    private bool created = false;
    private List<Transform> _tiles = new List<Transform>();
    private static string[] _onBoardFruitsNames = new string[] { "Apple", "Blackberry", "Blueberry", "Peach", "Raspberry", "Strawberry" };

    private Transform _tilesContainer;
    private Transform _fruitsContainer;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
        } else
            Destroy(gameObject);

        _tilesContainer = GameObject.FindGameObjectWithTag("Tiles").transform.FindChild("t1");
        _fruitsContainer = gameObject.transform;

        if (PlayerPrefs.GetInt("EnterdMiniGame") == 0)
            GenerateOnBoardFruits();
        if (!_fruitsContainer.gameObject.activeSelf)
            _fruitsContainer.gameObject.SetActive(true);
    }

    private void GenerateOnBoardFruits()
    {
        foreach (Transform tile in _tilesContainer)
        {
            _tiles.Add(tile);
        }

        for (int i = 0; i < _onBoardFruitsNames.Length - 1; i++)
        {
            for (int j = 0; j <= 30; j++)
            {
                int randomTileNumber = 0;
                bool tileIsNotStartField = true;
                while (tileIsNotStartField)
                {
                    randomTileNumber = Random.Range(0, _tiles.Count - 1);
                    if (_tiles[randomTileNumber].tag != "StartPathField")
                        tileIsNotStartField = false;
                }

                Vector3 fruitPosition = _tiles[randomTileNumber].transform.position;
                fruitPosition.y = fruitPosition.y + 0.1f;
                GameObject fruit = (GameObject)Instantiate(Resources.Load("Prefabs/" + _onBoardFruitsNames[i]), fruitPosition, Quaternion.identity);

                fruit.name = _onBoardFruitsNames[i];
                fruit.transform.parent = _fruitsContainer;

                _tiles.Remove(_tiles[randomTileNumber]);
            }
        }
    }
}
