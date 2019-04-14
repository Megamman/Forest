using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Range : MonoBehaviour
{
    public EnemyBehavior behavior;

    public Animator anim;

    public float stoppingDist;
    public float retreatDist;
    public float noise;
    public float startTimeBtwShots;
    private float timeBtwShots;

    public GameObject projectile;
    private Transform player;
    public Rigidbody2D rb2d;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Update();
        }
    }

    void Update ()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, behavior.worldSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDist && Vector2.Distance(transform.position, player.position) > retreatDist)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -behavior.worldSpeed * Time.deltaTime);
        }

        if(timeBtwShots <= 0)
        {
            anim.SetInteger("Spawn", 1);
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
            anim.SetInteger("Spawn", 0);
        }

        Vector2 pos = Random.insideUnitCircle * noise;
        transform.localPosition = Vector2.Lerp(transform.localPosition, pos, Time.deltaTime);

        rb2d.velocity = new Vector2();
    }


    //anim.SetInteger("Spawn", 1);
}
