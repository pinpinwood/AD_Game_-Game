using UnityEngine;

public class G_BossState : MonoBehaviour
{
    public delegate void BossDeadHandler();
    public event BossDeadHandler OnBossDead;

    public int health = 10;

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            OnBossDead?.Invoke(); // 通知 GameManager Boss 被打敗了
            Destroy(gameObject);
        }
    }
}
