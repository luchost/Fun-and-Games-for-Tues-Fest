using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public  float Speed = 10f ;
    public float JumpForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
            {
                float CurrSpeed = Speed * Input.GetAxis("Horizontal");
                rigidbody2D.velocity = new Vector2(Speed , 0);        
            }
        if (Input.GetButtonDown("Jump"))
        {
            float CurrSpeed = Speed * Input.GetAxis("Horizontal");
           float CurrJumpForce =JumpForce * Input.GetAxis("Vertical");
            rigidbody2D.velocity = new Vector2(Speed, JumpForce);
        }
    }
}
