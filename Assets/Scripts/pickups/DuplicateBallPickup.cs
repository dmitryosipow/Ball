using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateBallPickup : MonoBehaviour
{
    public float sizeScale;
    void ApplyEffect()
    {
        Ball ball = FindObjectOfType<Ball>();
        ball.Duplicate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            ApplyEffect();
            Destroy(gameObject);
        }
    }
}
