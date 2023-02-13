using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    public float velocity = 0.0f;
    private Renderer rd;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rd.material.mainTextureOffset = new Vector2(player.position.x * velocity, 0.0f);
    }
}
