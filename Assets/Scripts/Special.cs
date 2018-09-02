using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : MonoBehaviour {

    //dont need to check what its on as damage is the same for all (at the moment, might change later)

    float damage = 1f;
    Enemy enemy;

	void Start () {
		
	}
	

	void Update () {
		
	}

    //void OnTriggerStay2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "Enemy")
    //    {
    //        PlayerController upgrades = GameObject.Find("Player").GetComponent<PlayerController>();
    //        float health = col.GetComponent<Enemy>().health;
    //        if (upgrades.spec == 1)
    //        {
    //            enemy.health -= 100 * Time.deltaTime;
    //        }
    //        else if (upgrades.spec == 2)
    //        {
    //            enemy.health -= 120 * Time.deltaTime;
    //        }
    //        else if (upgrades.spec == 3)
    //        {
    //            enemy.health -= 150 * Time.deltaTime;
    //        }
    //        enemy = col.gameObject.GetComponent<Enemy>();
            
    //    }
        
        
    //}
}
