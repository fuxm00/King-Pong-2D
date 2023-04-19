using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameUI : MonoBehaviour
{
    public Button startGameBtn;
    public Button quitGameBtn;
    public Button highScoreBtn;

    void Start()
    {
        prepareBtnLayout();
    }
   
    public void prepareBtnLayout()
    {
        startGameBtn.transform.position = LayoutMng.btnPosition1;
        quitGameBtn.transform.position = LayoutMng.btnPosition2;
        highScoreBtn.transform.position = LayoutMng.btnPosition3;
    }
}
