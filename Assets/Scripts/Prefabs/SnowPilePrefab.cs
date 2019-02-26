using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPilePrefab : MonoBehaviour
{
    public GameObject SnowPrefab;
    public GameObject Snowball;
    public Vector3 pos;

    //private Vector3 startPos;

    /*
    private void Start()
    {
        startPos = transform.position;
    }
    */

    private void Update()
    {
        Snowball = GameObject.Find("Snowball");
        pos = Snowball.transform.position;
        //startPos = pos;
        //pos.x -= 2;


        
        /*
        if (transform.hasChanged && transform.position.x >= startPos.x)
        {
            GameObject snow = (GameObject)Instantiate(SnowPrefab, pos, transform.rotation, null);
        }
        */
        
    }        
}


