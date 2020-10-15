using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Jump : MonoBehaviour
{

    public float speed;
    public float jumpSpeed; //5
    public float jumpHeight; //3
    private float gravity;
    public JumpState jumpState;




    // Start is called before the first frame update
    void Start()
    {
        jumpState = JumpState.OnGround;
        speed = 0;
        gravity = 3;
    //height should also be zero.
}

    // Update is called once per frame
    void Update()
    {

        switch (jumpState)
        {
            case JumpState.OnGround:

                speed = 0;

                if (Input.GetButtonDown("Jump")) //when the jump button is pressed
                {
                    jumpState = JumpState.Jumping;
                }

                break;


            case JumpState.Jumping:

                speed = jumpSpeed; // speed should be set to the jumpSpeed parameter value
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
                //  speed += gravity * Time.deltaTime;

                if (transform.position.y >= jumpHeight) //once it's high enough
                {
                    jumpState = JumpState.Falling;

                }

                break;


            case JumpState.Falling:

                speed += gravity * Time.deltaTime;
                transform.Translate(new Vector3(0, speed * -Time.deltaTime, 0));

                if (transform.position.y <= 0) //once it hits ground
                {
                    jumpState = JumpState.OnGround;
                }

                break;

        public void OnTriggerEnter2D(Collider2D other)
            {
                if (other.tag == "Spike")
                {
                    Destroy(gameObject);
                }
            }

           /* */ //do same thing but on another script and game object to despawn spikes

    public void OnTriggerEnter2D(Collider2D other)
            {
                if (other.tag == "Void")
                {
                    Destroy(gameObject);
                }
            }
/*
 //do same thing but on another script and game object to despawn spikes

    public void OnTriggerEnter2D(Collider2D other)
            {
                if (other.tag == "Void")
                {
                    Destroy(gameObject);
                }
            }

 */

        }







          
        




        }
     }




public enum JumpState {

    OnGround,
    Jumping,
    Falling
}

