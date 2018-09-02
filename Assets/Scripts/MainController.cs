using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {

    public GameObject enemy;
    public int wave;
    public int maxEnemiesPerWave;
    public int enemyNum;
    public GameObject startPath;
    public float wait;
    float maxWait = 2;
    public Text waveText;
    public List<GameObject> enemies;
    public float waveWait;
    public float maxWaveWait = 5;
    public int hp = 10;
    public Text hpText;
    public Text creditText;
    public int credits;
    public GameObject shop;
    

    void Start () {
        maxEnemiesPerWave = 5;
        enemyNum = 0;
        hp = 20;
        maxWait = 2;
        wave = 0;
        waveWait = 0;
        wait = maxWait;
        credits = 0;
        shop.gameObject.SetActive(false);
	}
	

	void Update () {
        wait += Time.deltaTime;
        if (wait >= maxWait)
        {
            wait = 0f;
            if (enemyNum + 1 <= maxEnemiesPerWave)
            {
                enemies.Add(Instantiate(enemy, startPath.transform.position, this.transform.rotation));
                enemyNum++;
            }
            
            
        }
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                
                
                enemies.Remove(enemies[i]);
            }
        }

        waveText.text = "Wave: " + (wave + 1);
        hpText.text = "Health " + hp;

        if (enemies.Count == 0 && enemyNum == maxEnemiesPerWave)
        {
            waveWait += Time.deltaTime;
            if (waveWait >= maxWaveWait)
            {
                wave++;
                enemyNum = 0;
                waveWait = 0;
                maxEnemiesPerWave++;
                
            }
        }
    }

    public void Shop()
    {
        Time.timeScale = 0;
        shop.gameObject.SetActive(true);
    }
}
