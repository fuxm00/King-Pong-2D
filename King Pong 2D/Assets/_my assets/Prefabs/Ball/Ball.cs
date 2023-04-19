using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startSpeed;
    public float currentSpeed;
    public float height;
    public float angleOfBallBounce;

    public HighScoreMng highScore;

    private GameMng gameManager;
    public bool isHotPotato;
    public float hotPotatoMultiplier;

    private Vector2 startPos;

    private Vector2 direction;
    public ScoreBoardMng scoreBoardMng;

    void Start()
    {
        Launch(true);
        startPos = transform.position;
        height = transform.localScale.x / 2;

        gameManager = FindObjectOfType<GameMng>();
        highScore = FindObjectOfType<HighScoreMng>();
        scoreBoardMng = FindObjectOfType<ScoreBoardMng>();

        VariablesCheck();
    }
    
    void FixedUpdate()
    {
        transform.Translate(direction * currentSpeed * Time.deltaTime);

        if (transform.position.y < GameMng.bottomLeft.y + height && direction.y < 0)
        {
            BounceFromWall();
        }

        if (transform.position.y > GameMng.topRight.y - height && direction.y > 0)
        {
            BounceFromWall();
        }

        if (transform.position.x < GameMng.bottomLeft.x + height && direction.x < 0)
        {
            //Debug.Log("Right player wins!");
            playerScored(true);
        }

        if (transform.position.x > GameMng.topRight.x - height && direction.x > 0)
        {
            //Debug.Log("Left player wins!");
            playerScored(false);
        }
    }

    private void playerScored(bool isRightPlayer)
    {
        FindObjectOfType<HighScoreMng>().compareBounces(scoreBoardMng.bounceCount);
        scoreBoardMng.increaseScore(isRightPlayer);
        SaveSystem.SaveData(highScore);
    }

    private void BounceFromWall()
    {
        FlipDirection(false);
        FindObjectOfType<AudioMng>().play("blip2");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle")
        {
            FindObjectOfType<AudioMng>().play("blip1");
            bool isRight = other.GetComponent<Paddle>().isRight;

            if (isRight == true && direction.x > 0)
            {
                BounceFromPaddle(other);
            }

            if (isRight == false && direction.x < 0)
            {
                BounceFromPaddle(other);
            }

            if (isHotPotato)
            {
                currentSpeed = currentSpeed * hotPotatoMultiplier;
            }
        }
    }

    private void BounceFromPaddle(Collider2D other)
    {
        ChangeDirection(other);
        scoreBoardMng.increaseBounceCount();
    }

    private void ChangeDirection(Collider2D other)
    {
        float z = (transform.position.y - other.transform.position.y) / other.GetComponent<Paddle>().height;

        BounceAtAngle(z);
        FlipDirection(true);
    }

    private void FlipDirection(bool vertically)
    {
        if (vertically == true)
        {
            direction.x = -direction.x;
        }
        else
        {
            direction.y = -direction.y;
        }

    }

    private void VariablesCheck()
    {
        if (startSpeed == 0)
        {
            Debug.Log("startSpeed je nula");
        }
        if (hotPotatoMultiplier == 0)
        {
            Debug.Log("hotPotatoMultiplier je nula");
        }
        if (height == 0)
        {
            Debug.Log("radius je nula");
        }
        if (angleOfBallBounce == 0)
        {
            Debug.Log("angleOfBoiunce je nula");
        }
    }

    public void ResetBall()
    {
        transform.position = startPos;
        currentSpeed = startSpeed;
        Launch(true);
    }

    private void Launch(bool ramdomly)
    {
        if (ramdomly == true)
        {
            float x;
            float y;
            int random = Random.Range(0, 2);
            switch (random)
            {
                case 0:
                    x = 1;
                    y = 1;
                    break;
                case 1:
                    x = 1;
                    y = -1;
                    break;
                default:
                    x = 1;
                    y = 1;
                    Debug.LogError("Random number was out of bounds.");
                    break;
            }

            if (random == 0)
            {
                x = x * -1;
                y = y * -1;
            }

            Vector2 vec = new Vector2(x, y);
            direction = vec.normalized;
        }

        else
        {
            direction = new Vector2(1, 0).normalized;
        }
    }

    private void BounceAtAngle(float distance)
    {
        float x = direction.x;
        float y = distance * angleOfBallBounce;

        direction = new Vector2(x, y).normalized;
    }
}
