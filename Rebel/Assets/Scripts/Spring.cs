using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private Player playerPrefab;
    private Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
        playerPrefab.GetComponent<Rigidbody2D>().velocity +=jumpVelocity;
        myAnimator.SetBool("Spring", true);
        StartCoroutine(ExitAnimation());
    }

    IEnumerator ExitAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        myAnimator.SetBool("Spring", false);
    }
    
}
