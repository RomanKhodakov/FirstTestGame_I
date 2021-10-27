using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] int _damage = 100;
    [SerializeField] int _speed = 2;
    [SerializeField] float _lifeTime = 2; //для самоуничтожения
    private Transform _player;
    private Vector3 _movement;
    float CutTime = 0;


    void Start()
    {
        _player = PlayerSingleton.Instance.transform;
        _movement = -_player.right.normalized * _speed;
        CutTime = Time.time;
    }
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<MyEnemy>();
            enemy.Hurt(_damage);
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        var speed = _movement * _speed * Time.deltaTime;
        gameObject.transform.Translate(speed);
        if (Time.time - CutTime > _lifeTime)
        {
            Destroy(gameObject); //самоуничтожение по истечении времени
        }
    }
}
