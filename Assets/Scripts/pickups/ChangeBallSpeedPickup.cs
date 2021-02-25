using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBallSpeedPickup : MonoBehaviour
{
    public float koof;
    void ApplyEffect()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball bal in balls)
        {
            bal.ChangeSpeed(koof);
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
