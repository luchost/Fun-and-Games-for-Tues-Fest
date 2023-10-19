using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLogic2 : MonoBehaviour
{
    public CharacterControlle2 characterControlle2;
    public ComboManager2 combo;
    public HealthManager healthManager;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (characterControlle2.Blocking == true)
            {
                characterControlle2.BlockAttack(10);
                healthManager.ChangeHealthBar2();
            }
            else
            {
                characterControlle2.AttackHit(10);
                combo.AddHit();
                healthManager.ChangeHealthBar2();
            }

        }
    }
}

