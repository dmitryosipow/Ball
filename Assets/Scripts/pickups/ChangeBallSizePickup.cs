using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBallSizePickup : MonoBehaviour
{
    public float sizeScale;
    void ApplyEffect()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball bal in balls)
        {
            bal.ChangeSize(sizeScale);
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
