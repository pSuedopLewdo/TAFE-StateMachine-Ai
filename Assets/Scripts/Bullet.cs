using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    private float bulletDestroyTime = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySelf(bulletDestroyTime));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = transform.up;
        Vector2 pos = transform.position;

        dir = dir.normalized * speed * Time.deltaTime;
        transform.position = pos + dir;
    }

    IEnumerator DestroySelf(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameObject.Destroy(gameObject);
    }
}
