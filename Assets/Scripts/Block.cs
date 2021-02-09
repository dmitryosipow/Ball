using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Tooltip("Hits before destroy")]
    public int hits;
    [Tooltip("Points after destroy")]
    public int points;
    public Sprite spriteLightDamage;
    public Sprite spriteHeavyDamage;
    SpriteRenderer spriteRenderer;
    LevelChanger levelChanger;
    GameManager gameManager;


    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        levelChanger = FindObjectOfType<LevelChanger>();
        levelChanger.BlockCreated();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hits--;

        if (hits == 2)
        {
            spriteRenderer.sprite = spriteLightDamage;
        }
        else if (hits == 1)
        {
            spriteRenderer.sprite = spriteHeavyDamage;
        }

        if(hits <= 0)
        {
            gameManager.UpdateScore(points);
            levelChanger.BlockDestroyed();
            Destroy(gameObject);
        }

    }
}
