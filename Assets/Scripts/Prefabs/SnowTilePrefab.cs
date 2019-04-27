using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTilePrefab : MonoBehaviour
{
  
    public GameObject SnowPrefab;
    public GameObject Snowball;
    SpriteRenderer snowTileRenderer;
    Rigidbody2D rb;
    public bool active;

    public float snowChangeAmount = 1.0f;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //rb.isKinematic = false;
        snowTileRenderer = GetComponent<SpriteRenderer>();
        if (active)
            snowTileRenderer.enabled = true;
        else
            snowTileRenderer.enabled = false;
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<Player_Controler>().isDead)
        {
            if (collision.gameObject.CompareTag("Snowball"))
            {
                if (active)
                {
                    //give snow to snowball
                    collision.gameObject.GetComponent<Player_Controler>().addSnow(snowChangeAmount);
                    snowTileRenderer.enabled = false;
                    active = false;
                }
                else
                {
                    //take snow from snowball
                    collision.gameObject.GetComponent<Player_Controler>().removeSnow(snowChangeAmount);
                    snowTileRenderer.enabled = true;
                    active = true;
                }
            }
        }
    }
}
