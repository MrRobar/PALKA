using System;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PathNode _currentNode;

    private void Update()
    {
        if (_currentNode != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentNode.transform.position,
                _speed * Time.deltaTime);
            transform.LookAt(_currentNode.transform);
            if (transform.position == _currentNode.transform.position)
            {
                _currentNode = _currentNode.NextNode;
            }
        }
    }

    private void SetSpeed(float value)
    {
        _speed = value;
    }
}