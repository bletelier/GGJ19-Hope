using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class alpha : MonoBehaviour
{
    public SpriteRenderer game;
    private float myTime;
    // Start is called before the first frame update
    void Start()
    {
        game = GetComponent<SpriteRenderer>();
        myTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        game.color += new Color(0, 0, 0, 1) * Time.deltaTime*0.3f;
        if (Time.time - myTime >= 4.5f)
        {
            SceneManager.LoadScene("Comic");
        }
    }
}
