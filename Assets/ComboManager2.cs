using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager2 : MonoBehaviour
{
    public float numberOfHits;
    public GameObject enemy;

   
    public void AddHit()
    {
        numberOfHits += 1;
        StartCoroutine(Comboed());
    }
    IEnumerator Comboed()
    {
        if (numberOfHits <= 10)
        {
            enemy.GetComponent<CharacterControlle2>().enabled = false;
        }
        else
        {
            enemy.GetComponent<CharacterControlle2>().enabled = true;
        }
        yield return new WaitForSeconds(1f);
        enemy.GetComponent<CharacterControlle2>().enabled = true;
        numberOfHits = 0f;



    }
}
