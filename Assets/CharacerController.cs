using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacerController : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public  float Speed;
    public float JumpForce;
    public float JumpSpeedLimit;
    private bool isGrounded;
    public Animator Animator;
    public GameObject Player1;
    public GameObject Player2;
    private bool AnimationIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Starts Here
        float CurrSpeed = Speed * Input.GetAxis("Horizontal");

        Vector2 forward = new Vector2(CurrSpeed, 0);
        Rigidbody2D.velocity = forward;
        
        if (Input.GetButtonDown("Jump") == true && isGrounded == true)
        {
            Rigidbody2D.AddForce(Vector2.up*JumpForce);
            Rigidbody2D.velocity = new Vector2(CurrSpeed, Rigidbody2D.velocity.y);
        }
        //Block Logic
        if (Player1.transform.position.x - Player2.transform.position.x < 0)
        {
            if (Input.GetAxis("Horizontal") == -1)
            {
                Animator.SetBool("Block", true);
            }else{
                Animator.SetBool("Block", false);
                Animator.SetBool("StopBlock", true);
            }

        }else{
            if (Input.GetAxis("Horizontal") == 1)
            {
                Animator.SetBool("Block", true);
            }
            else
            {
                Animator.SetBool("Block", false);
                Animator.SetBool("StopBlock", true);
            }

        }

        //Animations Start Here
       /* Animation anim = Animator.GetCurrentAnimatorClipInfo(0)[0].clip;
        if (!anim.IsPlaying("Attack1") || !anim.IsPlaying("Attack2") || !anim.IsPlaying("Attack2"))
        {
            AnimationIsRunning = false;
        }*/
        if (Input.GetButtonDown("Fire1") == true && AnimationIsRunning == false)
        {
            Animator.SetBool("Attack1", true);
            //AnimationIsRunning = true;
        
        }
        if (Input.GetButtonDown("Fire2") == true)
        {
            Animator.SetBool("Attack2", true);

        }
        if (Input.GetButtonDown("Fire3") == true)
        {
            Animator.SetBool("Attack3", true);

        }
        if (Input.GetButtonDown("Horizontal") == true && isGrounded == true)
        {
            Animator.SetBool("Grounded", true);
            Animator.SetInteger("AnimState", 1);

        }
            Animator.SetInteger("AnimState", 0);

        
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
