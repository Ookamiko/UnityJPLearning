using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceLogic : MonoBehaviour
{
    public int startingLives = 3;

    private int lives;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        lives = startingLives > 0 ? startingLives : 1;
        DisplayLives();
        score = 0;
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayLives()
    {
        if (lives < 1)
        {
            Debug.Log("Death : Game Over !");
            lives = startingLives > 0 ? startingLives : 1;
            DisplayLives();
            score = 0;
            DisplayScore();
        } else
        {
            Debug.Log("You have " + lives + " lives !");
        }
    }

    public void LoseLive()
    {
        lives--;
        DisplayLives();
    }

    private void DisplayScore()
    {
        Debug.Log("Your score is " + score + " point(s) !");
    }

    public void AddScore(int point)
    {
        score += point;
        DisplayScore();
    }

    public void AddScore()
    {
        AddScore(1);
    }
}
