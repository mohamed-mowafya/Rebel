using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Wilberforce;

public class Player : MonoBehaviour
{
    [Header("Player movement")]
    [SerializeField] private float runSpeed = 6f;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private int dommage = 60;
    public static int coins = 150;
   // [SerializeField] private List<AnimationClip> attackAnimations;
    [Header("Sound Effects")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField][Range(0,1)] private float jumpSoundVolume = 0.25f;
    [SerializeField] [Range(0, 1)] private float deathSoundVolume = 0.25f;


    



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

        if (!isAlive) { return; }
        
        Run();
        FlipSprite();
        Jump();
       // Attack();
        CoinNumber();
        Death();
       
        // GetComponent<Rigidbody2D>().rotation = 0f;
    }
    
   // private void OnCollisionStay2D(Collision2D other)
  // {
   ///     GameObject otherObject = other.gameObject;
    //    StartCoroutine(TimeBetweenAttacks(otherObject));
   // }

    IEnumerator TimeBetweenAttacks(GameObject other)
    {
        if (!other.GetComponent<ennemie>())
        {
            yield return new WaitForSeconds(0f);
        }
        
        else if (other.GetComponent<ennemie>())
        {
            yield return new WaitForSeconds(1.5f);
            other.GetComponent<ennemie>().BeingAttacked();
        }
       
        
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

    private void DeathSound()
    {
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
       
    }


    private void Jump()
    {
       
        
        if (Input.GetButtonDown("Jump") && myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")) 
                                        && !myCollider2D.IsTouchingLayers(LayerMask.GetMask("Spring")))
        {
           
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            GetComponent<Rigidbody2D>().velocity += jumpVelocity;
            PlayJumpSound();
        }
    }


    private void Death()
    {

        if (myCollider2D.IsTouchingLayers(LayerMask.GetMask("Water")))
        {
            DeathSound();
            StartCoroutine(DeathAnimation());
            isAlive = false;
        }
        else if (coins <= 0)
        {
            DeathSound();
            StartCoroutine(DeathAnimation());
            isAlive = false;
        }

    }

    IEnumerator DeathAnimation()
    {
        myAnimator.SetBool("Die", true);
        yield return new WaitForSeconds(0.85f);
        Destroy(gameObject);  
       // SceneManager.LoadScene(4); Game Over
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
