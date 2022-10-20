using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private GameObject bulletPrefab;

    private void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var clickPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clickDir = clickPos - transform.position;

            //spawn a projetile in that click diretion
            Instantiate(bulletPrefab, transform.position, Quaternion.FromToRotation(Vector2.up, clickDir));
        }
    }
}