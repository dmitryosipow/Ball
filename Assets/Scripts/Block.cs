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

    [Tooltip("Effects and prefabs")]
    public GameObject pickupPrefab;
    public GameObject particlePrefab;
    public bool invisible;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelChanger = FindObjectOfType<LevelChanger>();
        levelChanger.BlockCreated();
        gameManager = FindObjectOfType<GameManager>();

        if (invisible)
        {
            spriteRenderer.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (invisible)
        {
            spriteRenderer.enabled = true;
            invisible = false;
            return;
        }

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
            print("destroy on collision");
            DestroyBlock();
        }

    }

    public void DestroyBlock()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(points);
        levelChanger.BlockDestroyed();
        
        if (pickupPrefab)
        {
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);
        }
        if (particlePrefab)
        {
            Instantiate(particlePrefab, transform.position, Quaternion.identity);
        }
    }
}
