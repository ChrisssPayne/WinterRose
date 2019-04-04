using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPilePrefab : MonoBehaviour
{
    public GameObject SnowPrefab;
    SpriteRenderer snowPileRenderer;

    public Vector3 pos;
    private Rigidbody2D rb;


    public bool active;
    public float storedSnow;

    //private Vector3 startPos;

    
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        snowPileRenderer = this.GetComponent<SpriteRenderer>();
        snowPileRenderer.enabled = true;
        //active = false;    
    }
    

    private void Update()
    {
        pos = this.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            if (active)
            {
                //give snow to snowball
                collision.gameObject.GetComponent<Player_Controler>().addSnow(storedSnow);
                Destroy(gameObject);
                Debug.Log("I SHOULD BE DEAD!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            active = false;
        }
    }


}


