using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{

    public static int counter = 0;
    Text aliens;

    void Start()
    {
        aliens = GetComponent<Text>(); //getting the component text is attatched to 
    }

    void Update()
    {
        aliens.text = "Aliens: " + counter; //sets the point counter text
    }
}
