using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaHielo : MonoBehaviour
{
    public float waitCaida = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyPlatform());

        }
    }

    IEnumerator DestroyPlatform()
    {
        yield return new WaitForSeconds(waitCaida);
        Destroy(this.gameObject);
    }

}
