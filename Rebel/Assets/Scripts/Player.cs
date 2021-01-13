using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wilberforce;

public class Player : MonoBehaviour
{
    [Header("Player movement")]
    [SerializeField] private float runSpeed = 3f;
    [SerializeField] private float jumpSpeed = 10f;

     public int coins = 0;
   // [SerializeField] private List<AnimationClip> attackAnimations;
    [Header("Sound Effects")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField][Range(0,1)] private float jumpSoundVolume = 0.25f;


    private Animator myAnimator;
    private Collider2D myCollider2D;
    private bool isAlive = true;
    private float climbSpeed = 1f;
    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        Run();
        FlipSprite();
        Jump();
        Attack();
        CoinNumber();
       
        // GetComponent<Rigidbody2D>().rotation = 0f;
    }

    public int CoinNumber()
    {
        return coins;
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            myAnimator.SetBool("Attacking", true);
            StartCoroutine(WaitForAnimation());
        }
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        myAnimator.SetBool("Attacking", false);
    }
    private void Run()
    {
        float controlThrow  =  Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed ,GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);

    }


    private void PlayJumpSound()
    {
        AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position, jumpSoundVolume);
    }


    private void Jump()
    {
       
        
        if (Input.GetButtonDown("Jump") && myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")) 
                                        && !myCollider2D.IsTouchingLayers(LayerMask.GetMask("Spring")))
        {
           
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            GetComponent<Rigidbody2D>().velocity += jumpVelocity;
            AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position, jumpSoundVolume);
        }
    }
    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > Mathf.Epsilon; // if greater than 0
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x),1f);
        }
    }

}
