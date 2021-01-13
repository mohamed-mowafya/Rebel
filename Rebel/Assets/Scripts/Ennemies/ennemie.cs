using UnityEngine;

public class ennemie : MonoBehaviour
{

    [Header("Ennemie Settings")]
    [Range(0f, 5f)] [SerializeField] private float currentSpeed = 0f;
    private Player target;
    [SerializeField] private GameObject body;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip attackSound;
    [SerializeField] [Range(0, 1)] private float attackSoundVolume = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Faire le personage bouger.
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAttackState();
    }

    //Permet dde faire le personage ne pas bouger ou recomancer a bouger.
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    //Faire l'attack s'il y a une collision avec le player.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<Player>())
        {
            Attack(otherObject.GetComponent<Player>());
        }
        else
        {
            ChangeSide();
        }

    }

    //Sert pour que le enemie ne sort pas de l'écran ou depasse un autre objet si on veut.
    private void ChangeSide()
    {
        if (body.GetComponent<SpriteRenderer>().flipX)
        {
            body.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            body.GetComponent<SpriteRenderer>().flipX = true;

        }
        currentSpeed *= -1;
    }

    //Changer l'animation pour l'attack
    public void Attack(Player player)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        target = player;
    }

    //Si le player fuit il faut arreter de attacker.
    private void UpdateAttackState()
    {
        if (target)
        {
            if (Mathf.Abs(target.GetComponent<Transform>().position.x - GetComponent<Transform>().position.x) > 5) //usually is 3. something
            {
                GetComponent<Animator>().SetBool("IsAttacking", false);
            }
        }
        return;

    }


    public void StrikeCurrentTarget(float damage)
    {
        if (!target)
        {
            return;
        }
        else
        {
            Debug.Log("Damage");
            PlayAttackSound();

        }

       /* Health health = target.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }*/
    }



    private void PlayAttackSound()
    {
        AudioSource.PlayClipAtPoint(attackSound, Camera.main.transform.position, attackSoundVolume);
    }

}
