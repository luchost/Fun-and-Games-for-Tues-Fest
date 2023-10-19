using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
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
            enemy.GetComponent<CharacerController>().enabled = false;
        }else{
            enemy.GetComponent<CharacerController>().enabled = true;
        }
        yield return new WaitForSeconds(1f);
        enemy.GetComponent<CharacerController>().enabled = true;
        numberOfHits = 0f;



    }
}
