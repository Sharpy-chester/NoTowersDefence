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
    Upgrades upgrades;
    public GameObject upgradesObj;
    public int proj;
    public int spec;
    float bulletDamage;
    float bulletSpeed;
    float bulletSize;
    float specDamage;
    public GameObject waterBarrage;
    GameObject thisWaterBarrage;
    bool isSpec;

	void Start () {
        mainControllerObj = GameObject.Find("MainController");
        mainController = mainControllerObj.GetComponent<MainController>();
        upgrades = upgradesObj.GetComponent<Upgrades>();
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
        if (isSpec)
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            thisWaterBarrage.transform.LookAt(new Vector3(target.x, target.y, 0));
            
        }
        
    }

    void Shoot()
    {
        proj = upgrades.proj;
        spec = upgrades.spec;
        bulletCooldown += Time.deltaTime;
        if (bulletCooldown >= maxBulletCooldown && Time.timeScale == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (proj == 0)
                {
                    bulletSpeed = 3;
                    bulletDamage = 5;
                    bulletSize = 1;
                }
                if (proj == 1)
                {
                    bulletSpeed = 5;
                    bulletDamage = 7;
                    bulletSize = 1.2f;
                }
                if (proj == 2)
                {
                    bulletSpeed = 8;
                    bulletDamage = 9;
                    bulletSize = 1.4f;
                }
                if (proj == 3)
                {
                    bulletSpeed = 10;
                    bulletDamage = 12;
                    bulletSize = 1.6f;
                }
                GameObject bullet = Instantiate(bulletPre, this.transform.position, this.transform.rotation);
                bullet.GetComponent<BulletController>().damage = bulletDamage;
                bullet.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
                bullet.transform.localScale = new Vector3(bulletSize, bulletSize, bulletSize);
                bulletCooldown = 0;
            }
            
        }
        if (Input.GetMouseButtonDown(1) && spec > 0)
        {
            isSpec = true;
            thisWaterBarrage = Instantiate(waterBarrage, this.transform.position, this.transform.rotation);
            thisWaterBarrage.transform.SetParent(this.gameObject.transform);
            thisWaterBarrage.transform.localEulerAngles = new Vector3(0, 90, 0);

            

            if (spec == 1)
            {

            }
            if (spec == 2)
            {

            }
            if (spec == 3)
            {

            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            isSpec = false;
            Destroy(thisWaterBarrage);
        }
    }
}
