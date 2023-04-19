using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour
{
    public Button resetBtn;
    public Button backBtn;

    public Text text;
    private string title;

    void Start()
    {
        prepareLayout();

        title = "Most bounces: ";
        refreshStats();
    }

    public void prepareLayout()
    {
        resetBtn.transform.position = LayoutMng.btnPosition2;
        backBtn.transform.position = LayoutMng.btnPosition3;
    }

    public void refreshStats()
    {
        text.text = title + HighScoreMng.highestBounces.ToString();
    }
}