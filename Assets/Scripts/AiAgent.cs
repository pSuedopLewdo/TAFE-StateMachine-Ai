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

    private float minDis = 0.025f;
    private float chaseDis = 3f;

    public bool IsPlayerInRange()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < chaseDis)
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
        MoveToPoint(waypointPosition);
        if(Vector2.Distance(transform.position, waypointPosition) < minDis )
        {
            //_waypointIndex = (_waypointIndex+1) % _waypoints.Length;
            _waypointIndex++;
        }
        if(_waypointIndex >= _waypoints.Length)
        {
            _waypointIndex = 0;
        }       
    }

    public void ChasePlayer()
    {
        
        MoveToPoint(_player.transform.position);
    }

    public void MoveToPoint(Vector2 point)
    {
        Vector2 dirToPlayer = point - (Vector2)transform.position;

        if (dirToPlayer.magnitude > minDis)
        {
            dirToPlayer.Normalize();
            dirToPlayer *= _speed * Time.deltaTime;
            transform.position += (Vector3) dirToPlayer;
        }
    }

    public void Search()
    {
        //stores closest waypoint
        //-1 common way to have a null in an index
        int closestIndex = -1;
        float closestDistance = float.MaxValue;
        
        //loop for everyway point
        for (int index = 0; index < _waypoints.Length; index++)
        { 
            float currentDistance = Vector2.Distance(_waypoints[index].position, transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestIndex = index;
            }
        }
        
        _waypointIndex = closestIndex;

        //if distance to x < prev closest waypoint

        //the new waypoint id the closest
        //waypointindex == closest index;

        //searches the Waypoint Index for the closest waypoint to the Ai

        /*
        float index = 0;
        while (index < _waypoints.Length)
        {
            index++;
        }
        */

    }
}
