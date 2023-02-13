using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguiPersonaje : MonoBehaviour
{
    public float xRel, yRel;
    public GameObject personajeASeguir;
    void Update()
    {
        transform.position = new Vector3(personajeASeguir.transform.position.x-xRel, personajeASeguir.transform.position.y - yRel, -10);
    }
}
