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
    float speedCoeff = 1;
    Vector2 force;
    bool isStarted;

    float radius;
    float padHeight;
    float xDelta;
    GameManager gameManager;

    [Header("Параметры взрыва мяча")]
    public float explodeRadius;
    public GameObject explodeEffect;

    bool isMagnetActive;
    bool isExplode;

    [Header("Cлед мяча")]
    public TrailRenderer trail;

    private void Start()
    {
        score.Reset();
        Initialize();
    }
    private void Update()
    {
        if (transform.position.y <= -5.5f)
        {
            //SceneManager.LoadScene("Finish");
        }

        if (!isStarted)
        {
            transform.position = new Vector3(pad.transform.position.x + xDelta, pad.transform.position.y + radius + padHeight*0.5f, 0);
            if (Input.GetMouseButtonDown(0))
            {
                StartBall();
            }
        }
        else
        {
            rb.velocity = rb.velocity.normalized * speed * speedCoeff;
        }
    }

    void Initialize()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        radius = GetComponent<CircleCollider2D>().radius;
        padHeight = pad.GetComponent<BoxCollider2D>().size.y;
    }

    void StartBall()
    {
        force = (new Vector2(Random.Range(-1.0f, 1.0f), 1)).normalized * speed;
        /*print(force);
        rb.AddForce(force*speed);*/
        rb.velocity = force;
        isStarted = true;
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.DrawRay(transform.position, rb.velocity);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explodeRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            score.AddHit();

            if (isMagnetActive)
            {
                xDelta = transform.position.x - pad.transform.position.x;
                Restart();
            }
        }
        if (isExplode && collision.gameObject.CompareTag("block"))
        {
            print("yo");
            Explode();
        }
    }

    public void ActivateExplode()
    {
        isExplode = true;
        explodeEffect.SetActive(true);
    }

    public void ActivateMagnet(bool active, float duration = 1f)
    {
        isMagnetActive = active;

        if (active)
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
        transform.localScale = new Vector2(sizeScale, sizeScale);
        trail.startWidth = sizeScale;
    }

    public void ChangeSpeed(float koof)
    {
        speedCoeff = koof;
    }

    public void Restart()
    {
        isStarted = false;
    }

    void Explode()
    {
        int layerMask = LayerMask.GetMask("block");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explodeRadius, layerMask);
        foreach (Collider2D col in colliders)
        {
            Block block = col.GetComponent<Block>();
            if (block == null)
            {
                Destroy(gameObject);
            }
            else
            {
                print("destroy on explode");

                block.DestroyBlock();
            }
        }
    }

    public void Duplicate()
    {
        Ball originalBall = this;

        Ball newBall = Instantiate(originalBall);
        newBall.Initialize();
        newBall.speedCoeff = speedCoeff;
        newBall.StartBall();
        if (isMagnetActive)
        {
            newBall.ActivateMagnet(true);
        }
    }
}
