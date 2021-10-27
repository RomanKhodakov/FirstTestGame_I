using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMine : MonoBehaviour
{
    [SerializeField] GameObject _rootGameObject;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 MinePos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            Instantiate(_rootGameObject, MinePos, Quaternion.identity);
        }
    }
}
