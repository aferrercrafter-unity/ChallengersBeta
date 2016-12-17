﻿using UnityEngine;
using System.Collections;

public class WizardLife : MonoBehaviour {

    GameObject manager;
    int life = 1;

	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("Manager");
	}
	
	// Update is called once per frame
	void Update () {

        if(transform.position.y < -1)
            manager.SendMessage("Lost");

    }

    void OnTriggerEnter(Collider col)
    {
        print(col.gameObject.name);
        if (col.gameObject.CompareTag("EnemyWeapon"))
        {
            life--;
            if(life <= 0)
            {
                manager.SendMessage("Lost");
            }
        }
    }
}
