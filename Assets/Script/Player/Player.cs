using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(-.1f,0);
    public float speed;
    public float speedRun;
    public float forcejump = 20;
    
    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = 0.3f;
    private float _currentSpeed;
    public float normalScale = 1;
    
    [Header("Animation Player")]

    public string boolRun = "Run";
    public Animator animator;

   
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
        animator.speed = 2;
      } else {
        _currentSpeed = speed;
        animator.speed = 1;
      }
    
      if(Input.GetKey(KeyCode.LeftArrow))
        {
           myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
           myRigidbody.transform.localScale = new Vector3(-1,1,1)* normalScale;
           animator.SetBool(boolRun,true);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
           myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
           myRigidbody.transform.localScale = new Vector3(1,1,1)* normalScale;
           animator.SetBool(boolRun,true);
        }
        else
        {
           animator.SetBool(boolRun, false);
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

        myRigidbody.transform.localScale = Vector2.one * normalScale;
        
        DOTween.Kill(myRigidbody.transform);
        
        ScaleJump();
       }
    }

    private void ScaleJump()
    {
       myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo);
       //myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo);
    }
}
