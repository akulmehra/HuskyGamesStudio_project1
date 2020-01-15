using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {

    int score;
    int health;
    int ammoNum;
    int gren;
    public Text scoreText;
    public Text healthText;
    public Text ammo;
    public Text grenText;

    scoreManager()
    {
        score = 0;
    }
	
    void Start () {
		
	}
	
	
	void Update () 
    {
        health = GameObject.Find("player_Prefab").GetComponent<playerDamage>().health;
        ammoNum = GameObject.Find("player_Prefab").GetComponent<fire>().ammo;
        gren = GameObject.Find("player_Prefab").GetComponent<fire>().numOfGrenades;
        healthText.text = "Health: " + health.ToString();
        scoreText.text = "Kills: " + score.ToString();
        ammo.text = "Ammo: " + ammoNum.ToString();
        grenText.text = "Grenades: " + gren.ToString();
	}

    public void scoreUp()
    {
        score++;
    }

    int getScore()
    {
        return score;
    }
}
