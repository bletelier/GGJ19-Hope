using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public Camera camSnow;
    public Camera camFire;
    public playerHealthBar phb;
    

    


    private void Awake()
    {
        camSnow = GameObject.Find("Main Camera").GetComponent<Camera>();
        camFire = GameObject.Find("Main Camera (1)").GetComponent<Camera>();
        phb = GetComponent<playerHealthBar>();
        
        camSnow.enabled = true;
        camFire.enabled = false;
    }
    private void Update()
    {
        if(phb.currentHealth <= 25.0f)
        {
            camSnow.enabled = false;
            camFire.enabled = true;
        }
        else
        {
            camSnow.enabled = true;
            camFire.enabled = false;
        }
    }


}
