using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public ScoreSO score;
    public Pad pad;
    public int speed;
    Vector2 force = new Vector2(1,1);
    bool isStarted;

    float radius;
    float padHeight;

    private void Start()
    {
        score.Reset();
        rb = GetComponent<Rigidbody2D>();
        radius = GetComponent<CircleCollider2D>().radius;
        padHeight = pad.GetComponent<BoxCollider2D>().size.y;
    }
    private void Update()
    {
        if (transform.position.y <= -5.5f)
        {
            SceneManager.LoadScene("Finish");
        }

        if (!isStarted)
        {
            transform.position = new Vector3(pad.transform.position.x, pad.transform.position.y + radius + padHeight*0.5f, 0);
            if (Input.GetMouseButtonDown(0))
            {
                StartBall();
            }
        }
    }

    void StartBall()
    {
        rb.AddForce(force*speed);
        isStarted = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Hit");
        if(collision.gameObject.tag == "player")
        {
            score.AddHit();
        }  
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        print("Go out");
    }
}
