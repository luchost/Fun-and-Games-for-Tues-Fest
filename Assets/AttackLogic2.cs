using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLogic2 : MonoBehaviour
{
    public CharacterControlle2 characterControlle2;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (characterControlle2.Blocking == true)
            {
                characterControlle2.BlockAttack(10);
            }
            else
            {
                characterControlle2.AttackHit(10);
            }

        }
    }
}

