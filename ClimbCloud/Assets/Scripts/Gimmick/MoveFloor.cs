using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    [SerializeField, Header("°‚ª“®‚­‘¬‚³")]
    private float _moveSpeed;

    [SerializeField, Header("°‚ª“®‚­·‚ÌÅ‘å’l"), Range(0, 1)]
    private float _diffMax;


    private Vector2 _keepStartPosition;

    private int _direction = 1;


    public bool _isMoving;


    private void Start()
    {
        _keepStartPosition = transform.position;
    }

    private void Update()
    {
        if (!_isMoving) { return; }

        if (Mathf.Abs(transform.position.x - _keepStartPosition.x) > _diffMax)
        {

            _direction *= -1;
        }
        else if (Mathf.Abs(transform.position.x - _keepStartPosition.x) > _diffMax)
        {
            _direction *= -1;
            Debug.Log(_direction);
        }


        gameObject.transform.position += new Vector3(_moveSpeed * _direction * Time.deltaTime, 0, 0);


    }
}
