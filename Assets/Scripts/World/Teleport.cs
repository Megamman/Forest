using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform Dest;

    public void TeleportObject(GameObject player)
    {
        player.transform.position = Dest.transform.position;
    }
}
