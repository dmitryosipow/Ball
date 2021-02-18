using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    public Ball ball;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("ball"))
        {
            ball.Restart();
            gameManager.DecreaseHealth();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
