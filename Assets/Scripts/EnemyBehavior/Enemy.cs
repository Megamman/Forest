using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Input of behavior and stats
    public EnemyBehavior behavior;

    public GameObject attackArea;

    //If rangeAttack = True
    public GameObject projectile;

    [SerializeField]
    private Transform enemyGraphic;

    private Transform player;

    public Animator anim;

    public Rigidbody2D rb2d;

    public SpriteRenderer renderer;

    private int health;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        health = behavior.health;

        attackArea.SetActive(false);

    }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Health();

        float move = Input.GetAxis("Horizontal");

        renderer.flipX = move < 0;

        behavior.timeAttack -= Time.deltaTime;
        if (behavior.timeAttack < 0)
        {
            behavior.timeAttack = behavior.startTimeBtwAttack;
        }
        
        if (behavior.noise)
        {
            Vector2 pos = Random.insideUnitCircle * behavior.noiseAmount;
            enemyGraphic.localPosition = Vector2.Lerp(enemyGraphic.localPosition, pos, Time.deltaTime);
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        anim.SetInteger("Idle", behavior.animIdle);
        Debug.Log("idle");
    }

    void Move()
    {

        if (Vector2.Distance(transform.position, player.position) > behavior.stoppingDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, behavior.speed * Time.deltaTime);
            Attack();
            
        }
        else if (Vector2.Distance(transform.position, player.position) < behavior.retreatDist) 
        {

            transform.position = Vector2.MoveTowards(transform.position, player.position, -behavior.speed * Time.deltaTime);
            
        }
        

        rb2d.velocity = new Vector2();
    }


    // Update is called once per frame
    void Attack()
    {

        if (behavior.rangeAttack)
        {

            if (behavior.timeAttack <= 0)
            {
                // this is when the enemie attacks
                anim.SetInteger("Idle", behavior.animRange);
                Instantiate(projectile, transform.position, Quaternion.identity);
                behavior.timeAttack = behavior.startTimeBtwAttack;
            }
            else if (behavior.timeAttack > 0)
            {
                behavior.timeAttack -= Time.deltaTime;
                anim.SetInteger("Idle", behavior.animIdle);
            }
        }

        if (behavior.meleeAttack)
        {
            if (behavior.timeAttack <= 0)
            {
                Debug.Log("start ATTACK");
                attackArea.SetActive(true);
                // this is when the enemie attacks
                behavior.timeAttack -= Time.deltaTime;
                anim.SetInteger("Idle", behavior.animMelee);
                behavior.timeAttack = behavior.startTimeBtwAttack;
            }
            else
            {
                Debug.Log("start timer");
                attackArea.SetActive(false);
                behavior.timeAttack -= Time.deltaTime;
                anim.SetInteger("Idle", behavior.animIdle);
            }
        }
        
    }

    void Health()
    {
        if(behavior.health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
