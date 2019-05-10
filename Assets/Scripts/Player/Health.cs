using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public float fullHealth;

    public float health;

    public Slider slider;

    public Text HPText;

    void Start()
    {
        slider.maxValue = fullHealth;
        fullHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Healthslider());

        //demage =- health;

        if (health == 0)
        {
            //Destroy(gameObject);
        }

        if (fullHealth < health)
        {
            health = fullHealth;
        }

        HPText.text = health + "/" + fullHealth;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HPPotion")
        {
            //if(health < fullHealth)
            //{
            health += 5;
            //}
            Destroy(other.gameObject);
        }

        if (other.tag == "Hearth")
        {
            Destroy(other.gameObject);
            health += 1;
            fullHealth += 1;

        }
    }

    IEnumerator Healthslider()
    {
        // float progress = Mathf.Clamp01(health / .9f);

        slider.value = health;
        //progressText.text = progress * 100f + "%";

        yield return null;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        //anim.SetTrigger("Hit");

        if (health <= 0)
        {
            Destroy(gameObject, .3f);
            //anim.SetTrigger("Die");

        }
    }
}
