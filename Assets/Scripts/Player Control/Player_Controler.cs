using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controler : MonoBehaviour
{
    [Header("Movment Properties")]
    public float movementSpeed = 10;

    [Header("Size Properties")]
    public Vector3 sizeDelta;
    public Vector3 sizeGrowPile;
    public Vector3 sizeGrowTile;

    [Header("Jump Properties")]
    public float jumpForce = 15;

    //Private Member Variables
    private Rigidbody2D rb;
    private Vector2 movementDelta = Vector2.zero;
    private bool isJumping;
    private Vector3 startPos;
    private float old_pos;
    private bool left;
    private bool right;
    public GameObject SnowTilePrefab;
    public GameObject Snowball;
    public Vector3 pos;

    //public objects
    //public GameObject SnowPile;
    //public GameObject SnowPrefab;

    // Start is called before the first frame update
    void Start()
    {
        old_pos = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        movementDelta.x = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Snowball = GameObject.Find("Snowball");
        pos = Snowball.transform.position;
        pos.x -= 2;

        if (rb.velocity.magnitude > .3)
        {
            if (Vector3.Angle(transform.forward, Vector3.forward) <= 180.0)
            {
                if (this.transform.localScale.x > 0.3 && this.transform.localScale.y > 0.3)
                {
                    GameObject snow = (GameObject)Instantiate(SnowTilePrefab, pos, transform.rotation, null);
                    this.transform.localScale = this.transform.localScale - sizeDelta;
                    Destroy(snow, 5);
                }                
            }
            /*
            if (this.transform.localScale.x > 0.3 && this.transform.localScale.y > 0.3)
            {
                this.transform.localScale = this.transform.localScale - sizeDelta;
                GameObject snow = (GameObject)Instantiate(SnowTilePrefab, pos, transform.rotation, null);
            }
            */

        }
        
        /*
        if (old_pos < transform.position.x)
        {
            //print("moving right");
            right = true;
            left = false;
        }
        if (old_pos > transform.position.x)
        {
            //print("moving left");
            right = false;
            left = true;
        }
        old_pos = transform.position.x;

        
        if (right == true)
        {
            //this.transform.localScale = this.transform.localScale - sizeDelta;
        }
        else if (left == true)
        {
            //this.transform.localScale = this.transform.localScale - sizeDelta;
        }                   
        */

        rb.AddForce(movementDelta * Input.GetAxis("Horizontal"));

        Jump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            if (this.transform.localScale.x > 0.3 && this.transform.localScale.y > 0.3)
            {
                this.transform.localScale = this.transform.localScale - sizeDelta;
            }

            //this.transform.localScale = this.transform.localScale - sizeDelta;
            //movementDelta.y = jumpForce;
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            //movementDelta.y = jumpForce;
        }
        */

    }

    private void CalculateRotation()
    {
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            //rb.velocity = Vector2.zero;
        }

        if (collision.gameObject.CompareTag("SnowPile"))
        {
            isJumping = false;
            this.transform.localScale = this.transform.localScale + sizeGrowPile;
            Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.CompareTag("SnowTile"))
        {
            isJumping = false;
            this.transform.localScale = this.transform.localScale + sizeGrowTile;
            Destroy(collision.gameObject);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
