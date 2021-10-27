using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] int _health = 100;
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _sightDistance = 5;
    [SerializeField] private float _chaseTime = 1;
    [SerializeField] AudioSource _audioDead;
    [SerializeField] ParticleSystem _particleSystem;
    private Transform _player;
    private bool _isPlayerInSight = false;
    private float _captureTime = 0;
    private Vector3 _enemyStartPos;

    private void Start()
    {        
        _player = PlayerSingleton.Instance.transform;
        _enemyStartPos = gameObject.transform.position;
        _enemyStartPos.Set(_enemyStartPos.x, 0, _enemyStartPos.z);
    }

    private void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, _player.position) < _sightDistance)
        {
            var direction = (_player.position - gameObject.transform.position).normalized * (_speed * Time.deltaTime);
            gameObject.transform.Translate(direction);
            _isPlayerInSight = true;
            _captureTime = Time.time;
        }
        else
        {
            if (_isPlayerInSight && Time.time > _captureTime + _chaseTime && 
                Mathf.Abs(gameObject.transform.position.x - _enemyStartPos.x) > 0.2f && 
                Mathf.Abs(gameObject.transform.position.z - _enemyStartPos.z) > 0.2f)
            {
                var direction = (_enemyStartPos - gameObject.transform.position).normalized * (_speed * Time.deltaTime);
                gameObject.transform.Translate(direction);
                _captureTime = 0;
            }
        }
    }
    public void Hurt(int damage)
    {
        Debug.Log($"Hurt - {damage}");
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        _audioDead.Play();
        _particleSystem.Play();
    }
}
