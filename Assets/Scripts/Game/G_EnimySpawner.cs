using UnityEngine;

public class G_EnimySpawner : MonoBehaviour
{
    [SerializeField] private GameObject G_EnemyPrefab;
    [SerializeField] private Transform G_EnemyParent; // 母物件，用來整理生成的敵人
    [SerializeField] private Transform[] G_SpawnStartPoint;
    [SerializeField] private int G_RowLimit = 5; // 每排最多幾隻
    [SerializeField] private float G_Spacing = 1.5f;

    private float G_SpawnInterval = 5f;
    private float G_MinSpawnInterval = 1.5f;
    private float G_TimePassed = 0f;
    private float G_IntervalReductionRate = 0.5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemies), 2f, G_SpawnInterval);
    }

    private void Update()
    {
        G_TimePassed += Time.deltaTime;

        // 每30秒降低一次生成間隔
        if (G_TimePassed > 30f && G_SpawnInterval > G_MinSpawnInterval)
        {
            G_SpawnInterval -= G_IntervalReductionRate;
            G_SpawnInterval = Mathf.Max(G_MinSpawnInterval, G_SpawnInterval);
            G_TimePassed = 0f;

            CancelInvoke(nameof(SpawnEnemies));
            InvokeRepeating(nameof(SpawnEnemies), 0f, G_SpawnInterval);
        }
    }

    void SpawnEnemies()
    {
        Transform point = G_SpawnStartPoint[Random.Range(0, G_SpawnStartPoint.Length)];
        int enemyCount = Random.Range(3, 7); // 一次生成 3～6 隻敵人

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject newEnemy = Instantiate(G_EnemyPrefab, G_EnemyParent);

            int row = i / G_RowLimit;
            int col = i % G_RowLimit;

            Vector3 offset = new Vector3(col * G_Spacing, 0, row * G_Spacing);
            newEnemy.transform.position = point.position + offset;
        }
    }
}
