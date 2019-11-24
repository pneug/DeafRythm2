using System;
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

    
    /// <summary>
    /// 
    /// </summary>
    /// <returns>true if collided with player</returns>
    public bool Move()
    {
        transform.localPosition += Vector3.down *50f;
        if (Math.Abs(transform.position.y - Player.inst.transform.position.y) <= 20)
        {
            // check if colliding with player
            if (Math.Abs(transform.position.x - Player.inst.transform.position.x) <= 20)
            {
                // let player loose health
                Game.inst.LooseHealth();
                return true;
            }
        }
        // maybe destroy if out of screen

        return false;
    }
}
