using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game inst;
    
    private float beatDur = 1f;
    public float BeatTimer;

    public Text ScoreTxt;
    private int score = 0;

    public GameObject HealthPanel;

    public GameObject GamePanel;
    public GameObject GameOverPanel;
    public Text GameOverScore;
    private bool isGameOver = false;

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        BeatTimer = beatDur;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;
        BeatTimer -= Time.deltaTime;
        if (BeatTimer <= 0)
        {
            BeatTimer = beatDur;
            OnBeat();
        }
    }

    public void LooseHealth()
    {
        if (HealthPanel.GetComponentsInChildren<Image>().Length == 1)
        {
            // Game Over
            isGameOver = true;
            GameOverPanel.SetActive(true);
            GamePanel.SetActive(false);
            GameOverScore.text = "You survived " + score + " beats";
        }

        Image removedItem = HealthPanel.GetComponentInChildren<Image>();
        AnimationManager.anims.Remove(removedItem.GetComponent<AnimationManager>());
        Destroy(removedItem.gameObject);
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(0);
        AnimationManager.anims = new List<AnimationManager>();
    }
    
    private void OnBeat()
    {
        Player.inst.OnBeat();
        // call all actions which happen on beat, e.g. increase score, move enemies, let player move 
        foreach (Enemy e in EnemyManager.inst.enemies)
        {
            e.Move();
        }
        EnemyManager.inst.OnBeat();
        foreach (AnimationManager anim in AnimationManager.anims)
        {
            anim.OnBeat();
        }
        if (!isGameOver)
        {
            score += 1;
            ScoreTxt.text = "Score: " + score;
        }
    }

    private void OnLateBeat()
    {
        // check if the player has tapped exactly once
    }
}
