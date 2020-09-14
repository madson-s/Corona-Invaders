using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            GameManager.instance.LossLife(1);

        if (collision.gameObject.tag == "Enemy")
            GameManager.instance.AddScore(10);

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
