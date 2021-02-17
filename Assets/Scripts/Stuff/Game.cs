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
    //public AudioSource carSounds;
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public Slider slider;
    public Health health;
    public int Score { get; set; } = 0;
    public float ScoreFloat { get; set; } = 0;
    public int HighScore { get; set; } = 0;

    static Game instance = null;

    float timer = 0.0f;
    //public int pointz = 1;
    public int damage = 5;

    public enum eState
    {
        Title,
        StartGame,
        Game,
        GameOver
    }

    //public eState State { get; set; } = eState.Title;
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
                health.health = 100;
                startScreen.SetActive(false);
                timer = 0;
                Score = 0;
                music.Play();
                State = eState.Game;
                
                break;
            case eState.Game:
                Game.Instance.AddPoints();
                timer += Time.deltaTime;
                timerUI.text = string.Format("{0:D4}", (int)timer);
                if(Score > HighScore)
                {
                    HighScore = Score;
                    highScoreUI.text = string.Format("{0:D4}", HighScore);
                }
                if (slider.value <= 0)
                {
                    State = eState.GameOver;
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

    public void AddPoints()
    {
        ScoreFloat += Time.deltaTime;
        textUI.text = string.Format("{0:N4}", ScoreFloat);
    }

   public void AddPoints(int points)
    {
        Score += points;
        textUI.text = string.Format("{0:D4}", Score);
    }

    public void StartGame()
    {
        State = eState.StartGame;
    }
}
