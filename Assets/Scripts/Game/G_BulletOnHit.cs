using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_BulletOnHit : MonoBehaviour
{
    [Header("¤l¼u³]©w")]
    public float range;
    public ParticleSystem projectileEffect;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            G_WallState G_State=other.GetComponent<G_WallState>();
            G_State.AddWallint();
            //print("add!");
            Destroy(this.gameObject);
        }
        if (other.tag =="Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }
}
