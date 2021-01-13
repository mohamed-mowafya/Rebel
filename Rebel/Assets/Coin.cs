using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;
    [SerializeField] public int scorePerCoin = 10;

    private void OnCollisionEnter2D(Collision2D other)
    {
        AudioSource.PlayClipAtPoint(coinSound,transform.position);
        FindObjectOfType<Player>().coins +=scorePerCoin;
        Destroy(gameObject);
    }
}
