using System;
using System.Linq.Expressions;
using UnityEngine;
using System.Collections;

public class ennemie : MonoBehaviour
{
    [Header("Ennemie Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] public float health = 100f;
    [SerializeField] private int damageSubit = 20;
    [SerializeField] private int damageCause = 20;
    [SerializeField] private float delayTime = 0f;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip attackSound;
    [SerializeField] [Range(0, 1)] private float attackSoundVolume = 0.1f;
    [SerializeField] private AudioClip dieSound;
    [SerializeField] [Range(0, 1)] private float dieSoundVolume = 0.1f;

    //Cached components references
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;
    private Player player;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateAttackState();
        Walk();
    }

    public void SetMovementSpeed(float speed)
    {
        moveSpeed = speed;
    }
    
    
    //Verifier s'il y a collision avec le player.

    private void OnCollisionStay2D(Collision2D other)
    {
        StartCoroutine(TimeBetweenAttacks());

    }

    IEnumerator TimeBetweenAttacks()
    {
        Attack();
        Player.coins -= damageCause;
        yield return new WaitForSeconds(1f);
    }
    //Changer animation pour attack
    private void Attack()
    {
       
       myAnimator.SetBool("IsAttacking", true);
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(delayTime);
        Debug.Log("Delay time");
    }

    

    //Checker le bon cotê et la velocite
    private void Walk()
    {
        if (IsFacingRigth())
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    //Test si l'ennemi marche vers la droit ou gauche
    bool IsFacingRigth()
    {
        return transform.localScale.x < 0;
    }

    //Rotate le ennemi dans le x (droit ou gauche)
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }


    //TODO
    //Faire l'attack.
    public void StrikeCurrentTarget()
    {
        if (!player)
        {
            return;
        }
        else
        {
            //player.BeingAttacked(damageCause)
            PlayAttackSound();
        }

       
        
    }

    public void BeingAttacked()
    {
        myAnimator.SetBool("IsBeingAttacked", true);
        DealDamage(20);
    }

    //TODO talves colocar false logo apos no IsDying
    public void Die()
    {
        myAnimator.SetBool("IsDying", true);
        PlayDieSound();
    }

    public void DealDamage(int damage)
    {
        
        health -= damage;
        if (health <= 0)
        {
            Die();
            Destroy(gameObject);
        }

    }

    //TODO
    //VOIR SI ÇA MARCHE AVEC LE PLAYER
    private void UpdateAttackState()
    {
        if (player)
        {
            if (Mathf.Abs(player.GetComponent<Transform>().position.x - GetComponent<Transform>().position.x) > 5
            ) //usually is 3. something
            {
                GetComponent<Animator>().SetBool("IsAttacking", false);
            }
        }

        return;
    }

    //SOUND EFFECTS
    private void PlayAttackSound()
    {
        AudioSource.PlayClipAtPoint(attackSound, Camera.main.transform.position, attackSoundVolume);
    }

    private void PlayDieSound()
    {
        AudioSource.PlayClipAtPoint(dieSound, Camera.main.transform.position, dieSoundVolume);
    }
}
