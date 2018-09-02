using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 1f;
    public GameObject bulletPre;
    public float bulletCooldown = 0;
    public float maxBulletCooldown = 0.5f;
    GameObject mainControllerObj;
    MainController mainController;

	void Start () {
        mainControllerObj = GameObject.Find("MainController");
        mainController = mainControllerObj.GetComponent<MainController>();
    }
	

	void Update () {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
        }

        Shoot();

    }

    void Shoot()
    {
        bulletCooldown += Time.deltaTime;
        if (bulletCooldown >= maxBulletCooldown)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(bulletPre, this.transform.position, this.transform.rotation);
                bulletCooldown = 0;
            }
        }
        
    }
}
