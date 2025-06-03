using UnityEngine;

public class G_Item : MonoBehaviour
{

    public G_ItemType itemType;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<G_PlayerState>();

            switch (itemType)
            {
                case G_ItemType.SpreadGun:
                    player.SwitchWeapon();
                    break;
                case G_ItemType.RapidFire:
                    player.SwitchWeapon();
                    break;
                case G_ItemType.Evolve:
                    player.Evolve();
                    break;
            }

            Destroy(gameObject); // 撞到就消失
        }
    }
}
