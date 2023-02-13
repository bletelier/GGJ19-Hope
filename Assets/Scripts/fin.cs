using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fin : MonoBehaviour
{
    private Image im;
    public void Awake()
    {
        im = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        if(im.enabled)
        {
            if(im.name.Equals("win"))
            {
                StartCoroutine(volverAlMenu());
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(2);


                }
            }
            
        }
    }
    IEnumerator volverAlMenu()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(1);
    }
}
