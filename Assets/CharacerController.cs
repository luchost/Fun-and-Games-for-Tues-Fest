using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacerController : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public  float Speed;
    public float JumpForce;
    private bool isGrounded;
    public Animator Animator;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Soldier;
    public GameObject Soldier2;
    private bool AnimationIsRunning = false;
    public GameObject HurtBoxOverHead;
    public GameObject HurtBoxMedium;
    public GameObject HurtBoxLow;
    public bool Blocking  ;
    public int Health;
    private bool OnRight;
    public GameObject Player1Lose;
    public bool Attack1;
    public bool Attack2;
    public bool Attack3;
    public bool Special1;
    public bool Special2;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Blocking = false;
        OnRight = false;
        Attack1 = true;
        Attack2 = true;
        Attack3 = true;
        Special1 = true;
        Special2 = true;
    }

    // Update is called once per frame
    void Update()
    {    // Check if Dead Here
        if (Health <= 0)
        {
            Player1.GetComponent<CharacerController>().enabled = false;
            Player2.GetComponent<CharacterControlle2>().enabled = false;
            Player1Lose.SetActive(true);
        
        }
        //Movement Starts Here
        float CurrSpeed = Speed * Input.GetAxis("Horizontal");

        Vector2 forward = new Vector2(CurrSpeed, 0);
        Rigidbody2D.velocity = forward;

        if (Input.GetButtonDown("Jump") == true && isGrounded == true)
        {
            //StartCoroutine(JumpingLogic(JumpForce, Rigidbody2D));
        }
    
        //Block Logic
        if (Player1.transform.position.x - Player2.transform.position.x < 0)
        {
            if (OnRight == true)
            {
                this.transform.rotation = Quaternion.Euler(0, 180f, 0);
                OnRight = false;
            }
            if (Input.GetAxis("Horizontal") == -1)
            {
                Animator.SetBool("Block", true);
                Blocking = true;
            }else{
                Animator.SetBool("Block", false);
                Animator.SetBool("StopBlock", true);
                Blocking = false;
            }

        }else{
            if(OnRight == false)
            {
                this.transform.rotation = Quaternion.Euler(0, 180f, 0);
                OnRight = true;
            }
            if (Input.GetAxis("Horizontal") == 1)
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
        if (Input.GetButtonDown("Fire1") == true && Attack1 == true)
        {
            Animator.SetBool("Attack1", true);
            //AnimationIsRunning = true;
            HurtBoxLogic(1);
            Attack1 = false;
            StartCoroutine(Attack1Reset());
        }
        if (Input.GetButtonDown("Fire2") == true && Attack2 == true)
        {
            Animator.SetBool("Attack2", true);
            HurtBoxLogic(2);
            Attack2 = false;
            StartCoroutine(Attack2Reset());

        }
        if (Input.GetButtonDown("Fire3") == true && Attack3 == true)
        {
            Animator.SetBool("Attack3", true);
            HurtBoxLogic(3);
            Attack3 = false;
            StartCoroutine(Attack3Reset());
        }
        if (Input.GetButtonDown("Horizontal") == true && isGrounded == true)
        {
            Animator.SetBool("Grounded", true);
            Animator.SetInteger("AnimState", 1);

        }
            Animator.SetInteger("AnimState", 0);
       
        if (Input.GetButtonDown("Special2") == true && Input.GetAxis("Horizontal") == 1 && Special2 == true)
        {
            Transform pos = Player1.GetComponent<Transform>();
            GameObject SoldierNow = Instantiate(Soldier2, pos.position, Quaternion.identity);
            SoldierNow.GetComponent<Transform>().GetChild(0).GetComponent<AttackLogic2>().characterControlle2 = Player2.GetComponent<CharacterControlle2>();
            SoldierNow.GetComponent<Transform>().GetChild(0).GetComponent<AttackLogic2>().combo = Player2.GetComponent<ComboManager2>();
            Special2 = false;
            StartCoroutine(Special2Reset());
        }
        else if (Input.GetButtonDown("Special2") == true && Special1 == true)
        {
            Transform pos = Player1.GetComponent<Transform>();
            GameObject SoldierNow = Instantiate(Soldier, pos.position, Quaternion.identity);
            SoldierNow.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180f, 0);
            SoldierNow.GetComponent<Transform>().GetChild(0).GetComponent<AttackLogic2>().characterControlle2 = Player2.GetComponent<CharacterControlle2>();
            SoldierNow.GetComponent<Transform>().GetChild(0).GetComponent<AttackLogic2>().combo = Player2.GetComponent<ComboManager2>();
            Special1 = false;
            StartCoroutine(Special1Reset());
        }



    }
    IEnumerator Attack1Reset() 
    {
        yield return new WaitForSeconds(.5f);
            Attack1 = true;
    
    }
    IEnumerator Attack2Reset()
    {
        yield return new WaitForSeconds(.5f);
            Attack2 = true;

    }
    IEnumerator Attack3Reset()
    {
        yield return new WaitForSeconds(.5f);
            Attack3 = true;

    }
    IEnumerator Special1Reset()
    {
        yield return new WaitForSeconds(4f);
            Special1 = true;

    }
    IEnumerator Special2Reset()
    {
        yield return new WaitForSeconds(4f);
            Special2 = true;

    }


    IEnumerator WaitAndStartHurtBox(GameObject HurtBox) 
    {
        yield return new WaitForSeconds(.1f);
        HurtBoxStart(HurtBox);
        yield return new WaitForSeconds(.2f);
        HurtBoxStop(HurtBox);
    }
    IEnumerator JumpingLogic(float JumpForce, Rigidbody2D me)
    {
        for (int i = 0; i < 10; i++)
        {
            me.AddForce(new Vector2(0, JumpForce / 10f));
            yield return new WaitForSeconds(.03f);
        }

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
        Rigidbody2D.AddForce(new Vector2(60, 250));
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
