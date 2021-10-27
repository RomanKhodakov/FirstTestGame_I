using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform _player;
    private Vector3 _setup;

    private void Start()
    {
        _player = PlayerSingleton.Instance.transform;
        _setup.Set(7, 7, 0);
    }

    private void Update()
    {
        gameObject.transform.position = _player.transform.position + _setup;
    }
}
