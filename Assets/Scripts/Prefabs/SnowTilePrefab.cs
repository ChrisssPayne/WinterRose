using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTilePrefab : MonoBehaviour
{
  
    public GameObject SnowPrefab;
    public GameObject Snowball;
    SpriteRenderer snowTileRenderer;
    bool active;

    public int snowChangeAmount;
    void Start()
    {
        snowTileRenderer = GetComponent<SpriteRenderer>();
        active = false;
    }

    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            if (active)
            {
                //give snow to snowball
                collision.gameObject.GetComponent<Player_Controler>().snow += snowChangeAmount;
                snowTileRenderer.enabled = false;
                active = false;
            }
            else
            {
                //take snow from snowball
                collision.gameObject.GetComponent<Player_Controler>().snow -= snowChangeAmount;
                snowTileRenderer.enabled = true;
                active = true;
            }
        }

    }
}
