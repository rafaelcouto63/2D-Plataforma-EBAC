using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Vector2 friction = new Vector2(-.1f,0);
    public float speed;
    public float speedRun;
    public float forcejump = 20;

    private float _currentSpeed;
   
    private void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
      if(Input.GetKey(KeyCode.LeftShift))
      {
        _currentSpeed = speedRun;
      } else {
        _currentSpeed = speed;
      }
    
      if(Input.GetKey(KeyCode.LeftArrow))
        {
           myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
           myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
        }

        if(myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += friction;
        }

        if(myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= friction;
        }
    }

    private void Jump()
    {
       if(Input.GetKeyDown(KeyCode.Space))
       {
        myRigidbody.velocity = Vector2.up * forcejump;
       }
    }
}
