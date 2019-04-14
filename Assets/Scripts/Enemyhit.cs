using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhit : MonoBehaviour
{
    public float noise = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Random.insideUnitCircle * noise;
        transform.localPosition = Vector2.Lerp(transform.localPosition, pos, Time.deltaTime);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Blade"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
