using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePadScalePickup : MonoBehaviour
{
    public float sizeScale;
    void ApplyEffect()
    {
        Pad pad = FindObjectOfType<Pad>();

        pad.ChangeSize(sizeScale);
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
