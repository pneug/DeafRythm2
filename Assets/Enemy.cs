using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    /// <summary>
    /// 
    /// </summary>
    /// <returns>true if collided with player</returns>
    public bool Move()
    {
        transform.localPosition += Vector3.down *150f;
        if (Math.Abs(transform.position.y - Player.inst.transform.position.y) <= 75)
        {
            // check if colliding with player
            if (Math.Abs(transform.position.x - Player.inst.transform.position.x) <= 75)
            {
                // let player loose health
                Game.inst.LooseHealth("");
                return true;
            }
        }
        // maybe destroy if out of screen

        return false;
    }
}
