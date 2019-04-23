using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public float fullHealth;

    public float health;

    public Slider slider;

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
        
    }

    IEnumerator Healthslider()
    {
        // float progress = Mathf.Clamp01(health / .9f);

        slider.value = health;
        //progressText.text = progress * 100f + "%";

        yield return null;
    }
}
