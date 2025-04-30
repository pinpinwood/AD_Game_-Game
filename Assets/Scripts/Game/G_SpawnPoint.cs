using System.Threading;
using UnityEngine;

public class G_SpawnPoint : MonoBehaviour
{
    [Header("出生點設定")]
    public Transform[] spawnPoints; 
    public GameObject wallPrefab;
    public GameObject enemyPrefab;

    private float timer;
    public float spawnInterval = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnWallAndEnemy();   
        }
    }
    void SpawnWallAndEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform chosenPoint = spawnPoints[randomIndex];
        Debug.Log("Spawning at: " + Time.time);
        // 生成牆
        GameObject newWall = Instantiate(wallPrefab, chosenPoint.position, Quaternion.identity);
        int randomValue = Random.Range(-5, 10);
        G_WallState wallScript = newWall.GetComponent<G_WallState>();
        wallScript.SetValue(randomValue);

        // 生成敵人
        Vector3 enemySpawnPos = chosenPoint.position + new Vector3(1f, 0, 0); // X軸偏一點
        Instantiate(enemyPrefab, enemySpawnPos, Quaternion.identity);
        timer = 0f;
    }
}
