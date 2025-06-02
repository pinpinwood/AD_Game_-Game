using UnityEngine;

public class G_GameManager : MonoBehaviour
{
    public static G_GameManager Instance;

    public float bossSpawnTimer = 60f;
    private float bossTimer = 0f;

    public bool isBossActive = false;

    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private Transform bossSpawnPoint;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (isBossActive) return;

        bossTimer += Time.deltaTime;
        if (bossTimer >= bossSpawnTimer)
        {
            bossTimer = 0f;
            SpawnBoss();
        }
    }

    void SpawnBoss()
    {
        isBossActive = true;

        GameObject boss = Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
        boss.GetComponent<G_BossState>().OnBossDead += OnBossDefeated;
    }

    void OnBossDefeated()
    {
        isBossActive = false;
    }
}
