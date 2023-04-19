using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Vector2 startPos; //pořáteční pozice paddlu
    public float paddleOffset; //offset jak mají být paddlydaleko od okrajů

    public float speed; //rychlost padlu
    public float height; //výška paddlu

    string input; //název vstupu pro paddle
    public bool isRight; //příznak, zda je paddle napravo

    void Start()
    {
        startPos = transform.position; //získání počáteční pozice
        height = transform.localScale.y; //získání výšky paddlu

        VariablesCheck(); //kontrola proměnných
    }

    void Update()
    {
        //velikost pohybu
        float move = Input.GetAxisRaw(input) * speed * Time.deltaTime; 

         //podmínky aby nemohl paddle vyjet z pole
        if (transform.position.y < GameMng.bottomLeft.y + height/2 && move < 0)
        {
            move = 0;
        }

        if (transform.position.y > GameMng.topRight.y - height / 2 && move > 0) 
        {
            move = 0;
        }

        //posunutí paddlu
        transform.Translate(Vector2.up * move);

    }

    public void Prepare(bool isRightPaddle)
    {
        isRight = isRightPaddle;

        Vector2 pos = Vector2.zero;

        if (isRightPaddle)
        {
            pos = new Vector2(GameMng.topRight.x, 0);
            pos = pos - Vector2.right * transform.localScale.x - new Vector2(1,0) * paddleOffset;

            input = "paddleRight";
        } 
        else
        {
            pos = new Vector2(GameMng.bottomLeft.x, 0);
            pos = pos + Vector2.right * transform.localScale.x + new Vector2(1, 0) * paddleOffset;

            input = "paddleLeft";
        }

        transform.position = pos;

        transform.name = input;
    }

    private void VariablesCheck()
    {
        if (speed == 0)
        {
            Debug.Log("speed je nula");
        }
        if (height == 0)
        {
            Debug.Log("height je nula");
        }
        if (input == "" || input == null)
        {
            Debug.Log("input je nula");
        }
    }

    public void reset ()
    {
        transform.position = startPos;
    }
}
