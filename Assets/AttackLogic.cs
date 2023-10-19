using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLogic : MonoBehaviour
{
    public CharacerController characerController;
    public ComboManager combo;
    public HealthManager healthManager;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (characerController.Blocking == true)
            {
               characerController.BlockAttack(10);
                healthManager.ChangeHealthBar1();
            }
            else
            {
              characerController.AttackHit(10);
                combo.AddHit();
                healthManager.ChangeHealthBar1();
            }

        }
    }
}
