using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Range : MonoBehaviour
{
    public Animator anim;

    public float speed;
    public float stoppingDist;
    public float retreatDist;
    public float noise;
    public float startTimeBtwShots;
    private float timeBtwShots;

    public GameObject projectile;
    private Transform player;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    void Update ()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDist && Vector2.Distance(transform.position, player.position) > retreatDist)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
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
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Blade"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //anim.SetInteger("Spawn", 1);
}
