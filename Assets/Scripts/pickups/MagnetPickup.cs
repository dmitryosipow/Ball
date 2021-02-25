using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPickup : MonoBehaviour
{
    float duration = 10f;
    void ApplyEffect()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball bal in balls)
        {
            bal.ActivateMagnet(true, duration);
        }

        Pad pad = FindObjectOfType<Pad>();
        pad.ActivateMagnet(true, duration);
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
