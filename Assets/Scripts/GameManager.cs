﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public HealthBar healthBar;
    public Text scoreText;
    int score;
    int currentHealth;

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
        currentHealth = 3;
        healthBar.currentHealth = currentHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        UpdateScore(0);
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = score.ToString();
    }

    public void DecreaseHealth()
    {
        currentHealth--;
        healthBar.currentHealth = currentHealth;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Finish");
        }
    }
}
