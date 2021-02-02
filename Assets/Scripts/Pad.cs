using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    Ball ball;
    public bool isStarted;
    float yPosition;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        yPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(isStarted)
        {
            Vector3 newPadPos = new Vector3(ball.transform.position.x, yPosition, 0);
            transform.position = newPadPos;
        }
        else
        {
            Vector3 mousePixelPoint = Input.mousePosition;

            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPoint);

            mouseWorldPosition.x = Mathf.Clamp(mouseWorldPosition.x, -7.29f, 7.29f);

            var pos = transform.position;
            pos.x = mouseWorldPosition.x;

            transform.position = pos;
        }
        
    }
}