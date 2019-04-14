using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Input of behavior and stats
    public EnemyBehavior behavior;

    //If rangeAttack = True
    public GameObject projectile;

    private Transform player;
    public Animator anim;
    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {

        behavior.timeAttack = behavior.startTimeBtwAttack;
        
    }

    void Update()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Move()
    {

        if (Vector2.Distance(transform.position, player.position) > behavior.stoppingDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, behavior.speed * Time.deltaTime);
            
        }
        /** else if (Vector2.Distance(transform.position, player.position) < behavior.stoppingDist && Vector2.Distance(transform.position, player.position) > behavior.retreatDist)
        {
            transform.position = this.transform.position;
        }*/
        else if (Vector2.Distance(transform.position, player.position) < behavior.retreatDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -behavior.speed * Time.deltaTime);
            Debug.Log("moving");
        }

        if (behavior.noise == true)
        {
            Vector2 pos = Random.insideUnitCircle * behavior.noiseAmount;
            transform.localPosition = Vector2.Lerp(transform.localPosition, pos, Time.deltaTime);
        }

        rb2d.velocity = new Vector2();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
            Move();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        anim.SetInteger("Idle", behavior.animIdle);
        Debug.Log("idle");
    }


    // Update is called once per frame
    void Attack()
    {

        if (behavior.rangeAttack == true)
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

        if (behavior.meleeAttack == true)
        {
            if (behavior.timeAttack <= 0)
            {
                // this is when the enemie attacks
                behavior.timeAttack -= Time.deltaTime;
                anim.SetInteger("Idle", behavior.animMelee);
                behavior.timeAttack = behavior.startTimeBtwAttack;
            }
            else
            {
                Debug.Log("start timer");
                behavior.timeAttack -= Time.deltaTime;
                anim.SetInteger("Idle", behavior.animIdle);
            }
        }
        
    }
}
