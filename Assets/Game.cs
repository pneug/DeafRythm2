using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game inst;
    
    public float beatDur = 1f;
    public float BeatTimer;
    private bool calledOffBeat = false;

    public Text ScoreTxt;
    public int score = 0;

    public GameObject HealthPanel;

    public GameObject TutorialPanel;
    public GameObject VictoryPanel;
    public GameObject GamePanel;
    public GameObject GameOverPanel;
    public Text GameOverScore;
    private bool isGameOver = false;
    private bool watchedTutorial = false;
    public bool endless = true;

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
        if (watchedTutorial && TutorialPanel.activeSelf)
        {
            OnStart();
        }
        if (isGameOver) return;
        if (!GamePanel.activeSelf) return;
        BeatTimer -= Time.deltaTime;
        if (BeatTimer <= 0)
        {
            BeatTimer = beatDur;
            OnBeat();
            calledOffBeat = false;
        }
        else if (BeatTimer <= beatDur / 4f * 3f && calledOffBeat == false)
        {
             OnOffBeat();
        }
    }

    public void LooseHealth(string msg)
    {
        Notificator.inst.ShowNotif(msg);
        if (HealthPanel.GetComponentsInChildren<Image>().Length == 1)
        {
            Invoke("GameOver", beatDur * 0.8f);
        }

        Image removedItem = HealthPanel.GetComponentInChildren<Image>();
        AnimationManager.anims.Remove(removedItem.GetComponent<AnimationManager>());
        Destroy(removedItem.gameObject);
    }

    public void Victory()
    {
        isGameOver = true;
        VictoryPanel.SetActive(true);
        GamePanel.SetActive(false);
        GameOverScore.text = "You delivered " + score + " cakes";
    }

    private void GameOver()
    {
        isGameOver = true;
        GameOverPanel.SetActive(true);
        GamePanel.SetActive(false);
        GameOverScore.text = "You delivered " + score + " cakes";

        int old_highscore = PlayerPrefs.GetInt("highscore", 0);
        if (score > old_highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
            GameOverScore.text += "\nCongratulations, you hold the new highscore!";
        }
        else
        {
            GameOverScore.text += "\nThe current Highscore is " + old_highscore;
        }
    }

    public void OnStartAdventure()
    {
        endless = false;
        OnStart();
    }

    public void OnStartEndless()
    {
        endless = true;
        OnStart();
    }

    public void OnStart()
    {
        TutorialPanel.SetActive(false);
        GamePanel.SetActive(true);
        watchedTutorial = true;
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
        /*if (score < 10)
        {
            Handheld.Vibrate();
        }*/
    }

    private void OnOffBeat()
    {
        // check if the player has tapped exactly once
        if (score < 10)
        {
            Handheld.Vibrate();
        }

        calledOffBeat = true;
    }
}
