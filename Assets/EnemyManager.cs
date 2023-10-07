using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    public Action<Color> Destroyed;
    public Action<Color> Created;
    private float _boardSize;

    private Color[] _colors;
    // Start is called before the first frame update
    void Start()
    {
        _colors = _gameManager.Colors;
        _boardSize = _gameManager.BoardSize;
    }

    // Update is called once per frame
    public Color ChangeColor()
    {
        return _colors[Random.Range(0, _colors.Length)];
    }
    
    public Vector3 ChangePosition()
    {
        return new Vector3(Random.Range(-_boardSize*5, _boardSize*5), 1,
            Random.Range(-_boardSize*5, _boardSize*5));
    }
}
