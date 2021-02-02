using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Game : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public TextMeshProUGUI timerUI;
    public TextMeshProUGUI highScoreUI;
    public AudioSource music;
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public int Score { get; set; } = 0;
    public int HighScore { get; set; } = 0;

    static Game instance = null;

    float timer = 90.0f;

    public enum eState
    {
        Title,
        StartGame,
        Game,
        GameOver
    }

    public eState State { get; set; } = eState.Title;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        switch (State)
        {
            case eState.Title:
                gameOverScreen.SetActive(false);
                startScreen.SetActive(true);
                break;
            case eState.StartGame:
                startScreen.SetActive(false);
                timer = 30;
                Score = 0;
                music.Play();
                State = eState.Game;
                
                break;
            case eState.Game:
                timer -= Time.deltaTime;
                timerUI.text = string.Format("{0:D2}", (int)timer);
                if (timer <= 0)
                {
                    music.Stop();
                    State = eState.GameOver;
                }
                if(Score > HighScore)
                {
                    HighScore = Score;
                    highScoreUI.text = string.Format("{0:D4}", HighScore);
                }
                break;
            case eState.GameOver:
                gameOverScreen.SetActive(true);
                break;
            default:
                break;
        }

    }

    public static Game Instance
    {
        get
        {
            return instance;
        }
    }

    //public eState State { get; set; } = eState.Title;

    public void AddPoints(int points)
    {
        Score += points;
        textUI.text = string.Format("{0:D4}", Score);
    }

    //public void HighScore(int highScore)
    //{
    //    Score += highScore;
    //    if (highScore < Score)
    //    {
    //        HighScoreUI.text = string.Format("{0:D4}", Score);
    //    }

    //    else if (highScore > Score)
    //    {
           
    //    }
    //}

    public void StartGame()
    {
        State = eState.StartGame;
    }

    
}
