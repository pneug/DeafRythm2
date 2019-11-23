using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        transform.localPosition += Vector3.down *50f;
        /*if (transform.localPosition.y <= Player.inst.transform.localPosition.y)
        {
            // check if colliding with player
            
        }*/
        // maybe destroy if out of screen
    }
}
