using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spawn;
    public GameObject enemies;
    public float speed;
    public LayerMask layerMask;
    public float reloadTime = 1f;

    private float downCount = 5;
    private float downTime;
    private float time;
    private bool reloading = false;
    

    private void Start()
    {
        speed = 2f;
        time = reloadTime;
        downTime = downCount;
    }
    void Update()
    {
        time -= Time.deltaTime;
        downTime -= Time.deltaTime;

        if(downTime < 0)
        {
            enemies.transform.Translate(Vector3.down);
            downTime = downCount;
        }

        if (time < 0)
            reloading = false;

        if (!reloading)
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 100, layerMask);
            if(ray.transform == null)
            {
                Instantiate(bullet, spawn.transform.position, Quaternion.identity);
                reloading = true;
                time = reloadTime;
            }
            
        }

        transform.Translate(GameManager.instance.enimiesDirection * speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int enemiesDirection = GameManager.instance.enimiesDirection;

        if (collision.gameObject.tag == "Border Right")
            enemiesDirection = -1;
        else if (collision.gameObject.tag == "Border Left")
            enemiesDirection = 1;

        GameManager.instance.enimiesDirection = enemiesDirection;

    }
}
