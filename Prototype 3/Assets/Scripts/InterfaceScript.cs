using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceScript : MonoBehaviour
{
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScore()
    {
        Debug.Log("Your score : " + score);
    }

    public void IncreaseScore(int toAdd)
    {
        score += toAdd;
        DisplayScore();
    }

    public void DisplayGameOver()
    {
        Debug.Log("Game Over!");
        Debug.Log("Final score : " + score);
    }
}
