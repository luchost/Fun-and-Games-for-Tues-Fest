using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image HealthBar1;
    public Image HealthBar2;
    public CharacerController Player1;
    public CharacterControlle2 Player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeHealthBar1() 
    {
        HealthBar1.fillAmount = Player1.Health / 600f;
    
    }
    public void  ChangeHealthBar2()
    {
        HealthBar2.fillAmount = Player2.Health / 600f;

    }
}
