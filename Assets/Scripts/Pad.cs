using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    Ball ball;
    public bool isStarted;
    float yPosition;
    GameManager gameManager;

    [Header("Magnet effect")]
    public GameObject magnetEffect;

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

            mouseWorldPosition.x = Mathf.Clamp(mouseWorldPosition.x, -7.4f, 7.4f);

            var pos = transform.position;
            pos.x = mouseWorldPosition.x;

            transform.position = pos;
        }
        
    }

    public void ActivateMagnet(bool active, float duration = 1f)
    {
        magnetEffect.SetActive(active);

        if(active)
        {
            StartCoroutine(StopMagnetAfterDelay(duration));
        }
    }

    IEnumerator StopMagnetAfterDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        ActivateMagnet(false);
    }

    public void ChangeSize(float sizeScale)
    {
        transform.localScale = new Vector2(sizeScale, 1);
    }
}