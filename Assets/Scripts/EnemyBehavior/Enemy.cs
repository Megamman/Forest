using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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

    public float health;

    private float timeAttack;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        health = behavior.health;

        

        //attackArea.SetActive(false);
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        float distFromPlayer = Vector2.Distance(transform.position, player.position);

        renderer.flipX = move < 0;

        if (timeAttack > 0) timeAttack -= Time.deltaTime;

        if (distFromPlayer < behavior.detectDist)
        {
            if (distFromPlayer > behavior.stoppingDist)
            {
                anim.SetInteger("Speed", 1);
                transform.position = Vector2.MoveTowards(transform.position, player.position, behavior.speed * Time.deltaTime);            
            }
            else if (distFromPlayer < behavior.retreatDist)
            {
                anim.SetInteger("Speed", 1);
                transform.position = Vector2.MoveTowards(transform.position, player.position, -behavior.speed * Time.deltaTime);
            }
            else
            {
                anim.SetInteger("Speed", 0);
                Attack();
            }
        }
        else
        {
            anim.SetInteger("Speed", 0);
        }

        if (behavior.noise)
        {
            Vector2 pos = Random.insideUnitCircle * behavior.noiseAmount;
            enemyGraphic.localPosition = Vector2.Lerp(enemyGraphic.localPosition, pos, Time.deltaTime);
        }
    }


    // Update is called once per frame
    void Attack()
    {

        if (timeAttack <= 0)
        {
            if (behavior.rangeAttack && behavior.meleeAttack)
            {
                int rand = Random.Range(0, 2);
                if (rand == 1)
                {
                    Debug.Log("Range ATTACK");
                    Instantiate(projectile, transform.position, Quaternion.identity);
                }
                if (rand == 2)
                {
                    Debug.Log("start ATTACK");
                    anim.SetTrigger("Melee Attack");
                }
            }

            if (behavior.rangeAttack && !behavior.meleeAttack)
            {
                Debug.Log("Range ATTACK");
                Instantiate(projectile, transform.position, Quaternion.identity);
            }

            if (behavior.meleeAttack && behavior.rangeAttack)
            {
                Debug.Log("start ATTACK");
                attackArea.SetActive(true);
                anim.SetTrigger("Melee Attack");
            }

            timeAttack = behavior.startTimeBtwAttack;
        }
        else
        {
            // if attackArea is not null, it will do the function.
            if (attackArea != null) attackArea.SetActive(false);
            anim.SetInteger("Speed", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Blade")
        {
            anim.SetTrigger("Hit");
            Debug.Log("Hit!!");

        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        // if no behavior on script, stop here.
        if (behavior == null) return;

        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, Vector3.forward, behavior.stoppingDist);
        
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, behavior.retreatDist);

        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, Vector3.forward, behavior.detectDist);
    }
#endif

}
