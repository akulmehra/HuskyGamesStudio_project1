using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;

    public float startTimeBtwSpawn;
    public float timeBtwSpawn;

    void Start () {

        timeBtwSpawn = startTimeBtwSpawn;
	}
	
	// Update is called once per frame
	void Update () {

        int randomIndex = Random.Range(0, 5);

        if(timeBtwSpawn <= 0)
        {
            Instantiate(enemyPrefab, spawnPoints[randomIndex].transform.position, spawnPoints[randomIndex].transform.rotation);
            timeBtwSpawn = startTimeBtwSpawn;

        }else{
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
