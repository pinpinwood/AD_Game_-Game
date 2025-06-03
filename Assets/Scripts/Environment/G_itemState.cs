using TMPro;
using UnityEngine;

public class G_itemState : MonoBehaviour
{
    [Header("����]�w")]
    public int G_Wallint;

    [Header("���UI(�r��^")]
    [SerializeField] private TextMeshProUGUI valueText;
    
    public G_ItemType G_ItemType;
    private int HP;


    private void Start()
    {

        // �ھڹD�������]�w������q
        switch (G_ItemType)
        {
            case G_ItemType.RapidFire:
                HP = 100;
                break;
            case G_ItemType.SpreadGun:
                HP = 50;
                break;
            case G_ItemType.Evolve:
                HP = 40; // �A�i�H�ۭq
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

        Debug.Log("���o�D��G" + G_ItemType.ToString());
    }   
}
