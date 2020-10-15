using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    public float speed = 1.5f;
    public float direction;

    public float minX, maxX;
    public float minY, maxY;

    public float cooldownTimer;
    public float cooldown;
    public int cMin, cMax; //1 - 3

    bool shotsFired;

    Vector3 velo;

    float X = 8.25f; 
    float Y = 4.5f;

    void Start()
    {
        velo = Vector2.up;
       // cooldown = Random.Range(cMin, cMax);
    }

    void Update()
    {
        transform.Translate(velo * speed * Time.deltaTime); //moves the star

        if (cooldownTimer <= 0) //ensure timer doesn't go too far
        {
            cooldownTimer = 0;
        }
        else
        {
            cooldownTimer -= Time.deltaTime; //counting down so the stars shoot a fragment at a random time
        }

        if (cooldown == 0 && shotsFired == false)
        {
            Shooting();
        }


        if (transform.position.x > X + 5|| transform.position.x < -X - 5|| transform.position.y > Y + 5|| transform.position.y < -Y - 5)
        {
            Destroy(gameObject);
        }
    }

    public void Shooting()
    {

            GameObject fragment = Instantiate(Resources.Load("Fragment"), gameObject.transform) as GameObject;
            fragment.transform.rotation = Quaternion.LookRotation(Vector3.forward, GameObject.FindWithTag("Planet").transform.position - transform.position);

            shotsFired = true;

    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Bullet")
        {
            GameObject alien = Instantiate(Resources.Load("Alien"), transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }

        if (other.tag == "Planet")
        {
            Destroy(gameObject);
        }

    }   
}
