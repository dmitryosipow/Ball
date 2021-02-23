using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    Ball ball;
    public bool isStarted;
    float yPosition;
    public GameManager gameManager;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameManager = FindObjectOfType<GameManager>();
        yPosition = transform.position.y;
    }

    
    void Update()
    {
        if (gameManager.pauseActive)
        {
            return;
        }

        if (isStarted)
        {
            Vector3 newPadPos = new Vector3(ball.transform.position.x, yPosition, 0);
            transform.position = newPadPos;
        }
        else
        {
            Vector3 mousePixelPoint = Input.mousePosition;

            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPoint);

            mouseWorldPosition.x = Mathf.Clamp(mouseWorldPosition.x, -4.29f, 4.29f);

            var pos = transform.position;
            pos.x = mouseWorldPosition.x;

            transform.position = pos;
        }
        
    }
}