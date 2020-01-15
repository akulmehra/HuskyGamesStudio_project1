using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {

    public int health;
    public GameObject target;
    public float moveSpeed = 20f;
    public Transform firePos;
    public GameObject enemyBullet;

    public float startTimeBtwShoot;
    public float timeBtwShoot;

    public float minDistance;

    public GameObject hitParticle;

    public GameObject[] bloodStains;
    public GameObject[] collectables;

    public AudioSource audSource;


	void Start () {

        timeBtwShoot = startTimeBtwShoot;
        target = GameObject.Find("player_Prefab");

        audSource = Camera.main.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
    void Update () {

        Vector2 direction = target.transform.position - transform.position;

        transform.up = direction;
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

        if(health <= 0)
        {
            Instantiate(hitParticle, transform.position, Quaternion.identity);
            GameObject.Find("scoreManager").GetComponent<scoreManager>().scoreUp();

            int rand = Random.Range(0, 3);
            float pitch = Random.Range(0.5f, 4);
            Instantiate(bloodStains[rand], transform.position, transform.rotation);
            audSource.pitch = pitch;

            audSource.Play();

            int r = Random.Range(0, 4);

            if(r==0)
            {
                Instantiate(collectables[rand], transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
	}

    public void takeDamage(int damage)
    {
        health -= damage;
    }
}
