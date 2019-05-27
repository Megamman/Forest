using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    private float fullHealth;

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
            if (slider != null) slider.value = 1.0f * (_health / fullHealth);
            if (HPText != null) HPText.text = string.Format("{0}/{1}", _health, fullHealth);
        }
    }

    public Slider slider;

    public Text HPText;

    public GameObject lostMenu;

    public int healthRand;

    void Start()
    {
        healthRand = Random.Range(5, 12);

        CurrentHealth = healthRand;
        fullHealth = CurrentHealth;

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

        if (fullHealth < CurrentHealth)
        {
            CurrentHealth = fullHealth;
        }        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HPPotion")
        {
            //if(health < fullHealth)
            //{
            CurrentHealth += 5;
            //}
            Destroy(other.gameObject);
        }

        if (other.tag == "Hearth")
        {
            Destroy(other.gameObject);
            CurrentHealth += 1;
            fullHealth += 1;

        }
    }

    public void TakeDamage(int damage)
    {
        if (healthRand > 10)
        {
            damage *= 3;
        }
        else if (healthRand > 7)
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
