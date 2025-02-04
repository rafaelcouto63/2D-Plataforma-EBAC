using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public HealthBase _healthBase;

   [Header("Player Setup")]
    public SOPlayerSetup soPlayerSetup;
    private float _currentSpeed;
    private float normalScale = 1;
    private Animator _currentPlayer;

   [Header("Jump Collision Setup")]
   public Collider2D collider2D;
   public float distToGround;
   public float spaceToGround;
   public ParticleSystem jumpVFX;


    /*[Header("Speed Setup")]
    public Vector2 friction = new Vector2(-.1f,0);
    public float speed;
    public float speedRun;
    public float forcejump = 20;
    
    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = 0.3f;
    public SOfloat jumpScaleY;
    public SOfloat jumpScaleX;
    public SOfloat animationDuration;
    
    [Header("Animation Player")]

    public string boolRun = "Run";
    public Animator animator;
    public string triggerDeath = "Death";*/


    private void Awake()
    {
      if(_healthBase != null) 
      {
        _healthBase.OnKill += OnPlayerKill;
      }

      _currentPlayer = Instantiate(soPlayerSetup.player,transform);
    }

    private bool IsGrounded()
    {
      Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, distToGround + spaceToGround);
      return Physics2D.Raycast(transform.position,-Vector2.up, distToGround + spaceToGround);
    }

    private void OnPlayerKill()
    {
       _healthBase.OnKill -= OnPlayerKill;
       _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);
    }

    private void Update()
    {
        IsGrounded();
        Movement();
        Jump();
    }

    private void Movement()
    {
      if(Input.GetKey(KeyCode.LeftShift))
      {
        _currentSpeed = soPlayerSetup.speedRun;
        _currentPlayer.speed = 2;
      } else {
        _currentSpeed = soPlayerSetup.speed;
        _currentPlayer.speed = 1;
      }
    
      if(Input.GetKey(KeyCode.LeftArrow))
        {
           myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
           myRigidbody.transform.localScale = new Vector3(-1,1,1)* normalScale;
           _currentPlayer.SetBool(soPlayerSetup.boolRun,true);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
           myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
           myRigidbody.transform.localScale = new Vector3(1,1,1)* normalScale;
           _currentPlayer.SetBool(soPlayerSetup.boolRun,true);
        }
        else
        {
           _currentPlayer.SetBool(soPlayerSetup.boolRun, false);
        }

        if(myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += soPlayerSetup.friction;
        }

        if(myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= soPlayerSetup.friction;
        }
    }

    private void Jump()
    {
       if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
       {
        myRigidbody.velocity = Vector2.up * soPlayerSetup.forcejump;

        //myRigidbody.transform.localScale = Vector2.one * normalScale;
        
        DOTween.Kill(myRigidbody.transform);
        
        ScaleJump();
        JumpVFX();
       }
    }

    private void JumpVFX()
    {
       if(jumpVFX != null) 
       {
         jumpVFX.Play();
       }
    }

    private void ScaleJump()
    {
       myRigidbody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo);
       if(myRigidbody.transform.localScale.x < 0) {
        myRigidbody.transform.DOScaleX(-soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo);
       } else {
       myRigidbody.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo); 
       }
    }
}
