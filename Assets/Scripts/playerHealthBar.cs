using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHealthBar : MonoBehaviour
{
    private float maxHealth = 100.0f;
    public float currentHealth;
    public float sockTime = 3.0f;
    public float trapTime = -2.0f;
    public float trapTime2 = -1.0f;
    public float houseTime = 0.7f;
    public Image healthBar;
    public float time;
    private bool invulnerable;
    public Image deathImage;
    public Image deathImage2;
    public Image winImage;
    private bool gano = false;
    private Rigidbody2D pRb;
    private winControl audios;
    public AudioClip death;
    public AudioClip damage;
    public AudioClip smell;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("HealthBarImage").GetComponent<Image>();
        deathImage = GameObject.Find("deathImage").GetComponent<Image>();
        deathImage2 = GameObject.Find("deathImage2").GetComponent<Image>();
        winImage = GameObject.Find("win").GetComponent<Image>();
        audios = GetComponent<winControl>();

        deathImage.enabled = false;
        deathImage2.enabled = false;
        winImage.enabled = false;
        healthBar.fillAmount = 1.0f;
        currentHealth = maxHealth;
        time = 10.0f;
        invulnerable = false;
        pRb = GetComponent<Rigidbody2D>();
        StartCoroutine(perderVida());
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Calceta")
        {
            SoundManagerFX.PlaySound(smell);
            currentHealth = Mathf.Clamp(currentHealth + ((maxHealth / (time )) *sockTime), 0, 100);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Trampa2" && !invulnerable)
        {
            currentHealth = Mathf.Clamp(currentHealth + ((maxHealth / (time)) * trapTime), 0, 100);
            SoundManagerFX.PlaySound(damage);
            StartCoroutine(serInvulnerable());
        }
        if(collision.gameObject.tag == "Finish")
        {
            gano = true;
            Destroy(this.gameObject);
            winImage.enabled = true;
        }
        if (collision.gameObject.tag == "Trampa3" && !invulnerable)
        {
            currentHealth = Mathf.Clamp(currentHealth + ((maxHealth / (time)) * trapTime2), 0, 100);
            SoundManagerFX.PlaySound(damage);
            StartCoroutine(serInvulnerable());

        }
        if(collision.gameObject.tag == "InstaDeath")
        {
            currentHealth = 0.0f;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Casa")
        {
            currentHealth = Mathf.Clamp(currentHealth + ((maxHealth / (time * 20f)) * houseTime), 0, 100);
        }
    }

    private void Update()
    {
        if(currentHealth <= 0.0f && !gano)
        {
            Destroy(this.gameObject);
            deathImage.enabled = true;
            deathImage2.enabled = true;
            audios.play(death);
          

            
        }

    }
    
    IEnumerator serInvulnerable()
    {
        invulnerable = true;
        yield return new WaitForSeconds(1.5f);
        invulnerable = false;
    }

    IEnumerator perderVida()
    {
        yield return new WaitForSeconds(1.0f);
        while (currentHealth > 0.0f)
        {
            yield return new WaitForSeconds(0.1f);
            currentHealth = Mathf.Clamp(currentHealth - (maxHealth / (time*10f)), 0.0f,100.0f);
            healthBar.fillAmount = currentHealth/maxHealth;
        }
    }
}
