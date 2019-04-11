﻿using System.Collections;
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

    private bool isDead = false;

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
        if(!this.isDead)
            rb.AddForce(movementDelta * Input.GetAxis("Horizontal"));


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
        this.rb.velocity = Vector2.zero;
        this.rb.isKinematic = false;
        this.isDead = true;
        //this.enabled = false;
        
        
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
                SceneManager.LoadScene(scene.name);
            }

        }
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

        if (collision.gameObject.CompareTag("Heat"))
        {
            print(LavaChangeAmount);
            removeSnow(LavaChangeAmount);
        }
        if (collision.gameObject.CompareTag("Kill") || collision.gameObject.CompareTag("Lava"))
        {
            killPlayer();
        }
    }
    

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
