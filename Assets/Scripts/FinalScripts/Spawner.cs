using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int defaultSpeed;
    public Vector2 spawnRange;
    float spawnedTime = 0;
    public float spawnDelta;
    public GameManager gm;
    public List<GameObject> spawnedList;
    int spawnedIndex = 0;
    public int maxEnemies;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - spawnedTime > spawnDelta && spawnedList.Count < maxEnemies)
        {
            SpawnEnemy();
            spawnedTime = Time.time;
        }
    }

    void SpawnEnemy()
    {
        int div = 10;
        bool divisible = false;
        int prefabIdx = 0;
        while (!divisible)
        {
            div = (int)Random.Range(2f, 100f);
            if(div % 2 == 0 || div % 3 == 0 || div % 5 == 0 || div % 7 == 0)
            {
                if(div % 7 == 0)
                {
                    prefabIdx = 3;
                }
                else if (div % 5 == 0)
                {
                    prefabIdx = 2;
                }
                else if (div % 3 == 0)
                {
                    prefabIdx = 1;
                }
                else if (div % 2 == 0)
                {
                    prefabIdx = 0;
                }
                divisible = true;
            }
        }
        GameObject enemy = GameObject.Instantiate(enemyPrefabs[prefabIdx]);
        EnemyManager em = enemy.GetComponent<EnemyManager>();
        em.value = div;
        em.gm = gm;
        em.id = spawnedIndex;
        spawnedIndex++;
        EnemyMovement emv = enemy.GetComponent<EnemyMovement>();
        emv.speed = defaultSpeed;
        Vector2 newPos = new Vector2(Random.Range(spawnRange.x, spawnRange.y), this.transform.position.y);
        enemy.transform.position = newPos;
        spawnedList.Add(enemy);
    }

    public void RemoveFromList(int id)
    {
        GameObject toDestroy = null;
        for (int i = 0; i < spawnedList.Count; i++)
        {
            GameObject enemy = spawnedList[i];
            EnemyManager em = enemy.GetComponent<EnemyManager>();
            if(em.id == id)
            {
                spawnedList.Remove(enemy);
                toDestroy = enemy;
            }
        }
        GameObject.Destroy(toDestroy);
    }

    public void DespawnAll()
    {
        for(int i = spawnedList.Count - 1; i >= 0; i--)
        {
            GameObject enemy = spawnedList[i];
            spawnedList.Remove(enemy);
            GameObject.Destroy(enemy);
        }
        spawnedTime = Time.time;
    }
}
