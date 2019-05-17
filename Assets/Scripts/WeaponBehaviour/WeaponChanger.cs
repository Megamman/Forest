using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChanger : MonoBehaviour
{
    public GameObject[] Weapons;

    public GameObject activeWeapon;

    public Transform attackPos;

    public Image Weapon;
    public Slider LoadWeapon;

    // Start is called before the first frame update
    void Start()
    {
        int WeapRand = Random.Range(0, Weapons.Length);
        activeWeapon = Weapons[WeapRand];
        LoadWeapon.value = 0;
        //activeAttack = activeWeapon.GetComponent<Weapon>().Attack();
    }

    // Update is called once per frame
    void Update()
    {
        activeWeapon.GetComponent<Weapon>().Timer();

        if (Input.GetMouseButtonDown(0))
        {
            activeWeapon.GetComponent<Weapon>().Attack(this);
        }


        // if selected show icon on UI

        Weapon.sprite = activeWeapon.GetComponent<Weapon>().Icon;

        StartCoroutine(WeaponLoader());

    }

    IEnumerator WeaponLoader()
    {
        float weapTimer = activeWeapon.GetComponent<Weapon>().timeAttack;
        LoadWeapon.maxValue = activeWeapon.GetComponent<Weapon>().behavior.btwAttack;

        while (weapTimer > 0)
        {
            LoadWeapon.value = activeWeapon.GetComponent<Weapon>().timeAttack;

            yield return null;
        }

    }

    public void Attack()
    {
        Instantiate(activeWeapon, attackPos.position, transform.rotation);
    }
}
