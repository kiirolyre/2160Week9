using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{


    public int min, max;
    private float timer;

    void Start()
    {
        timer = Random.Range(min, max);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0){
            Instantiate(Resources.Load("Spike"), gameObject.transform);
            timer = Random.Range(min, max);
        }
    }
}
