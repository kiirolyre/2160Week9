using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    public GameManager gameManager;

    public float speed = 5.0f;
  
    float X = 8.25f; //the width of the default screen
    float Y = 4.5f; //the height of the default screen

    public float cooldownTimer;
    public float cooldown; //0.3

    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed * Time.deltaTime); //move according to the WASD keys

        Barrier();

        Shoot();
    }

    public void Shoot()
    {

        if (cooldownTimer <= 0) //ensure timer doesn't go too far
        {
            cooldownTimer = 0;
        }
        else
        {
            cooldownTimer -= Time.deltaTime; //counting down (to make sure bullets fire at an acceptable rate)
        }

        if (cooldownTimer == 0 && Input.GetAxisRaw("Shoot X") != 0 || cooldownTimer == 0 && Input.GetAxisRaw("Shoot Y") != 0) //while the arrow keys are pressed and the cooldown is done
        {
            
              GameObject bullet = Instantiate(Resources.Load("Bullet"), transform.position, Quaternion.identity) as GameObject; //spawns a bullet at the current location
              Vector2 vect = new Vector2(Input.GetAxisRaw("Shoot X"), Input.GetAxisRaw("Shoot Y"));
              bullet.GetComponent<Bullet>().vect = vect;
              cooldownTimer = cooldown; //resets timer

        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fragment" || other.tag == "Star")
        {
            FindObjectOfType<GameManager>().endGame();
            Destroy(gameObject);
        }

    }

    public void Barrier() //prevents planet from advancing past the camera boundraries
    {
        if (transform.position.x > X)
        {
            transform.position = new Vector3(X, transform.position.y, 0);
        }
        if (transform.position.x < -X) 
        {
        transform.position = new Vector3(-X, transform.position.y, 0);
        }

        if (transform.position.y > Y)
        {
            transform.position = new Vector3(transform.position.x, Y, 0);
        }
        if (transform.position.y < -Y)
        {
            transform.position = new Vector3(transform.position.x, -Y, 0);
        }
    }


}

       