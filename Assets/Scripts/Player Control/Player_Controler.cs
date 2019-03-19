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
    private bool isJumping;
    private Vector3 startPos;
    public float snow;
    public float jumpCost;
    public GameObject SnowTilePrefab;
    public GameObject SnowPrefab;

    public GameObject Snowball;
    public Vector3 pos;

    public float LavaChangeAmount = 1.0f;

    public float restartTime = 1f;

    //public objects
    //public GameObject SnowPile;
    //public GameObject SnowPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementDelta.x = movementSpeed;

        resizePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //Snowball = GameObject.Find("Snowball");
        //pos = this.transform.position;

        rb.AddForce(movementDelta * Input.GetAxis("Horizontal"));

        Jump();
        Reset();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            if (this.transform.localScale.x > 0.3 && this.transform.localScale.y > 0.3)
            {
                GameObject pile;
                pile = Instantiate(SnowPrefab, this.transform.position, transform.rotation, null);
                pile.GetComponent<SnowPilePrefab>().storedSnow = jumpCost;
                removeSnow(jumpCost);
            }
        }
    }

    private void Reset()
    {
        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            //Application.LoadLevel(Application.loadedLevel);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    private void CalculateRotation()
    {
        
    }

    private void resizePlayer()
    {
        this.transform.localScale = (sizeDelta * snow) + Vector3.one * 0.3f;
    }
    public void killPlayer()
    {
        this.rb.velocity = Vector2.zero;
        this.rb.isKinematic = false;
        this.enabled = false;
        if (restartTime <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        restartTime = restartTime - 0.001f;
        
    }

    public void removeSnow(float amountToRemove)
    {

        if (amountToRemove > 0)
        {
            snow -= amountToRemove;
            resizePlayer();
        }

        if(snow < 0)
            killPlayer();
       
    }

    public void addSnow(float amountToAdd)
    {
        if (amountToAdd > 0)
        {
            snow += amountToAdd;
            resizePlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
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
        if (collision.gameObject.CompareTag("Lava"))
        {
            removeSnow(LavaChangeAmount);
        }
        if (collision.gameObject.CompareTag("Port1"))
        {
            SceneManager.LoadScene(2);
        }
        if (collision.gameObject.CompareTag("Port2"))
        {
            SceneManager.LoadScene(0);
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        
    }
}
