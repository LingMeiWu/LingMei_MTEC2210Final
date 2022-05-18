using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemys;
    public Transform[] enemySpawnPoints;
    public float time = 180f;
    private float lastSpawnTime;
    public int enemyFrequency = 1;
    public static float score = 0f;
    public Text scoreText;
    public Text timeText;
    public static AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = 0;
        }
        timeText.text = Mathf.Floor(time / 60).ToString("00")+ ":" + (time % 60).ToString("00");
        scoreText.text = "Score: " + score.ToString("0000");
        if (time <= 0)
        {
            Time.timeScale = 0;
        }

        if (lastSpawnTime - time >= enemyFrequency)
        {
            SpawnEnemy();
            
        }
        

    }

    void SpawnEnemy()
    {
        // selected a random position
        int index = Random.Range(0, enemySpawnPoints.Length);
        Vector3 spawnPos = enemySpawnPoints[index].position;

        // selected a random enemy 
        int enemyindex = Random.Range(0, enemys.Length);
        GameObject enemy = Instantiate(enemys[enemyindex]);
        enemy.transform.position = spawnPos;

        lastSpawnTime = time;
    }


}
