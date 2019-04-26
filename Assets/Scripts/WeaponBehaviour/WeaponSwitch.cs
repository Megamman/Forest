using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] Weapons;

    public Queue<GameObject> weaponSequence;

    public GameObject activeWeapon;

    public bool isReversed = false;

    public Transform attackPos;

    // Start is called before the first frame update
    void Start()
    {
        weaponSequence = new Queue<GameObject>(Weapons);
        activeWeapon = weaponSequence.Dequeue();
        //activeAttack = activeWeapon.GetComponent<Weapon>().Attack();
    }

    // Update is called once per frame
    void Update()
    {
        activeWeapon.GetComponent<Weapon>().Timer();

        if (Input.GetMouseButtonDown(0))
        {
            activeWeapon.GetComponent<Weapon>().Attack();
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
        // if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        // {
        //     i--;
        // }
    }
}
