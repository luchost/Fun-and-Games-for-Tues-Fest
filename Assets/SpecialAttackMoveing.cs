using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackMoveing : MonoBehaviour
{
    public float speed;
    public Animator Animator;
    public Rigidbody2D rigid;
    public GameObject HurtBox;
    public GameObject me;
    // Start is called before the first frame update
    void Start()
    {
        MoveToPosition();
    }
    void Update() 
    {

            if (rigid.velocity.x == 0)
            {
                // rigid.velocity = new Vector2(0, 0);
                Attack();
            }
      
    }
    void MoveToPosition() 
    {
        rigid.AddForce(new Vector2(speed,0));
        
    }
    void Attack() 
    {
        StartCoroutine(WaitAndStartHurtBox(HurtBox));
        
    }
    IEnumerator WaitAndStartHurtBox(GameObject HurtBox)
    {
        yield return new WaitForSeconds(.5f);
        Animator.SetBool("Attack", true);
        HurtBoxStart(HurtBox);
        yield return new WaitForSeconds(2f);
        HurtBoxStop(HurtBox);
    }
    void HurtBoxStart(GameObject HurtBox)
    {
        HurtBox.SetActive(true);
    }
    void HurtBoxStop(GameObject HurtBox)
    {
        HurtBox.SetActive(false);
        Destroy(me);
    }
}
