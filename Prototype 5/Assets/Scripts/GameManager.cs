using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public GameObject gameoverScreen;
    public GameObject titleScreen;

    private float spawnRate = 1.5f;
    private int score;
    
    public bool isGameover = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int difficultyFactor)
    {
        spawnRate /= difficultyFactor;
        scoreText.gameObject.SetActive(true);
        titleScreen.SetActive(false);
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScoreDisplay();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int value)
    {
        if (!isGameover)
        {
            score += value;
            UpdateScoreDisplay();
        }
    }

    public void GameOver()
    {
        isGameover = true;
        gameoverScreen.SetActive(true);
        StopCoroutine(SpawnTarget());
    }

    private IEnumerator SpawnTarget()
    {
        while(!isGameover)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
