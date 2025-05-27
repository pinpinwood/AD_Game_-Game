using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class G_SpawnPoint : MonoBehaviour
{
    [Header("生成間隔")]
    public float spawnInterval = 3f;

    [Header("Spawn Point 設定")]
    public Transform[] G_SpawnPoints;

    [Header("Prefab 設定")]
    public GameObject G_EnemyPrefab;
    public GameObject G_WallPrefab;
   // public GameObject G_ItemWallPrefab;

    [Header("最大生成數")]
    public int G_MaxWallCount = 2;
    public int G_MaxItemWallCount = 1;

    [Header("敵人生成數量範圍")]
    public int G_MinEnemies = 3;
    public int G_MaxEnemies = 7;

    [Header("出現機率")]
    [Range(0f, 1f)] public float G_EnemyChance = 0.8f;
    [Range(0f, 1f)] public float G_WallChance = 0.6f;
    [Range(0f, 1f)] public float G_ItemWallChance = 0.3f;

    [Header("排隊格數與間距")]
    public int G_TotalSlots = 7;
    public float G_SlotSpacing = 2f;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnAtEachPoint();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnAtEachPoint()
    {
        foreach (Transform spawnOrigin in G_SpawnPoints)
        {
            List<int> availableSlots = new List<int>();
            for (int i = 0; i < G_TotalSlots; i++) availableSlots.Add(i);

            // 先處理敵人
            if (Random.value < G_EnemyChance)
            {
                int enemyCount = Random.Range(G_MinEnemies, G_MaxEnemies + 1);
                List<int> enemySlots = GetCenterAlignedSlots(enemyCount, availableSlots);
                foreach (int slot in enemySlots)
                {
                    Vector3 pos = spawnOrigin.position + new Vector3((slot - G_TotalSlots / 2) * G_SlotSpacing, 0, 0);
                    Instantiate(G_EnemyPrefab, pos, Quaternion.identity);
                    availableSlots.Remove(slot);
                }
            }

            // 牆壁
            if (Random.value < G_WallChance)
            {
                int wallCount = Random.Range(1, G_MaxWallCount + 1);
                SpawnObjects(G_WallPrefab, wallCount, spawnOrigin, availableSlots);
            }

            // 道具牆
           // if (Random.value < G_ItemWallChance)
            {
           //     int itemWallCount = Random.Range(1, G_MaxItemWallCount + 1);
           //     SpawnObjects(G_ItemWallPrefab, itemWallCount, spawnOrigin, availableSlots);
            }
        }
    }

    void SpawnObjects(GameObject prefab, int count, Transform origin, List<int> availableSlots)
    {
        for (int i = 0; i < count && availableSlots.Count > 0; i++)
        {
            int randIndex = Random.Range(0, availableSlots.Count);
            int slot = availableSlots[randIndex];
            availableSlots.RemoveAt(randIndex);

            Vector3 pos = origin.position + new Vector3((slot - G_TotalSlots / 2) * G_SlotSpacing, 0, 0);
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }

    List<int> GetCenterAlignedSlots(int count, List<int> available)
    {
        List<int> result = new List<int>();
        int center = G_TotalSlots / 2;

        List<int> sorted = new List<int>(available);
        sorted.Sort((a, b) => Mathf.Abs(a - center).CompareTo(Mathf.Abs(b - center)));

        foreach (int slot in sorted)
        {
            if (result.Count >= count) break;
            result.Add(slot);
        }

        return result;
    }
}
