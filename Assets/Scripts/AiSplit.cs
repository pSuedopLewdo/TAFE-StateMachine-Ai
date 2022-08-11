using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSplit : MonoBehaviour
{
    [SerializeField] private float shrinkPercent = 0.5f;
    [SerializeField] private float smallestSize = 0.25f;
    public Bullet splitByBullet = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        
        //if it is a bullet or if it is not nothing
        if (bullet != null)
        {
            if (bullet == splitByBullet) return;
            
            transform.localScale *= shrinkPercent;
            if (transform.localScale.x < smallestSize)
            {
                Destroy(gameObject);
                return;
            }
            splitByBullet = bullet;
            Instantiate(gameObject);
        }
    }
}
