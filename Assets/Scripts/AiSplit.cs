using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSplit : MonoBehaviour
{
    public bool beenHit = false;
    [SerializeField] private float shrinkPercent = 0.95f;
    [SerializeField] private float smallestSize = 0.25f;
    public Bullet splitByBullet = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        
        //if it is a bullet or if it is not nothing
        if (bullet != null)
        {
            if (bullet == splitByBullet)
            {
                //beenHit = true;
                return;
            }

            beenHit = true;
            transform.localScale *= shrinkPercent;
            Destroy(bullet.gameObject);
        }
    }
}
