using TMPro;
using UnityEngine;

public class G_itemState : MonoBehaviour
{
    [Header("物件設定")]
    public int G_Wallint;

    [Header("牆壁UI(字體）")]
    [SerializeField] private TextMeshProUGUI valueText;
    
    public G_ItemType G_ItemType;
    private int HP;


    private void Start()
    {

        // 根據道具類型設定對應血量
        switch (G_ItemType)
        {
            case G_ItemType.RapidFire:
                HP = 100;
                break;
            case G_ItemType.SpreadGun:
                HP = 50;
                break;
            case G_ItemType.Evolve:
                HP = 40; // 你可以自訂
                break;
            default:
                HP = 20;
                break;
        }
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            TriggerEffect();
            Destroy(gameObject);
        }
    }

    private void TriggerEffect()
    {
        G_GunState player = FindObjectOfType<G_GunState>();
        if (player != null)
        {
            player.ApplyItem(G_ItemType);
        }

        Debug.Log("取得道具：" + G_ItemType.ToString());
    }   
}
