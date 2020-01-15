using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeExplosion : MonoBehaviour {

    public float triggerTime;
    public float range;
    public float force;
    public float throwForce;

    public int grenadeDamage;
    public GameObject explosionPartice;

    public AudioSource grenadeSound;
	// Use this for initialization
	void Start () {

        grenadeSound = GameObject.Find("grenadeSound").GetComponent<AudioSource>();
        Invoke("Explode", triggerTime);
        Rigidbody2D rbGrenade = gameObject.GetComponent<Rigidbody2D>();
        rbGrenade.AddForce(transform.up * throwForce);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Explode()
    {
        grenadeSound.Play();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);

        Instantiate(explosionPartice, transform.position, transform.rotation);
        foreach(Collider2D nearbyObject in colliders)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if(rb!=null)
            {
                Vector2 direction = transform.position - nearbyObject.transform.position;
                rb.AddForce(-direction * force);

                nearbyObject.GetComponent<enemyAI>().takeDamage(grenadeDamage);
            }
        }

        Destroy(gameObject);
    }
}
