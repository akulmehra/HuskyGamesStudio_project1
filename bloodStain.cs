using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodStain : MonoBehaviour {

    public float lifeTime;

	// Use this for initialization
	void Start () {

        Invoke("DestroyStain", lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DestroyStain()
    {
        Destroy(gameObject);
    }
}
