using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(tiempoMusica());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
    IEnumerator tiempoMusica()
    {
        yield return new WaitForSeconds(25);
        SceneManager.LoadScene(1);
    }
}
