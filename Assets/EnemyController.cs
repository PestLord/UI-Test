using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Action<Color> Destroyed;
    
    private GameManager _manager;
    private Color _currentColor;
    // Start is called before the first frame update
    void Start()
    {
        _manager = FindObjectOfType<GameManager>();
        Rebuild();
    }
    
    void Rebuild()
    {
        _currentColor = _manager.ChangeColor();
        GetComponent<Renderer>().material.color = _currentColor;
        transform.position = _manager.ChangePosition();
        Debug.Log(transform.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Renderer>().material.color == _currentColor && other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
