using UnityEngine;

public class G_EnimyState:MonoBehaviour
{
    [Header("¼Ä¤H³]©w")]
    [SerializeField] private int G_EnimyHP;
    [SerializeField] private float speed;
    private void Update()
    {
        Vector3 newPos = transform.position + transform.forward * -speed * Time.deltaTime;
        this.transform.position = newPos;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            //Debug.Log("You Dead");
            G_PlayerState g_Player = other.gameObject.GetComponentInParent<G_PlayerState>();
                g_Player.RemoveMembers(1);
        }
    }
}
