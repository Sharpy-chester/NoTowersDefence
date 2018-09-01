using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

    public GameObject enemy;
    public int wave;
    public int maxEnemiesPerWave;
    public int enemyNum;
    public GameObject startPath;
    public float wait;
    float maxWait = 2;


	void Start () {
        maxEnemiesPerWave = 5;
        enemyNum = 0;
        wait = 0;
        maxWait = 2;
	}
	

	void Update () {
        wait += Time.deltaTime;
        if (wait >= maxWait)
        {
            wait = 0f;
            if (enemyNum <= maxEnemiesPerWave)
            {
                Instantiate(enemy, startPath.transform.position, this.transform.rotation);
            }
            
            
            
        }





	}
}
