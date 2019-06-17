using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{


    private float _health;
    protected float CurrentHealth
    {
        get
        {
            return _health;
        }
        private set
        {
            _health = value;
            if (slider != null) slider.value = 1.0f * (_health / healthRand);
            if (HPText != null) HPText.text = string.Format("{0}/{1}", _health, healthRand);
        }
    }

    public Slider slider;

    public Text HPText;

    public GameObject lostMenu;

    public int healthRand;

    void Start()
    {
        healthRand = Random.Range(9, 16);

        CurrentHealth = healthRand;

        lostMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //demage =- health;

        if (CurrentHealth == 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            lostMenu.SetActive(true);
        }

        if (healthRand < CurrentHealth)
        {
            CurrentHealth = healthRand;
        }        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HPPotion")
        {
            //if(health < healthRand)
            //{
            CurrentHealth += 5;
            //}
            Destroy(other.gameObject);
        }

        if (other.tag == "Hearth")
        {
            Destroy(other.gameObject);
            healthRand += 1;
            CurrentHealth += 1;

        }
    }

    public void TakeDamage(int damage)
    {
        if (healthRand > 14)
        {
            damage *= 3;
        }
        else if (healthRand > 11)
        {
            damage *= 2;
        }

        CurrentHealth -= damage;
        //anim.SetTrigger("Hit");

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Destroy(gameObject, .3f);
            //anim.SetTrigger("Die");
            Invoke ("Death", 3);

        }
    }

    void Death()
    {
        Time.timeScale = 0;
        lostMenu.SetActive(true);
    }
}
