using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private float beatDur = 1f;

    public float BeatTimer;
    // Start is called before the first frame update
    void Start()
    {
        BeatTimer = beatDur;
    }

    // Update is called once per frame
    void Update()
    {
        BeatTimer -= Time.deltaTime;
        if (BeatTimer <= 0)
        {
            BeatTimer = beatDur;
            OnBeat();
        }
    }
    
    private void OnBeat()
    {
        // call all actions which happen on beat, e.g. increase score, move enemies, let player move 
        foreach (Enemy e in EnemyManager.inst.enemies)
        {
            e.Move();
        }
    }

    private void OnLateBeat()
    {
        // check if the player has tapped exactly once
    }
}
