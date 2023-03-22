using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacerController : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public  float Speed;
    public float JumpForce ;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
        float CurrSpeed = Speed * Input.GetAxis("Horizontal");
        Rigidbody2D.velocity = new Vector2(CurrSpeed , 0);
        
        if (Input.GetButtonDown("Jump"))
        {
            Rigidbody2D.velocity = new Vector2(CurrSpeed, JumpForce);
        }
    }
}
