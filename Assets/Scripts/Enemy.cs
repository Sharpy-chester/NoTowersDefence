﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speed = 5f;
    public GameObject[] path;
    public GameObject curPath;
    public int curPathInt;
    public float health;
    public float maxHealth;
    public Image hpBar;
    MainController mainController;
    public GameObject mainControllerObj;
    int damage = 1;

	
	void Start () {

        
        
        curPathInt = path.Length - 1;
        curPath = path[curPathInt];
        
	}

    void Awake()
    {
        health = maxHealth;
        mainControllerObj = GameObject.Find("MainController");
        mainController = mainControllerObj.GetComponent<MainController>();
        
    }


    void Update () {
        curPath = path[curPathInt];
        if (this.transform.position == curPath.transform.position)
        {
            curPathInt--;
        }
        Vector3 curPathPos = curPath.transform.position;
        Vector3 thisPos = this.transform.position;
        this.transform.position = Vector3.MoveTowards(this.transform.position, curPathPos, speed * Time.deltaTime);

        if (curPathInt < (0))
        {

            mainController.hp--;
            Destroy(this.gameObject);
            
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        HealthBar();
	}

    void HealthBar()
    {
        float ratio = health / maxHealth;
        hpBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.name == "bullet(Clone)")
        {
            Destroy(collision.gameObject);
            BulletController bulletController = collision.GetComponent<BulletController>();
            health -= bulletController.damage;
        }
    }
}