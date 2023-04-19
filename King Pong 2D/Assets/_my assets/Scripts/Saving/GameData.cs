using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int highestBounces;

    public GameData ()
    {
        highestBounces = HighScoreMng.highestBounces;
    }
}
