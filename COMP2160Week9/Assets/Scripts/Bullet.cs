using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4f;
    public Vector2 vect;

    float X = 10.25f;
    float Y = 6.5f;

    void Update()
    {

        transform.Translate(vect * speed * Time.deltaTime); //allows the bullet to move (path already determined by planet.cs)

        if (transform.position.x > X || transform.position.x < -X || transform.position.y > Y || transform.position.y < -Y)
        {
            Destroy(gameObject); //destroys upon exiting the camera boundrary
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Star")
        {
            Destroy(gameObject);
       }

    }

}





