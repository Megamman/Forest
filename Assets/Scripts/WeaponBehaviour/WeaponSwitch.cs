using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] Weapons;

    public Queue<GameObject> weaponSequence;

    public GameObject activeWeapon;

    public bool isReversed = false;

    public Transform attackPos;

    public Image Weapon;
    public Slider LoadWeapon;

    // Start is called before the first frame update
    void Start()
    {
        weaponSequence = new Queue<GameObject>(Weapons);
        activeWeapon = weaponSequence.Dequeue();
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

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (isReversed) weaponSequence = new Queue<GameObject>(weaponSequence.Reverse());
            isReversed = false;

            //when the scroll ir rolling the first one goes to the end and select the new first object
            weaponSequence.Enqueue(activeWeapon);
            activeWeapon = weaponSequence.Dequeue();
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (!isReversed) weaponSequence = new Queue<GameObject>(weaponSequence.Reverse());
            isReversed = true;

            //when the scroll ir rolling the first one goes to the end and select the new first object
            weaponSequence.Enqueue(activeWeapon);
            activeWeapon = weaponSequence.Dequeue();
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
