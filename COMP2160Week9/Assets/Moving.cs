using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{

    public int speed; //5
    public int min, max;
    private float timer;

    private Vector3 scaleChange;


    // Start is called before the first frame update
    void Start()
    {
          float randNum = Random.Range(-0.5f, 0.75f); ;

          scaleChange = new Vector3(randNum, randNum, 0);

          transform.localScale += scaleChange;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector3(speed * -Time.deltaTime, 0, 0)); //moving left

    }

}
