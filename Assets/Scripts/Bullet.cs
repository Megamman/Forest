using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	float moveSpeed = 7f;

	Rigidbody2D rb;

    public Transform target;
	public Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		moveDirection = (target.transform.position);
		rb.velocity = new Vector3 (moveDirection.x, moveDirection.y);
		Destroy (gameObject, 3f);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name.Equals ("Player")) {
			Debug.Log ("Hit!");
			Destroy (gameObject);
		}
	}

}
