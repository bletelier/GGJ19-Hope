using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float fallMultiplier;
    public float lowFallMultiplier;
    private Rigidbody2D playerRigidbody;
    public bool canJump;
    private float tiempoUltimoSalto = 0;
    public float v = 0.1f;
    private bool Press = true;

    public float temp;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

   

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        canJump = false;
    }

    private void FixedUpdate()
    {
        //Movimiento principal y seguir moviendose
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            Press = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.rotation = new Quaternion(0, -180, 0, 0);
            Press = true;
        }

        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            Press = false;
        }
        //Saltos mejorados
        if (playerRigidbody.velocity.y < 0)
        {
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(playerRigidbody.velocity.y > 0 && (!Input.GetKey(KeyCode.W) || (Time.time - tiempoUltimoSalto) > 0.15f ))
        {
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity * (lowFallMultiplier - 1) * Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    void Update()
    {
        anim.SetBool("Pressing", Press);
        anim.SetBool("Grounded", canJump);
            

        temp = Mathf.Abs(playerRigidbody.velocity.y);
        
        if (Mathf.Abs(playerRigidbody.velocity.y) < v  && Input.GetKeyDown(KeyCode.W) && canJump)
        {
            playerRigidbody.velocity = Vector2.up * jumpSpeed;
            tiempoUltimoSalto = Time.time;
            canJump = false; ;   
        }
    }


}
