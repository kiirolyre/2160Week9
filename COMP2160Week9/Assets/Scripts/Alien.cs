using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alien : MonoBehaviour
{

    public float alienTimer; //5

    void Update()
    {

        alienTimer -= Time.deltaTime;

        if (alienTimer <= 0) //after some time, the alien despawns
        {
            Destroy(gameObject);
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Planet")
        {
            Counter.counter += 10; //adds points to the point counter script

            Destroy(gameObject); 
        }
    }



}
