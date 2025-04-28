using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Gun_Shoot : MonoBehaviour
{

    public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public float projectileSpeed = 30f;
    public float lifeTime = 0.3f;
    float timer = 0;
  

    void Start()
    {

    }
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > lifeTime)
        {
            Fire();
            timer = 0; //重置計時器
                       //Debug.Log("時間重置");
        }
        //Debug.Log(timer);
    }
    void Update()
    {
      
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab);
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), projectileSpawn.parent.GetComponent<Collider>());
        projectile.transform.position = projectileSpawn.position;
        Vector3 rotation = projectile.transform.rotation.eulerAngles;
        projectile.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        projectile.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * projectileSpeed, ForceMode.Impulse);
        //StartCoroutine("DestroyProjectile");
    }

    private IEnumerator DestroyProjectile(GameObject projectile)
    {
        yield return new WaitForSeconds(2);
        Destroy(projectile);
    }
}
