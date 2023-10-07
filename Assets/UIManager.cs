using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private MenuElement _menuElement;
    [SerializeField] private Transform _parent;
    [SerializeField] private MenuElement _countElement;
    private MenuElement[] _elements;

    private Color[] _colors;
    // Start is called before the first frame update
    void Start()
    {
        _colors = _gameManager.Colors;
        _elements = new MenuElement[_colors.Length];
        for (int i = 0; i < _colors.Length; i++)
        {
            Debug.Log("Create Color");
            Debug.Log(_colors.Length);
            
            _elements[i] = Instantiate(_menuElement, _parent);
            _elements[i].GetComponentInChildren<Image>().color = _colors[i];
            _elements[i].transform.position += new Vector3(i * 100, 0, 0);
        }

        _countElement.transform.position += new Vector3(100 * _colors.Length, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
