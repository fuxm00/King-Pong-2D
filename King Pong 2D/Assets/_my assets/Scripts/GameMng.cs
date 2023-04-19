using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMng : MonoBehaviour
{
    [Header("Ball prefab")]
    public Ball ball;
    [Header("Paddle prefab")]
    public Paddle paddle;
    [Header("Pause menu")]
    public GameObject pauseMenuUI;
    private PauseMenuMng pauseMenuMng;
    [Header("Scoreboard")]
    public ScoreBoardUI scoreBoardUI;
    private ScoreBoardMng scoreBoardMng;
    [Header("Other")]
    public StartGameUI StartGameUI;   
    
    public HighScoreMng highScoreUI;

    public AudioSource source;

    private Ball playBall;
    private Paddle paddleLeft;
    private Paddle paddleRight;

    public bool playerIsPlaying;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    void Start()
    {
        pauseMenuMng = FindObjectOfType<PauseMenuMng>();
        scoreBoardMng = FindObjectOfType<ScoreBoardMng>();
        prepareGameField();
        scoreBoardMng.resetScoreBoard();
        checkVariables();
    }

    /// <summary>method <c>prepareGameField</c> prepares gamefield</summary>
    public void prepareGameField()
    {
        Time.timeScale = 0f;

        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        playBall = Instantiate(ball);
        paddleLeft = Instantiate(paddle) as Paddle;
        paddleRight = Instantiate(paddle) as Paddle;

        paddleLeft.Prepare(false);
        paddleRight.Prepare(true);
    }

    public void initGame()
    {
        playerIsPlaying = true;
        scoreBoardUI.scoreBoard.SetActive(true);
        Cursor.visible = false;
        newGame();
    }

    public void newGame()
    {
        resetGameElements();
        Time.timeScale = 1f;
    }

    public void terminateGame()
    {
        StartGameUI.gameObject.SetActive(true);
        pauseMenuUI.SetActive(false);
        resetGameElements();
        pauseMenuMng.gameIsPaused = false;
        playerIsPlaying = false;
        Time.timeScale = 0f;
        scoreBoardUI.scoreBoard.SetActive(false);
        Cursor.visible = true;
    }

    public void quitApp()
    {
        Application.Quit();
    }

    private void checkVariables()
    {
        if (ball == null)
        {
            Debug.Log("ball je null");
        }
        if (paddle == null)
        {
            Debug.Log("paddle je null");
        }
    }

    public void resetAfterGoal()
    {
        playBall.ResetBall();
        scoreBoardMng.resetBounces();
        FindObjectOfType<AudioMng>().play("bam");
    }

    #region Reset methods
    public void resetGameElements()
    {
        playBall.ResetBall();
        paddleLeft.reset();
        paddleRight.reset();

        scoreBoardMng.resetScoreBoard();
    }
    #endregion
}
