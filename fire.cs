using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {

    public Transform firePos;
    public float startTimeBtwShoot;
    float timeBtwShoot;
    public GameObject bullet;
    public GameObject grenade;

    public int ammo = 200;
    public int numOfGrenades = 10;

    public AudioSource audioSource;


	void Start () {
        
        timeBtwShoot = startTimeBtwShoot;
        audioSource = gameObject.GetComponent<AudioSource>();

	}
	
	
	void Update () {
		
        if(timeBtwShoot<=0)
        {
            //shoot
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (ammo > 0)
                {
                    Shoot();
                }
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (numOfGrenades > 0)
                {
                    Grenade();
                }
            }
            timeBtwShoot = startTimeBtwShoot;
        }
        else
        {
            timeBtwShoot -= Time.deltaTime;
        }

	}

    void Shoot()
    {
        Instantiate(bullet, firePos.position, transform.rotation);
        ammo--; 
        audioSource.Play();
    }

    void Grenade()
    {
        Instantiate(grenade, transform.position, transform.rotation);
        numOfGrenades--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ammoPack")
        {
            ammo += 50;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "grenadePack")
        {
            numOfGrenades += 5;
            Destroy(collision.gameObject);
        }
    }
}
