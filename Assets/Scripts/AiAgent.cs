using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAgent : MonoBehaviour
{
    //serializable field means that only unity can access the variable
    //private mean no one can access the variable
    //public means everyone can access the variable

    [SerializeField] private GameObject _player;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 5;
    [SerializeField] private int _waypointIndex = 0;
    public float chaseDistance = 5;

    private float minDis = 0.025f;

    public bool IsPlayerInRange()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < chaseDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Patrol()
    {
        Vector2 waypointPosition = _waypoints[_waypointIndex].position;

        MoveToPoint(_waypoints[_waypointIndex].position);

        if (Vector2.Distance(transform.position, waypointPosition) < 0.1f)
        {
            if (_waypointIndex >= _waypoints.Length)
            {
             _waypointIndex = 0;
            }
            _waypointIndex++;
        }        
    }

    public void ChasePlayer()
    {
        MoveToPoint(_player.transform.position);
    }

    public void MoveToPoint(Vector2 point)
    {
        Vector2 dirToPlayer = _player.transform.position - transform.position;

        if (dirToPlayer.magnitude > minDis)
        {
            dirToPlayer.Normalize();
            dirToPlayer *= _speed * Time.deltaTime;
            transform.position += (Vector3) dirToPlayer;
        }
    }  
}