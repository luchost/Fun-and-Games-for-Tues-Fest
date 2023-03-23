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

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
        float CurrSpeed = Speed * Input.GetAxis("Horizontal");

        Vector2 forward = new Vector2(CurrSpeed, 0);
        Rigidbody2D.velocity = forward;
        
        if (Input.GetButtonDown("Jump") == true && isGrounded == true)
        {
            Vector2 up = new Vector2(0, 10);
            Rigidbody2D.AddForce(up) ;
        }
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
