using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshMove : MonoBehaviour
{
    [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;
    [SerializeField] private Transform _target;
    void Update()
    {
        _agent.SetDestination(_target.position);
    }

}
