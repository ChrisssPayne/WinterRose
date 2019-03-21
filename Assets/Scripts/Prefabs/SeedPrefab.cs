using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPrefab : MonoBehaviour
{

    public GameObject Icon;
    SpriteRenderer seedRenderer;
    Rigidbody2D rb;
    public bool active;

    void Start()
    {

        seedRenderer = GetComponent<SpriteRenderer>();
        if (active)
            seedRenderer.enabled = true;
        else
            seedRenderer.enabled = false;
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
                //Hide seed icon
                Icon.SetActive(false);
                seedRenderer.enabled = false;
                active = false;
            }
            else
            {
                //Nothing
            }
        }
    }
}
