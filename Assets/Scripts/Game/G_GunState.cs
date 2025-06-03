using UnityEngine;
using static G_Item;

public enum G_ItemType
{
    SpreadGun,
    RapidFire,
    Evolve
}
public class G_GunState : MonoBehaviour
{
    public GameObject G_NormalBullet;
    public GameObject G_SpreadBullet;
    public Transform G_FirePoint;

    private float G_FireRate = 1f;
    private float G_FireCooldown = 0f;

    private enum G_WeaponType { Normal, Spread, Rapid };
    private G_WeaponType currentWeapon = G_WeaponType.Normal;

    void Update()
    {
        G_FireCooldown -= Time.deltaTime;
        if (Input.GetButton("Fire1") && G_FireCooldown <= 0)
        {
            Fire();
            G_FireCooldown = 1f / G_FireRate;
        }
    }

    void Fire()
    {
        switch (currentWeapon)
        {
            case G_WeaponType.Normal:
                Instantiate(G_NormalBullet, G_FirePoint.position, G_FirePoint.rotation);
                break;
            case G_WeaponType.Spread:
                for (int i = -1; i <= 1; i++)
                {
                    Quaternion spreadRotation = Quaternion.Euler(0, i * 10, 0) * G_FirePoint.rotation;
                    Instantiate(G_SpreadBullet, G_FirePoint.position, spreadRotation);
                }
                break;
            case G_WeaponType.Rapid:
                Instantiate(G_NormalBullet, G_FirePoint.position, G_FirePoint.rotation);
                break;
        }
    }

    public void ApplyItem(G_ItemType type)
    {
        switch (type)
        {
            case G_ItemType.SpreadGun:
                currentWeapon = G_WeaponType.Spread;
                break;
            case G_ItemType.RapidFire:
                currentWeapon = G_WeaponType.Rapid;
                G_FireRate = 5f; // 更快的射速
                break;
            case G_ItemType.Evolve:
                GetComponent<G_PlayerState>().Evolve(); // 呼叫角色進化功能
                break;
        }
    }
}
