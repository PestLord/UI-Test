using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private MenuElement _menuElement;
    [SerializeField] private Transform _parent;
    [SerializeField] private MenuElement _countElement;
    [SerializeField] private EnemyManager _enemyManager;
    private MenuElement[] _elements;
    private Dictionary<Color, int> _counts;
    private Dictionary<Color, MenuElement> _elementColor;
    private int _playerMovedCount = 0;

    private Color[] _colors;
    // Start is called before the first frame update
    void Start()
    {
        _counts = new Dictionary<Color, int>();
        _elementColor = new Dictionary<Color, MenuElement>();
        _colors = _gameManager.Colors;
        _elements = new MenuElement[_colors.Length];

        for (int i = 0; i < _colors.Length; i++)
        {
            Debug.Log("Create Color");
            Debug.Log(_colors.Length);
            
            _elements[i] = Instantiate(_menuElement, _parent);
            _elements[i].GetComponentInChildren<Image>().color = _colors[i];
            _elements[i].transform.position += new Vector3(i * 100, 0, 0);
            Debug.Log(_colors[i]);
            _elementColor.Add(_colors[i], _elements[i]);
            _counts.Add(_colors[i], 0);
        }

        PlayerController.Moved += PlayerMoved;
        _enemyManager.Created += EnemyCreated;
        _enemyManager.Destroyed += EnemyDestroyed;

        _countElement.transform.position += new Vector3(100 * _colors.Length, 0, 0);
    }

    private void PlayerMoved()
    {
        _playerMovedCount++;
        _countElement.GetComponentInChildren<TextMeshProUGUI>().text = _playerMovedCount.ToString();
    }

    private void EnemyDestroyed(Color color)
    {
        _counts[color]--;
        _elementColor[color].GetComponentInChildren<TextMeshProUGUI>().text = _counts[color].ToString();
    }

    private void EnemyCreated(Color color)
    {
        _counts[color]++;
        _elementColor[color].GetComponentInChildren<TextMeshProUGUI>().text = _counts[color].ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        PlayerController.Moved -= PlayerMoved;
        _enemyManager.Created -= EnemyCreated;
        _enemyManager.Destroyed -= EnemyDestroyed;
        
    }
}
