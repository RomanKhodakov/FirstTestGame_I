using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private float _period = 1;
    [SerializeField] private float _halfRange = 0;
    [SerializeField] private float _height = 3;

    private float _lastSpawn = 0;

    private void Update()
    {
        if (Time.time > _lastSpawn + _period)
        {
            _lastSpawn = Time.time;
            var enemy = _enemies[Random.Range(0, _enemies.Count)];
            var position = new Vector3(Random.Range(-_halfRange, _halfRange), _height, Random.Range(-_halfRange, _halfRange));
            Instantiate(enemy, position, Quaternion.identity);
        }
    }
}
