using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 5f;
    public GameObject[] path;
    public GameObject curPath;
    public int curPathInt;
    public float health;
    public float maxHealth;
    

	
	void Start () {
        path = GameObject.FindGameObjectsWithTag("Path");

        curPathInt = path.Length - 1;
        curPath = path[curPathInt];
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

        if (curPathInt > (path.Length -1))
        {
            Destroy(this.gameObject);
        }
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