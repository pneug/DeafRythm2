using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager inst;
    
    public GameObject EnemyPrefab;
    public List<Enemy> enemies;
    private bool spawnedEnemy;

    private void Awake()
    {
        inst = this;
    }

    public void OnBeat()
    {
        if (!spawnedEnemy)
        {
            GameObject newEnemy = Instantiate(EnemyPrefab, transform);
            int randInt = Random.Range(0, 3);
            newEnemy.transform.localPosition = new Vector3(-150 + 150 * randInt, 0, 0);
            enemies.Add(newEnemy.GetComponent<Enemy>());
        }
        spawnedEnemy = !spawnedEnemy;
        // spawn enemies
    }
}
