using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardUI : MonoBehaviour
{
    [Header("ScoreBoard")]
    public GameObject scoreBoard;
    [Header("Left score")]
    public Text leftScoreTxt;
    [Header("Right score")]
    public Text rightScoreTxt;
    [Header("Bounce count")]
    public Text bounceMeterTxt;
    public GameObject bounceMeter;
    [Header("Line")]
    public GameObject line;
    [Header("Other")]
    public GameMng gameMng;
    public ScoreBoardMng scoreBoardMng;

    void Start()
    {
        prepareLayout();
    }

    void Update()
    {
        
    }
    public void prepareLayout()
    {
        bounceMeter.transform.position = LayoutMng.topMiddle;
        leftScoreTxt.transform.position = LayoutMng.topMiddleLeft;
        rightScoreTxt.transform.position = LayoutMng.topMiddleRight;
        line.transform.localScale = LayoutMng.verticalLine;
    }

    #region refresh methods
    public void refreshLeftScore()
    {
        leftScoreTxt.text = scoreBoardMng.leftScore.ToString();
    }

    public void refreshRightScore()
    {
        rightScoreTxt.text = scoreBoardMng.rightScore.ToString();
    }

    public void refreshBounceMeter()
    {
        bounceMeterTxt.text = scoreBoardMng.bounceCount.ToString();
    }
    #endregion
}
