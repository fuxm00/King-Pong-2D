using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoardMng : MonoBehaviour
{
    [Header("Scoreboard")]
    public ScoreBoardUI scoreBoardUI;

    private GameMng gameMng;

    public int leftScore;
    public int rightScore;
    public int bounceCount;

    void Start()
    {
        gameMng = FindObjectOfType<GameMng>();
    }

    void Update()
    {
        
    }

    public void increaseScore(bool isRightPlayer)
    {
        if (isRightPlayer)
        {
            rightScore++;
            scoreBoardUI.refreshRightScore();
        }
        else
        {
            leftScore++;
            scoreBoardUI.refreshLeftScore();
        }

        gameMng.resetAfterGoal();
    }

    public void increaseBounceCount()
    {
        bounceCount++;
        scoreBoardUI.refreshBounceMeter();
    }

    #region Reset methods
    public void resetScoreBoard()
    {
        resetRightScore();

        resetLeftScore();

        resetBounces();
    }

    public void resetBounces()
    {
        int i = 0;
        bounceCount = i;
        scoreBoardUI.refreshBounceMeter();
    }

    public void resetLeftScore()
    {
        int i = 0;
        leftScore = i;
        scoreBoardUI.refreshLeftScore();
    }

    public void resetRightScore()
    {
        int i = 0;
        rightScore = i;
        scoreBoardUI.refreshRightScore();
    }

    #endregion
}
