using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLogic : MonoBehaviour
{
    public CharacerController characerController;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (characerController.Blocking == true)
            {
               characerController.BlockAttack(10);
            }
            else
            {
              characerController.AttackHit(10);
            }

        }
    }
}
