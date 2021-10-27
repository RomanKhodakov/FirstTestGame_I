using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 5; 
    private Vector3 _movement;
    private readonly Vector3 _jump = new Vector3(0, 8, 0);

    float tdelay = 0;
    private void Update()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.z = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - tdelay > 1)
            {
                _rigidbody.velocity = _jump;
                tdelay = Time.time;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_rigidbody == null)
            return;

        if (_movement.magnitude < 0.01f)
            return;

        _rigidbody.transform.forward = _movement.normalized;

        var translate = Vector3.left * (_speed * Time.deltaTime);

        _rigidbody.transform.Translate(translate);

    }
}
