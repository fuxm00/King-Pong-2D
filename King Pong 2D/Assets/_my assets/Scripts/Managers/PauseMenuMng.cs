using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuMng : MonoBehaviour
{
    [Header("Pause menu")]
    public GameObject pauseMenuUI;

    private GameMng gameManager;
    public bool gameIsPaused = false;

    void Start()
    {
        gameManager = FindObjectOfType<GameMng>();
        checkVariables();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&gameManager.playerIsPlaying)
        {
            if (gameIsPaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    public void resumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.visible = false;
        //FindObjectOfType<AudioManager>().play("pause2");
    }

    public void pauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.visible = true;
        FindObjectOfType<AudioMng>().play("pause");
    }

    private void checkVariables()
    {
        if (pauseMenuUI == null)
        {
            Debug.Log("pauseMenuUI je null");
        }

        if (gameManager == null)
        {
            Debug.Log("gameManager je null");
        }
    }
}
