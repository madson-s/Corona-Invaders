using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spawn;
    private Rigidbody2D rigidbody;
    public float reloadTime = 1f;
    public float speed;
    private bool reloading = false;
    private float time;
    private float direction;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (direction != 0)
            Move(direction);

        if (reloading)
            Reload();
        else
            Shoot();
    }

    public void Move(float direction)
    {
        if (transform.position.x < -11)
            transform.position = new Vector3(-11,  transform.position.y, transform.position.z);
        else if (transform.position.x > 11)
            transform.position = new Vector3( 11, transform.position.y, transform.position.z);

        rigidbody.MovePosition(transform.position + new Vector3(direction * speed, 0, 0) * Time.fixedDeltaTime);
    }

    public void Reload()
    {
        time -= Time.deltaTime;
        if (time < 0)
            reloading = false;
    }
    public void Shoot()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(bullet, spawn.transform.position, Quaternion.identity);
            reloading = true;
            time = reloadTime;
        }
    }
}
