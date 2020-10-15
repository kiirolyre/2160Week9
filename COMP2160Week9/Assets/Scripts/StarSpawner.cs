using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    float X = 8.25f;
    float Y = 4.5f;

    private float speed; //2.5

    public float cooldownTimer;
    public float cooldown; 
    public int cMin, cMax; //4 - 10

    public int loc;
    public int rMin, rMax; //0

    float spawnX = 9.25f;
    float spawnY = 5.5f;

    //public float spawnRate; 

    void Update()
    {
        Spawner();

        if (transform.position.x > X + 10 || transform.position.x < -X - 10 || transform.position.y > Y + 10 || transform.position.y < -Y - 10)
        {
            Destroy(gameObject);
        }
    }

    public void Spawner()
    {

        if (cooldownTimer <= 0) //ensure timer doesn't go too far
        {
            cooldownTimer = 0;
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (cooldownTimer == 0)
        {
            Vector2 location = SpawnLocation();
            GameObject star = Instantiate(Resources.Load("Star"), location, Quaternion.identity) as GameObject;
            star.transform.rotation = Quaternion.LookRotation(Vector3.forward, new Vector3(-location.x, -location.y, 0) - transform.position);

            cooldownTimer = cooldown;
            
          //  if(cooldown >= 0.5)
          //  {
          //      cooldown -= 0.2f;
          //  }

        }
    }

    

    public Vector2 SpawnLocation()
    {
        Vector2 vect = Vector2.zero;

        loc = Random.Range(rMin, rMax);


        switch (loc) //randomly choosing which side to spawn on
        {
            case 0:
                vect.y = spawnY;
                break;

            case 1:
                vect.x = spawnX;
                break;

            case 2:
                vect.y = -spawnY;
                break;

            case 3:
                vect.x = -spawnX;
                break;
        }

        if (vect.y != 0)
        {
            vect.x = Random.Range(-spawnX, spawnX); 
        }
        else
        {
            vect.y = Random.Range(-spawnY, spawnY); 
        }


        return vect;

        
    }


}
   
    
