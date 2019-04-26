using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] Weapons;

    public Transform attackPos;

    public int i;


    // Start is called before the first frame update
    void Start()
    {
        int i = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Weapons[i], attackPos.position, transform.rotation);
        }
    }

    /*void SelectWeapon()
    {
        Weapons(index) = i;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            i++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            i--;
        }
    } */
}
