using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLivePickup : MonoBehaviour
{
    public int deltaAdd;
    void ApplyEffect()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        gm.ChangeHealth(deltaAdd);
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
