using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodePickup : MonoBehaviour
{
    public int points;

    void ApplyEffect()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball bal in balls)
        {
            bal.ActivateExplode();
        }
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
