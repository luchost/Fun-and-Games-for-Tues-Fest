using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlle2 : MonoBehaviour
{

    public Rigidbody2D Rigidbody2D;
    public float Speed;
    public float JumpForce;
    private bool isGrounded;
    public Animator Animator;
    public GameObject Player1;
    public GameObject Player2;
    private bool AnimationIsRunning = false;
    public GameObject HurtBoxOverHead;
    public GameObject HurtBoxMedium;
    public GameObject HurtBoxLow;
    public bool Blocking;
    public int Health;
    private bool OnRight;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Blocking = false;
        OnRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Starts Here
        float CurrSpeed = Speed * Input.GetAxis("Horizontal2");

        Vector2 forward = new Vector2(CurrSpeed, 0);
        Rigidbody2D.velocity = forward;

        if (Input.GetButtonDown("Jump") == true && isGrounded == true)
        {
            Rigidbody2D.AddForce(Vector2.up * JumpForce);
            Rigidbody2D.velocity = new Vector2(CurrSpeed, Rigidbody2D.velocity.y);
        }
        //Block Logic
        if (Player1.transform.position.x - Player2.transform.position.x < 0)
        {
            if (OnRight == true)
            {
                this.transform.rotation = Quaternion.Euler(0, 180f, 0);
                OnRight = false;
            }
            if (Input.GetAxis("Horizontal2") == -1)
            {
                Animator.SetBool("Block", true);
                Blocking = true;
            }
            else
            {
                Animator.SetBool("Block", false);
                Animator.SetBool("StopBlock", true);
                Blocking = false;
            }

        }
        else
        {
            if (OnRight == false)
            {
                this.transform.rotation = Quaternion.Euler(0, 180f, 0);
                OnRight = true;
            }
            if (Input.GetAxis("Horizontal2") == 1)
            {
                Animator.SetBool("Block", true);
                Blocking = true;
            }
            else
            {
                Animator.SetBool("Block", false);
                Animator.SetBool("StopBlock", true);
                Blocking = false;
            }

        }
        //Animations Start Here

        /* Animation anim = Animator.GetCurrentAnimatorClipInfo(0)[0].clip;
        if (!anim.IsPlaying("Attack1") || !anim.IsPlaying("Attack2") || !anim.IsPlaying("Attack2"))
        {
            AnimationIsRunning = false;
        }*/
        if (Input.GetButtonDown("Fire4") == true && AnimationIsRunning == false)
        {
            Animator.SetBool("Attack1", true);
            //AnimationIsRunning = true;
            HurtBoxLogic(1);
        }
        if (Input.GetButtonDown("Fire5") == true)
        {
            Animator.SetBool("Attack2", true);
            HurtBoxLogic(2);

        }
        if (Input.GetButtonDown("Fire6") == true)
        {
            Animator.SetBool("Attack3", true);
            HurtBoxLogic(3);

        }
        if (Input.GetButtonDown("Horizontal2") == true && isGrounded == true)
        {
            Animator.SetBool("Grounded", true);
            Animator.SetInteger("AnimState", 1);

        }
        Animator.SetInteger("AnimState", 0);


    }

    IEnumerator WaitAndStartHurtBox(GameObject HurtBox)
    {
        yield return new WaitForSeconds(.1f);
        HurtBoxStart(HurtBox);
        yield return new WaitForSeconds(.2f);
        HurtBoxStop(HurtBox);
    }

    void HurtBoxLogic(int attackIndex)
    {
        if (attackIndex == 1 || attackIndex == 3)
        {
            StartCoroutine(WaitAndStartHurtBox(HurtBoxOverHead));
            StartCoroutine(WaitAndStartHurtBox(HurtBoxMedium));
            StartCoroutine(WaitAndStartHurtBox(HurtBoxLow));
        }
        else if (attackIndex == 2)
        {
            StartCoroutine(WaitAndStartHurtBox(HurtBoxMedium));
        }
    }
    void HurtBoxStart(GameObject HurtBox)
    {
        HurtBox.SetActive(true);
    }
    void HurtBoxStop(GameObject HurtBox)
    {
        HurtBox.SetActive(false);
    }
    public void BlockAttack(int Damage)
    {
        Health -= Damage / 10;
    }
    public void AttackHit(int Damage)
    {
        Health -= Damage;
        Player2.GetComponent<Rigidbody2D>().AddForce(new Vector2(3, 10));
        Debug.Log(Health);
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
