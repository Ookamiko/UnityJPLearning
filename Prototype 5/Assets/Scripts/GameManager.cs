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
    public TextMeshProUGUI liveText;
    public GameObject gameoverScreen;
    public GameObject titleScreen;
    public AudioSource backgoundMusic;
    public Slider backgroundVolume;

    private float spawnRate = 1.5f;
    private int score;
    private int lives;
    
    public bool isGameover = false;

    // Start is called before the first frame update
    void Start()
    {
        backgroundVolume.onValueChanged.AddListener(UpdateVolume);
        UpdateVolume(backgroundVolume.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int difficultyFactor)
    {
        spawnRate /= difficultyFactor;
        scoreText.gameObject.SetActive(true);
        liveText.gameObject.SetActive(true);
        titleScreen.SetActive(false);
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScoreDisplay();
        lives = 3;
        UpdateLiveDisplay();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }

    private void UpdateLiveDisplay()
    {
        liveText.text = "Lives: " + lives;
    }

    private void UpdateVolume(float value)
    {
        backgoundMusic.volume = value;
    }

    public void AddScore(int value)
    {
        if (!isGameover)
        {
            score += value;
            UpdateScoreDisplay();
        }
    }

    public void LoseLive()
    {
        if (lives > 0)
        {
            lives--;
            UpdateLiveDisplay();

            if (lives < 1)
            {
                GameOver();
            }
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
