using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {

    public Text blue;

    public Text green;

    public Text red;

    public Text yellow;

    public GameObject[] choice;
    bool chosen = false;
    public GameObject[] specials;
    
    public GameObject[] projectile;
    public int spec = 0;
    public int proj = 0;
    public Text creditText;
    public Text mainCreditText;
    public GameObject prices;

    //make it so that right click does special and left click does projectile

    void Start()
    {
        prices.SetActive(false);
        
    }
    void Awake()
    {
        specials = GameObject.FindGameObjectsWithTag("Special");
        projectile = GameObject.FindGameObjectsWithTag("Projectiles");
        foreach (GameObject i in specials)
        {
            i.gameObject.SetActive(false);
        }
        foreach (GameObject i in projectile)
        {
            i.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        creditText.text = mainCreditText.text;
        if (chosen)
        {
            

            foreach (GameObject i in specials)
            {
                i.gameObject.SetActive(true);
            }
            foreach (GameObject i in projectile)
            {
                i.gameObject.SetActive(true);
            }
            prices.SetActive(true);
            chosen = false;
        }
        

        for (int i = 0; i < specials.Length; i++)
        {
            if (spec < specials.Length)
            {
                if (specials[i] != specials[spec])
                {
                    Button specBtn = specials[i].GetComponent<Button>();
                    specBtn.enabled = false;
                }
                else if (specials[i] == specials[spec])
                {
                    Button specBtn = specials[i].GetComponent<Button>();
                    specBtn.enabled = true;
                }
            }
            
            
        }
        for (int i = 0; i < projectile.Length; i++)
        {
            if (proj < projectile.Length)
            {
                if (projectile[i] != projectile[proj])
                {
                    Button projBtn = projectile[i].GetComponent<Button>();
                    projBtn.enabled = false;
                }
                else if (projectile[i] == projectile[proj])
                {
                    Button projBtn = projectile[i].GetComponent<Button>();
                    projBtn.enabled = true;
                }
            }
            
        }
    }

    public void Blue()
    {
        green.gameObject.SetActive(false);
        red.gameObject.SetActive(false);
        yellow.gameObject.SetActive(false);
        blue.rectTransform.localPosition = new Vector3(0, 180, 0);
        chosen = true;

    }

    public void Green()
    {
        blue.gameObject.SetActive(false);
        red.gameObject.SetActive(false);
        yellow.gameObject.SetActive(false);
        green.rectTransform.localPosition = new Vector3(0, 180, 0);
        chosen = true;
    }

    public void Red()
    {
        green.gameObject.SetActive(false);
        blue.gameObject.SetActive(false);
        yellow.gameObject.SetActive(false);
        red.rectTransform.localPosition = new Vector3(0, 180, 0);
        chosen = true;
    }

    public void Yellow()
    {
        green.gameObject.SetActive(false);
        red.gameObject.SetActive(false);
        blue.gameObject.SetActive(false);
        yellow.rectTransform.localPosition = new Vector3(0, 180, 0);
        chosen = true;
    }

    public void Spec()
    {
        if (spec < 3)
        {
            spec++;
        }
        

    }

    public void Proj()
    {
        if (proj < 3)
        {
            proj++;
        }
    }

    public void ExitShop()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
