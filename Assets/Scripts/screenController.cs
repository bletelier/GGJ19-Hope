using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class screenController : MonoBehaviour
{
    public void CambiarEscena(string nescena)
    {
        SceneManager.LoadScene(nescena);
    }
    
}
