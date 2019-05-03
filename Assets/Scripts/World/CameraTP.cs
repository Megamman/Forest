using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTP : MonoBehaviour
{
    public Transform cameraPos;
    public GameObject Camera;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Camera.transform.position = this.transform.position;
        }
    }
}
