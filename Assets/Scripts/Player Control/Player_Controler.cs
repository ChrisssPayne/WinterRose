using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Vector3 startPos;
    public float snow;
    public float jumpCost;
    public GameObject SnowTilePrefab;
    public GameObject SnowPrefab;

    public GameObject Snowball;
    public Vector3 pos;

    public float LavaChangeAmount = 1.0f;

    public float restartTime = 1f;

    public bool isDead = false;
    public bool hasControl = true;

    public GameObject[] Pieces;


    private float force = 0.5f;
    private float starting_snow = 25;

    //public objects
    //public GameObject SnowPile;
    //public GameObject SnowPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Pieces = GameObject.FindGameObjectsWithTag("Piece");

        rb = GetComponent<Rigidbody2D>();
        movementDelta.x = movementSpeed;
        resizePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.rb.mass);
        //Snowball = GameObject.Find("Snowball");
        //pos = this.transform.position;
        if (!this.isDead)
        {
            if(hasControl)
                rb.AddForce(movementDelta * Input.GetAxis("Horizontal") * this.force);
        }

        Reset();
        checkIfAlive();
    }

    private void Reset()
    {
        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    private void resizePlayer()
    {
        this.transform.localScale = (sizeDelta * snow) + Vector3.one * 0.3f;
    }
    public void killPlayer()
    {
        //Turn off and Kill Snowball

        this.GetComponent<SpriteRenderer>().enabled = false;

        this.rb.velocity = Vector2.zero;
        this.rb.isKinematic = false;
        this.isDead = true;
        this.rb.mass = 1;

        //Make the Pieces appear and behave kinematically

        foreach (GameObject piece in Pieces)
        {
            piece.GetComponent<SpriteRenderer>().enabled = true;
            piece.GetComponent<PolygonCollider2D>().enabled = true;
            piece.GetComponent<Rigidbody2D>().simulated = true;

        }
        //this.enabled = false;


    }

    public void removeSnow(float amountToRemove)
    {

        if (amountToRemove > 0)
        {
            snow -= amountToRemove;
            resizePlayer();
            if (snow < 0)
                killPlayer();
            rb.mass = this.snow / 50;
            if (rb.mass < 0.1f)
                rb.mass = 0.1f;
            float difference = this.snow / starting_snow;
            this.force = 0.4f * difference + 0.1f;
        }

        if (snow < 0)
        {
            killPlayer();
        }
       
    }

    public void checkIfAlive()
    {
        if (this.isDead)
        {
            restartTime = restartTime - 0.01f;
            Debug.Log(restartTime);
            if (restartTime <= 0)
            {
                
                //Application.LoadLevel(Application.loadedLevel);
                Scene scene = SceneManager.GetActiveScene();
                if(scene.buildIndex == 4)
                {
                    restartTime = 1.0f;
                }
                else
                {
                    SceneManager.LoadScene(scene.name);

                }
            }

        }
    }

    public void addSnow(float amountToAdd)
    {
        if (amountToAdd > 0)
        {
            snow += amountToAdd;
            resizePlayer();
            rb.mass = this.snow / 50;
            if (rb.mass < 0.1f)
                rb.mass = 0.1f;
            float difference = this.snow / starting_snow;
            this.force = 0.4f * difference + 0.1f;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Kill") || collision.gameObject.CompareTag("Lava"))
        {
            killPlayer();
        }

        if (collision.gameObject.CompareTag("SnowPile"))
        {
            //isJumping = false;
            //this.transform.localScale = this.transform.localScale + sizeGrowPile;
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("SnowTile"))
        {
            //isJumping = false;
            //this.transform.localScale = this.transform.localScale + sizeGrowTile;
            //Destroy(collision.gameObject);

        }
        
        if (collision.gameObject.CompareTag("Port1"))
        {
            SceneManager.LoadScene(2);
        }
        if (collision.gameObject.CompareTag("Port2"))
        {
            SceneManager.LoadScene(3);
        }
        if (collision.gameObject.CompareTag("Port3"))
        {
            SceneManager.LoadScene(4);
        }
        if (collision.gameObject.CompareTag("Port4"))
        {
            SceneManager.LoadScene(5);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kill") || collision.gameObject.CompareTag("Lava"))
        {
            killPlayer();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heat"))
        {
            Debug.Log(LavaChangeAmount);
            removeSnow(LavaChangeAmount);
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        
    }
}
