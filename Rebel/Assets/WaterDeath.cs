using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDeath : MonoBehaviour
{
 [SerializeField] private AudioClip deathSound;

 private void OnCollisionEnter2D(Collision2D other)
 {
  AudioSource.PlayClipAtPoint(deathSound,transform.position);
  Destroy(other.gameObject);
 }
}
