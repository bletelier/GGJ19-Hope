using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaLibre : MonoBehaviour
{
    //public GameObject pincho;
    private Rigidbody2D pincho1;
    private Rigidbody2D pincho2;
    private Rigidbody2D pincho3;


    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.tag == "Player")
    {
        pincho1.gravityScale = 1;
        pincho2.gravityScale = 1;
        pincho3.gravityScale = 1;
        Destroy(gameObject);

        }
}

    // Start is called before the first frame update
    void Start()
    {
        pincho1 = GameObject.Find("Pincho Con caida").GetComponent<Rigidbody2D>();
        pincho2 = GameObject.Find("Pincho Con caida (2)").GetComponent<Rigidbody2D>();
        pincho3 = GameObject.Find("Pincho Con caida (1)").GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
