using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment : MonoBehaviour
{

    float X = 8.25f;
    float Y = 4.5f;

    public float speed = 1.5f;
    Vector2 velo;

    public float cooldownTimer;
    public float cooldown; //0.3

    void Start()
    {
        velo = Vector2.up;
    }

    void Update()
    {

        transform.Translate(velo * speed * Time.deltaTime);

        if (transform.position.x > X || transform.position.x < -X || transform.position.y > Y || transform.position.y < -Y)
        {
            Destroy(gameObject);
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Planet")
        {
            Destroy(gameObject);
        }

    }
}
