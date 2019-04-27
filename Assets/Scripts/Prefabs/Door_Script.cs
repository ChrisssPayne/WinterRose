using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Script : MonoBehaviour
{

    SpriteRenderer doorRenderer;
    Rigidbody2D rb;
    public bool active;

    void Start()
    {

        doorRenderer = GetComponent<SpriteRenderer>();
        if (active)
            doorRenderer.enabled = true;
        else
            doorRenderer.enabled = false;
    }

    private void Update()
    {
    }

    public void Open()
    {
        GetComponent<Collider2D>().enabled = false;
        doorRenderer.enabled = false;
        active = false;
    }
}