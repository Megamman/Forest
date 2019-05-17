using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    private float fullHealth;

    private float health;

    public Slider slider;

    public Text HPText;

    public GameObject lostMenu;

    public int healthRand;

    public float totalDamage;

    void Start()
    {
        healthRand = Random.Range(5, 12);

        health = healthRand;
        fullHealth = health;

        lostMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Healthslider());

        slider.maxValue = health;

        //demage =- health;

        if (health == 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            lostMenu.SetActive(true);
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
        if (healthRand > 7 && 9 < healthRand)
        {
            totalDamage = damage * 2;
        }
        else if (healthRand > 10)
        {
            totalDamage = damage * 3;
        }

        health -= totalDamage;
        //anim.SetTrigger("Hit");

        if (health <= 0)
        {
            Destroy(gameObject, .3f);
            //anim.SetTrigger("Die");

        }
    }
}
