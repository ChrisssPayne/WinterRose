using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTilePrefab : MonoBehaviour
{
  
    public GameObject SnowPrefab;
    public GameObject Snowball;
    public Vector3 pos;
    public Vector3 startPos;
    

    private void Update()
    {
        //Snowball = GameObject.Find("Snowball");
        //pos = Snowball.transform.position;
        //startPos = pos;
        //pos.x -= 1;

        /*
        if (transform.hasChanged && transform.position.x >= startPos.x)
        {
            GameObject snow = (GameObject)Instantiate(SnowPrefab, pos, transform.rotation, null);
        }
        */
        

    }
}
