using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTP : MonoBehaviour
{
    public GameObject camera;

    public void TeleportCamera()
    {
        camera.transform.position = this.transform.position;
    }
}
