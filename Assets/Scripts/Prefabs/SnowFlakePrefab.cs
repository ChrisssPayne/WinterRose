using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlakePrefab : MonoBehaviour
{

    public GameObject Door;

    SpriteRenderer snowFlakeRenderer;
    Rigidbody2D rb;
    public bool active;

    void Start()
    {

        snowFlakeRenderer = GetComponent<SpriteRenderer>();
        if (active)
            snowFlakeRenderer.enabled = true;
        else
            snowFlakeRenderer.enabled = false;
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            if (active)
            {
                //Open a specific door
                Door.GetComponent<Door_Script>().Open();
                snowFlakeRenderer.enabled = false;
                active = false;
            }
            else
            {
                //Nothing
            }
        }
    }
}
