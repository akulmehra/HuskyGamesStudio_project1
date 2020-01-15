using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float moveSpeed;
    public Rigidbody2D rb;

	void Start () {

        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update () {

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); 
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.up * -moveSpeed * Time.deltaTime);
        }
		
	}
}
