using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    public float speed;
    public float lifetime;
    public int damage;
    public GameObject player;

	void Start () {

        Invoke("DestroyProjectile", lifetime);
	}
	
	
	void Update () {

        transform.Translate(player.transform.up * speed * Time.deltaTime);
	}

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<enemyAI>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
