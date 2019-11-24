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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTappedRight()
    {
        playerTappedRight = true;
        if (playerTappedOnce)
        {
            // loose health for tapping twice?
            
        }
        playerTappedOnce = !playerTappedOnce;
    }
    
    public void OnTappedLeft()
    {
        playerTappedRight = false;
        if (playerTappedOnce)
        {
            // loose health for tapping twice?
            
        }
        playerTappedOnce = !playerTappedOnce;
    }

    public void OnBeat()
    {
        if (playerTappedOnce)
        {
            if (playerTappedRight)
            {
                if (transform.localPosition.x >= 50)
                {
                    // lose health and dont move
                    
                    return; // break?
                }

                transform.localPosition += Vector3.right * 50;
            }
            else
            {
                if (transform.localPosition.x <= -50)
                {
                    // lose health and dont move
                    
                    return; // break?
                }

                transform.localPosition += Vector3.left * 50;
            }
        }

        playerTappedOnce = false;
    }
}
