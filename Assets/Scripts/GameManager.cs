using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public HealthBar healthBar;
    public Text scoreText;
    int score;
    public int currentHealth;

    public GameObject pausePanel;
    public bool pauseActive;

    private void Awake()
    {
        GameManager[] gameManagers = FindObjectsOfType<GameManager>();
        for (int i = 0; i < gameManagers.Length; i++)
        {
            if (gameManagers[i].gameObject != gameObject)
            {
                Destroy(gameObject);
                break;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        print("start " + currentHealth);
        SetPause(false);
        RestartLevel();
        DontDestroyOnLoad(gameObject);
        UpdateScore(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetPause(!pauseActive);
        }
    }

    void SetPause(bool pause)
    {
        pausePanel.SetActive(pause);
        Time.timeScale = pause ? 0f : 1f;
        pauseActive = pause;
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = score.ToString();
    }

    public void DecreaseHealth()
    {
        print("curr health " + currentHealth);
        currentHealth--;
        healthBar.currentHealth = currentHealth;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Finish");
        }
    }

    public void RestartLevel()
    {
        currentHealth = 3;
        healthBar.currentHealth = currentHealth;
    }
}
