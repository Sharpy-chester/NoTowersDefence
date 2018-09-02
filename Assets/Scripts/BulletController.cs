using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public Vector3 mouse;
    public Vector3 movetowards;
    public float bulletSpeed = 5;
    public Vector2 target;
    Vector2 direction;
    public float damage = 5f;

    void Awake()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float directionx = (this.transform.position.x - target.x);
        float directiony = (this.transform.position.y - target.y);
        direction = new Vector2(directionx, directiony).normalized;
    }


    void Update () {
        Vector3 dir = new Vector3 (direction.x, direction.y, 0);
        this.transform.position += -dir * bulletSpeed * Time.deltaTime;

        
    }

    

}
