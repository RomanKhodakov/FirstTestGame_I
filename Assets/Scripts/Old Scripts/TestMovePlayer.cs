using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovePlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _speed = 400;
    float tdelay = 0;


    private Vector3 _movement;

    private void Update()
    {
        _movement.z = Input.GetAxis("Horizontal");
        _movement.x = -Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - tdelay > 1) //прыжок раз в секунду
            {
                _rigidbody.velocity = new Vector3(0, 6, 0);
                tdelay = Time.time;
            }
        }

    }

    private void FixedUpdate()
    {
        if (_rigidbody == null)
            return;

        if (_movement.magnitude < 0.01f)
        {
            return;
        }         
        _rigidbody.transform.right = -_movement.normalized;

        var velocity = _movement * (_speed * Time.deltaTime);

        _rigidbody.velocity = velocity;

    }

}
