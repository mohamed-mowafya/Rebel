using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMarcher : MonoBehaviour

{
    [Header("Player movement")]
    [SerializeField] private float runSpeed = 4f;
    
 


    private Animator myAnimator;
    private Collider2D myCollider2D;
    private bool isAlive = true;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
        
    }

    void Update()
    {

        if (!isAlive) { return; }

        Run();
    }

    
    private void Run()
    {
       // float controlThrow = 1;
        Vector2 playerVelocity = new Vector2(runSpeed, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().velocity = playerVelocity;
        myAnimator.SetBool("Running", true);

  
        if (GetComponent<Rigidbody2D>().position.x == -3.5)
        {

            runSpeed = 0f;
            myAnimator.SetBool("Running", false);
        }

    }
}

