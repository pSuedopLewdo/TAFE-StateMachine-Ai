using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AiAgent : MonoBehaviour
{
    //serializable field means that only unity can access the variable
    //private mean no one can access the variable
    //public means everyone can access the variable

    [SerializeField] private GameObject player;
    public float speed = 5;
    
    private float minDis = 0.025f;
    private float killDis = 0.9f;

    void Update()
    {
        Vector2 dirToPlayer = player.transform.position - transform.position;

        if (dirToPlayer.magnitude > minDis)
        {
            dirToPlayer.Normalize();
            dirToPlayer *= speed * Time.deltaTime;
            transform.position += (Vector3) dirToPlayer;
        }

        if (dirToPlayer.magnitude < killDis)
        {
            SceneManager.LoadScene(0);
        }
    }
}