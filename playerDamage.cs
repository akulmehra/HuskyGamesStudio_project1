using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour {

    public int health;
    public int meleeDamage;
    public int bulletDamage;

    public GameObject hitParticle;
    public GameObject destroyParticle;

    Rigidbody2D rb;
    public float pushForce;
    // Use this for initialization
    void Start () {

        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(health <= 0)
        {
            Instantiate(destroyParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            takeDamage(meleeDamage);
            rb.AddForce(collision.gameObject.transform.up * pushForce * Time.deltaTime);
           
        }
        if (collision.gameObject.tag == "enemyBullet")
        {
            takeDamage(bulletDamage);
            Instantiate(hitParticle, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "healthPack")
        {
            health += 10;
            Destroy(collision.gameObject);
        }
    }

    void takeDamage(int damage)
    {
        health -= damage;
    }
}
