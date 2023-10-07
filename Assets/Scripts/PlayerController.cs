using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Action Moved;
    private Rigidbody _rigidbody;
    private Vector3 vector3;
    private Vector3 _playerPosition;
    private Vector3 _startPosition;

    [SerializeField] private float _forceMultiplicator;
    [SerializeField] private float _maxForce;

    private Vector3 hitPos;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Moved?.Invoke();
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                _rigidbody.velocity = Vector3.zero;
                Debug.Log(hit.point);
                _playerPosition = GetComponent<Transform>().localPosition;
                hitPos = hit.transform.position;
                vector3 = hit.point - _playerPosition;
                //var distance = Mathf.Sqrt(Mathf.Pow(vector3.x, 2) + Mathf.Pow(vector3.z, 2));
                //var minimum = Mathf.Min(distance * _forceMultiplicator, _maxForce);
                _rigidbody.AddForce(new Vector3( vector3.normalized.x,0,vector3.normalized.z) * _maxForce);
            }
        }
    }
    
    public void MoveToStartPoint()
    {
        // Переносим игрока на стартовую точку.
        transform.position = _startPosition;

        // Зануляем ему скорость.
        _rigidbody.velocity = Vector3.zero;
    }
}
