using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPlatform : MonoBehaviour
{
    private Vector3 limitxp;
    private Vector3 limitxn;
    bool movDer = true;
    public float rango = 0;
    public float speed = 0;

    private void Start()
    {
        limitxp = transform.position + Vector3.right * rango;
        limitxn= transform.position + Vector3.left * rango;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < limitxp.x && movDer)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            movDer = false;
        }
        if (transform.position.x > limitxn.x && !movDer )
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            movDer = true;
        }
        
    }
}
