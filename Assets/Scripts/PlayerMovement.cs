using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    void Update()
    {
        //OldMovement();
        NewMovement();
    }

    void NewMovement()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(xAxis, yAxis);

        move.Normalize();
        move *= speed * Time.deltaTime;

        transform.position += (Vector3) move;
    }

    void OldMovement()
    {
        #region Get Key Movement Checks
        //move up?
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 newPos = transform.position;
            newPos.y += speed*Time.deltaTime;
            newPos.Normalize();
            transform.position = newPos;
        }
        
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 newPos = transform.position;
            newPos.y -= speed*Time.deltaTime;
            newPos.Normalize();
            transform.position = newPos;
        }
        
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 newPos = transform.position;
            newPos.x -= speed*Time.deltaTime; ;
            transform.position = newPos;
        }
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 newPos = transform.position;
            newPos.x += speed*Time.deltaTime;
            newPos.Normalize();
            transform.position = newPos;
        }

        #endregion
    }
}