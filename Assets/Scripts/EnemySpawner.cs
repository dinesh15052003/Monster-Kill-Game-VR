using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public static List<GameObject> enemyPrefabs = new List<GameObject>();

    public GameObject enemies;
    public float enemyBurstCount = 3, spawnTime = 1;
    Transform location;
    float updateTime;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
            spawnPoints.Add(child);
        Object[] subObjects = Resources.LoadAll("Prefabs", typeof(GameObject));
        foreach (GameObject subObject in subObjects)
        {
            GameObject lo = (GameObject)subObject;
            enemyPrefabs.Add(lo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > updateTime)
        {
            updateTime = Time.time + spawnTime;
            SpawnEnemy();
        }
        
    }

    public void SpawnEnemy()
    {
        if (enemies.transform.childCount < enemyBurstCount)
        {
            location = spawnPoints[Random.Range(0, transform.childCount)];
            GameObject item = enemyPrefabs[Random.Range(0, 5)];
            var enemyInstance = Instantiate(item, location);
            enemyInstance.transform.SetParent(enemies.transform);
            enemyInstance.transform.LookAt(Vector3.zero);
        }
    }
}
