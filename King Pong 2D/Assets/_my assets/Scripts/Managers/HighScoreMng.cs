using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMng : MonoBehaviour
{
    public static int highestBounces;
    public HighScoreUI highScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        highestBounces = 0;
        loadData();
    }

    public void compareBounces (int bounces)
    {
        if (bounces > highestBounces)
        {
            highestBounces = bounces;
            highScoreUI.refreshStats();
        }
    }

    public void resetStatistics()
    {
        highestBounces = 0;
        highScoreUI.refreshStats(); //je to observer??
        saveData();
    }

    #region Load and save methods

    public void saveData()
    {
        SaveSystem.SaveData(this);
    }
    public void loadData()
    {
        GameData data = SaveSystem.loadGameData();
        compareBounces(data.highestBounces);

    }
    #endregion
}
