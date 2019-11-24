using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player inst;
    
    private bool playerTappedOnce;
    private bool playerTappedRight;

    private void Awake()
    {
        inst = this;
    }
    
    public void OnTappedRight()
    {        
        playerTappedRight = true;
        if (Math.Abs(Game.inst.BeatTimer - Game.inst.beatDur / 2f) <= Game.inst.beatDur / 5f)
        {
            if (playerTappedOnce)
            {
                // loose health for tapping twice
                Game.inst.LooseHealth("Tapped too often");
            }
            else
            {
                if (Game.inst.BeatTimer < Game.inst.beatDur / 2f)
                {
                    Game.inst.LooseHealth("Tapped too early");
                }
                else
                {
                    Game.inst.LooseHealth("Tapped too late");
                }
            }
        }

        playerTappedOnce = true;
    }
    
    public void OnTappedLeft()
    {
        playerTappedRight = false;
        if (Math.Abs(Game.inst.BeatTimer - Game.inst.beatDur / 2f) <= Game.inst.beatDur / 5f)
        {
            if (playerTappedOnce)
            {
                // loose health for tapping twice
                Game.inst.LooseHealth("Tapped too often");
            }
        }
        else
        {
            if (Game.inst.BeatTimer < Game.inst.beatDur / 2f)
            {
                Game.inst.LooseHealth("Tapped too early");
            }
            else
            {
                Game.inst.LooseHealth("Tapped too late");
            }
        }

        playerTappedOnce = true;
    }

    public void OnBeat()
    {
        if (playerTappedOnce)
        {
            if (playerTappedRight)
            {
                if (transform.localPosition.x >= 150)
                {
                    // lose health? and dont move
                    
                    return; // break?
                }

                transform.localPosition += Vector3.right * 150;
            }
            else
            {
                if (transform.localPosition.x <= -150)
                {
                    // lose health? and dont move
                    
                    return; // break?
                }

                transform.localPosition += Vector3.left * 150;
            }
        }
        else
        {
            if (Game.inst.score > 3)
            {
                Game.inst.LooseHealth("Tap missing");
            }
        }

        playerTappedOnce = false;
    }
}
